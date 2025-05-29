# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:9.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY ["AutomationTests/IntegrationTests/IntegrationTests.csproj", "AutomationTests/IntegrationTests/"]
COPY ["App/ProductAPI/ProductAPI.csproj", "App/ProductAPI/"]
RUN dotnet restore "./AutomationTests/IntegrationTests/IntegrationTests.csproj"
COPY . .
WORKDIR "/src/AutomationTests/IntegrationTests"
RUN dotnet build "./IntegrationTests.csproj" -c Release -o /app/build

FROM build AS Integration
WORKDIR /src/AutomationTests/IntegrationTests
CMD ["dotnet", "test"]