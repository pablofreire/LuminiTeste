# Base para rodar a aplicação
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# Variáveis de ambiente
ENV CONNECTION_STRING ${CONNECTION_STRING}

# Fase de build
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/LuminiTeste/LuminiTeste.Api/LuminiTeste.Api.csproj", "LuminiTeste.Api/"]
COPY ["src/LuminiTeste/LuminiTeste.Domain/LuminiTeste.Domain.csproj", "LuminiTeste.Domain/"]
COPY ["src/LuminiTeste/LuminiTeste.Infra.IOC/LuminiTeste.Infra.IOC.csproj", "LuminiTeste.Infra.IOC/"]
COPY ["src/LuminiTeste/LuminiTeste.Infra.Data/LuminiTeste.Infra.Data.csproj", "LuminiTeste.Infra.Data/"]
RUN dotnet restore "./LuminiTeste.Api/LuminiTeste.Api.csproj"
COPY src .
WORKDIR "/src/LuminiTeste/LuminiTeste.Api"
RUN dotnet build "./LuminiTeste.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./LuminiTeste.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LuminiTeste.Api.dll"]
