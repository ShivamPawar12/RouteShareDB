FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY . .
RUN dotnet restore "routesharebackend.csproj"
RUN dotnet publish "routesharebackend.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

COPY --from=build /app/publish .

# Disable FileSystemWatcher on Linux
ENV DOTNET_USE_POLLING_FILE_WATCHER=1

# Run in Production
ENV ASPNETCORE_ENVIRONMENT=Production

# Render port
ENV ASPNETCORE_URLS=http://+:10000

EXPOSE 10000

ENTRYPOINT ["dotnet", "routesharebackend.dll"]