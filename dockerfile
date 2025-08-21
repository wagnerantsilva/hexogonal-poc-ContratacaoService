# Etapa de build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copia tudo e restaura dependências
COPY . ./
RUN dotnet restore ./src/Contratacao.Api/Contratacao.Api.csproj

# Build da aplicação
RUN dotnet publish ./src/Contratacao.Api/Contratacao.Api.csproj -c Release -o out

# Etapa de runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/out .

# Expondo a porta padrão
EXPOSE 80
ENTRYPOINT ["dotnet", "Contratacao.Api.dll"]