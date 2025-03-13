using Amazon;
using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Transfer;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace language_exchange_api.Controllers
{
    [ApiController]
    [Route("Audio")]
    public class AudioController : ControllerBase
    {


        [HttpGet("download-debug-windows")]
        public async Task<IActionResult> DownloadAudioDebug([FromQuery] string link)
        {
            if (string.IsNullOrWhiteSpace(link))
            {
                return BadRequest("O parâmetro 'link' é obrigatório.");
            }

            // No container, usamos o WORKDIR definido no Dockerfile, que é "/var/task"
            //var workingDirectory = "/var/task";
            var workingDirectory = @"C:\Projetos\.NET\language-exchange-api\yt-dlp_Windows\";
            
            var outputDirectory = Path.Combine(workingDirectory, "output");
            if (!Directory.Exists(outputDirectory))
            {
              //  Directory.CreateDirectory(outputDirectory);
            }

            // Padrão fixo para o nome do arquivo: "audio.%(ext)s"
            var outputPattern = Path.Combine("output", "audio.%(ext)s");

            // Remove arquivos antigos para evitar conflitos
            //foreach (var file in Directory.GetFiles(outputDirectory, "audio.*"))
            //{
            //    System.IO.File.Delete(file);
            //}
            string ffmpegPath = Path.Combine(workingDirectory, @"ffmpeg-2025-02-10-git-a28dc06869-full_build\bin");
            // Monta o comando para o yt-dlp:
            // --extract-audio: extrai o áudio
            // --audio-format mp3: converte para mp3
            // -o "output/audio.%(ext)s": define o padrão de saída
            //var arguments = $"--ffmeg-location  \"{ffmpegPath}\" --extract-audio --audio-format mp3  --write-subs --sub-lang en  -o \"{outputPattern}\" {link}";

            var arguments = $"--ffmpeg-location  \"{ffmpegPath}\" --extract-audio --audio-format mp3  --write-subs --sub-lang en {link}";
            
            string ytDlpPath;
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                // Defina o caminho para o executável do yt-dlp no Windows, se disponível, ou informe o usuário
                ytDlpPath = @"C:\Projetos\.NET\language-exchange-api\yt-dlp_Windows\yt-dlp.exe"; // Altere conforme necessário
            }
            else
            {
                ytDlpPath = "/usr/local/bin/yt-dlp";
            }

            var processStartInfo = new ProcessStartInfo
            {
                FileName = ytDlpPath,
                Arguments = arguments,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = false,
                WorkingDirectory = workingDirectory   // Garante que o comando seja executado em /var/task (ou onde o WORKDIR estiver definido)
            };

            try
            {
                using var process = Process.Start(processStartInfo);
                if (process == null)
                {
                    return StatusCode(500, "Falha ao iniciar o processo do yt-dlp.");
                }

                var stdOutputTask = process.StandardOutput.ReadToEndAsync();
                var stdErrorTask = process.StandardError.ReadToEndAsync();

                await process.WaitForExitAsync();
                var output = await stdOutputTask;
                var error = await stdErrorTask;

                if (process.ExitCode != 0)
                {
                    return StatusCode(500, $"Erro ao baixar o áudio: {error}");
                }



                var mp3Files = Directory.GetFiles(workingDirectory, "*.mp3");


                string bucketName = "project-task-manager";

                IAmazonS3 _client = new AmazonS3Client(RegionEndpoint.USEast1);
                
                foreach (var file in mp3Files)
                {
                    using (var fileStream = new FileStream(file, FileMode.Open, FileAccess.Read))
                    {
                        var uploadRequest = new TransferUtilityUploadRequest
                        {
                            InputStream = fileStream,
                            Key = Path.GetFileName(file),
                            BucketName = bucketName,
                            ContentType = "audio/mpeg"
                        };

                        var fileTransferUtility = new TransferUtility(_client);
                        fileTransferUtility.Upload(uploadRequest);
                        Console.WriteLine($"Uploaded {file}");
                    }
                }

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }
        [HttpGet("download-PD")]
        public async Task<IActionResult> DownloadAudio([FromQuery] string link)
        {
            if (string.IsNullOrWhiteSpace(link))
            {
                return BadRequest("O parâmetro 'link' é obrigatório.");
            }

            var workingDirectory = "/var/task";

            var outputDirectory = Path.Combine(workingDirectory, "output");
            if (!Directory.Exists(outputDirectory))
            {
                  Directory.CreateDirectory(outputDirectory);
            }

            var outputPattern = Path.Combine("output", "audio.%(ext)s");

            
            string ffmpegPath = Path.Combine(workingDirectory, @"ffmpeg-2025-02-10-git-a28dc06869-full_build\bin");
          
            var arguments = $"--ffmpeg-location  /usr/bin --extract-audio --audio-format mp3  --write-subs --sub-lang en {link}";

            string ytDlpPath;
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                ytDlpPath = @"C:\Projetos\.NET\language-exchange-api\yt-dlp_Windows\yt-dlp.exe";
            }
            else
            {
                ytDlpPath = "/usr/local/bin/yt-dlp";
            }

            var processStartInfo = new ProcessStartInfo
            {
                FileName = ytDlpPath,
                Arguments = arguments,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = false,
                WorkingDirectory = workingDirectory   // Garante que o comando seja executado em /var/task (ou onde o WORKDIR estiver definido)
            };

            try
            {
                using var process = Process.Start(processStartInfo);
                if (process == null)
                {
                    return StatusCode(500, "Falha ao iniciar o processo do yt-dlp.");
                }

                var stdOutputTask = process.StandardOutput.ReadToEndAsync();
                var stdErrorTask = process.StandardError.ReadToEndAsync();

                await process.WaitForExitAsync();
                var output = await stdOutputTask;
                var error = await stdErrorTask;

                if (process.ExitCode != 0)
                {
                    return StatusCode(500, $"Erro ao baixar o áudio: {error}");
                }


                var mp3Files = Directory.GetFiles(workingDirectory, "*.mp3");


                string bucketName = "project-task-manager";

                IAmazonS3 _client = new AmazonS3Client(RegionEndpoint.USEast1);

                foreach (var file in mp3Files)
                {
                    using (var fileStream = new FileStream(file, FileMode.Open, FileAccess.Read))
                    {
                        var uploadRequest = new TransferUtilityUploadRequest
                        {
                            InputStream = fileStream,
                            Key = Path.GetFileName(file),
                            BucketName = bucketName,
                            ContentType = "audio/mpeg"
                        };

                        var fileTransferUtility = new TransferUtility(_client);
                        fileTransferUtility.Upload(uploadRequest);
                        Console.WriteLine($"Uploaded {file}");
                    }
                }

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }

        [HttpGet("test")]
        public IActionResult test()
        {
            return Ok("teste concluido");
        }
    }
}
