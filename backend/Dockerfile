# Etapa de build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copia tudo para o container
COPY . .

# Restaura e publica a API
WORKDIR /src/LeituraLivre.API
RUN dotnet restore
RUN dotnet publish -c Release -o /app/publish

# Etapa final: runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "LeituraLivre.API.dll"]
