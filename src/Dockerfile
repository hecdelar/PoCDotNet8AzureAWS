# ==================================
# Build Stage
# ==================================
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiar el csproj y restaurar dependencias
COPY AdminRequest.WebAPI/AdminRequest.WebAPI.csproj AdminRequest.WebAPI/
RUN dotnet restore AdminRequest.WebAPI/AdminRequest.WebAPI.csproj

# Copiar todo el código
COPY . .

# Publicar
RUN dotnet publish AdminRequest.WebAPI/AdminRequest.WebAPI.csproj \
    -c Release \
    -o /app/publish \
    /p:UseAppHost=false

# ==================================
# Runtime Stage
# ==================================
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

ENV ASPNETCORE_URLS=http://+:8080
ENV ASPNETCORE_ENVIRONMENT=Development

EXPOSE 8080

COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "AdminRequest.WebAPI.dll"]