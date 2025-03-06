# Imagen base de .NET Runtime
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

# Imagen base de .NET SDK para compilar la app
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["EFconASPyMVC/EFconASPyMVC.csproj", "EFconASPyMVC/"]
RUN dotnet restore "EFconASPyMVC/EFconASPyMVC.csproj"
COPY . .
WORKDIR "/src/EFconASPyMVC"
RUN dotnet build "EFconASPyMVC.csproj" -c Release -o /app/build

# Publicar la app
FROM build AS publish
RUN dotnet publish "EFconASPyMVC.csproj" -c Release -o /app/publish

# Imagen final para ejecutar la aplicación
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EFconASPyMVC.dll"]
