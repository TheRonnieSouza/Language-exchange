# Etapa Build e Publicação da API 
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

WORKDIR /src
COPY ["language-exchange-api.csproj", "."]
RUN dotnet restore "./language-exchange-api.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "./language-exchange-api.csproj" -c Release -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./language-exchange-api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false


# Base: Instalação do yt-dlp e Dependências 
FROM alpine:3.21.3  AS base

ARG BUILD_VERSION
# Instala pacotes necessários e limpa cache para reduzir o tamanho da imagem
RUN set -x \
 && apk update \
 && apk upgrade -a \
 && apk add --no-cache \
    #ca-certificates \
    curl \
    ffmpeg \
    python3 \
    py3-mutagen \
    dumb-init 

# Instala yt-dlp

RUN curl -Lo /usr/local/bin/yt-dlp https://github.com/yt-dlp/yt-dlp/releases/download/2025.01.26/yt-dlp \
 && chmod a+rx /usr/local/bin/yt-dlp \
   && apk del curl 


# Etapa Final: Runtime da API .NET + Dependências
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final

## Instala dependências necessárias para rodar yt-dlp
#RUN apk add --no-cache \
   ## ca-certificates \
    #ffmpeg \
    #python3 \
    #py3-pip \
    #dumb-init

# Configura o PATH para incluir /usr/local/bin (onde o yt-dlp está localizado)
ENV PATH="/usr/local/bin:${PATH}"

# Cria o diretório para downloads
WORKDIR /downloads
VOLUME ["/downloads"]

# Copia yt-dlp do estágio base
COPY --from=base /usr/local/bin/yt-dlp /usr/local/bin/yt-dlp

WORKDIR /usr/local/bin/
RUN apt-get update && apt-get install -y ffmpeg


# Define o diretório de trabalho padrão para a aplicação .NET
WORKDIR /var/task

# Copia os arquivos publicados da API .NET
COPY --from=publish /app/publish .

# Configuração da variável de ambiente para certificados SSL
#ENV SSL_CERT_FILE=/etc/ssl/certs/ca-certificates.crt

# Ponto de entrada da aplicação, permitindo argumentos dinâmicos via comando
ENTRYPOINT ["dotnet", "language-exchange-api.dll"]
CMD ["--help"]

EXPOSE 8080
EXPOSE 8081