using LanguageExchange.Application.Models.LanguagesModels;
using LanguageExchange.Application.Services.LanguageServices;
using Microsoft.AspNetCore.Mvc;

namespace LanguageExchangeAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LanguageController : ControllerBase
    {
        private readonly ILanguageService _languageService;
        public LanguageController(ILanguageService languageService)
        {
            _languageService = languageService;
        }

        [HttpPost] 
        public async Task<IActionResult> CreateLanguage(CreateLanguageInputModel language)
        {
            var result = await _languageService.AddLanguage(language);

            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllLanguages()
        {
            var result = await _languageService.GetAllLanguages();

            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLanguage(int id)
        {
            var result = await _languageService.DeleteLanguage(id);

            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
    }
}
