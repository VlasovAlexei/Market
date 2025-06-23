# Base image with .NET runtime
FROM mcr.microsoft.com/dotnet/runtime:9.0 AS base
WORKDIR /app

# Build stage with .NET SDK
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copy project files
COPY ["AutomationTests/TestProjectBDD/TestProjectBDD.csproj", "AutomationTests/TestProjectBDD/"]
COPY ["AutomationTests/TestFramework/TestFramework.csproj", "AutomationTests/TestFramework/"]
COPY ["App/ProductAPI/ProductAPI.csproj", "App/ProductAPI/"]

# Restore dependencies
RUN dotnet restore "AutomationTests/TestProjectBDD/TestProjectBDD.csproj"

# Copy the entire source
COPY . .

# Build the project
WORKDIR "/src/AutomationTests/TestProjectBDD"
RUN dotnet build "TestProjectBDD.csproj" -c Release -o /app/build

# Final stage
FROM build AS TestProjectBDD
WORKDIR /app

# Copy built output
COPY --from=build /app/build .

# Copy script and set permissions
COPY scripts/WaitAndRun.sh /scripts/WaitAndRun.sh
RUN chmod +x /scripts/WaitAndRun.sh

# Set entry point
ENTRYPOINT ["/scripts/WaitAndRun.sh"]
