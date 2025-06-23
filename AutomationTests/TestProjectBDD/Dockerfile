# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copy project files
COPY ["AutomationTests/TestProjectBDD/TestProjectBDD.csproj", "AutomationTests/TestProjectBDD/"]
COPY ["AutomationTests/TestFramework/TestFramework.csproj", "AutomationTests/TestFramework/"]
COPY ["App/ProductAPI/ProductAPI.csproj", "App/ProductAPI/"]

# Restore
RUN dotnet restore "AutomationTests/TestProjectBDD/TestProjectBDD.csproj"

# Copy all source
COPY . .

# Build
WORKDIR "/src/AutomationTests/TestProjectBDD"
RUN dotnet build "TestProjectBDD.csproj" -c Release -o /app/build

# Stage 2: Test execution image
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS test
WORKDIR /src/AutomationTests/TestProjectBDD

# Copy source tree
COPY --from=build /src /src

# Copy script and set execute permission
COPY scripts/WaitAndRun.sh /scripts/WaitAndRun.sh
RUN chmod +x /scripts/WaitAndRun.sh

# Set entrypoint
ENTRYPOINT ["/scripts/WaitAndRun.sh"]
