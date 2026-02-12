# ---------- BUILD STAGE ----------
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Copy solution and all projects
COPY . .

# Restore dependencies
RUN dotnet restore src/CourseLanding.Api/CourseLanding.Api.csproj

# Publish API
RUN dotnet publish src/CourseLanding.Api/CourseLanding.Api.csproj \
    -c Release \
    -o /app/publish \
    --no-restore

# ---------- RUNTIME STAGE ----------
FROM mcr.microsoft.com/dotnet/aspnet:10.0
WORKDIR /app

COPY --from=build /app/publish .

ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

ENTRYPOINT ["dotnet", "CourseLanding.Api.dll"]
