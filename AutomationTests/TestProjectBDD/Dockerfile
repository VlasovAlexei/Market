FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Копируем проекты
COPY ["AutomationTests/TestProjectBDD/TestProjectBDD.csproj", "AutomationTests/TestProjectBDD/"]
COPY ["AutomationTests/TestFramework/TestFramework.csproj", "AutomationTests/TestFramework/"]
COPY ["App/ProductAPI/ProductAPI.csproj", "App/ProductAPI/"]

RUN dotnet restore "AutomationTests/TestProjectBDD/TestProjectBDD.csproj"

COPY . .

WORKDIR "/src/AutomationTests/TestProjectBDD"
RUN dotnet build "TestProjectBDD.csproj" -c Release -o /app/build

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS test
WORKDIR /src/AutomationTests/TestProjectBDD

COPY --from=build /src /src
COPY scripts/WaitAndRun.sh /scripts/WaitAndRun.sh
RUN chmod +x /scripts/WaitAndRun.sh

ENTRYPOINT ["/scripts/WaitAndRun.sh"]
