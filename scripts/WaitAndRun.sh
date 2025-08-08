#!/usr/bin/env sh
set -e
set -x

# Wait Selenium Grid with healthcheck
until curl -s http://selenium-hub:4444/wd/hub/status | grep '"ready": true' > /dev/null; do
    echo "Ожидаем готовность Selenium Grid..."
    sleep 2
done

# Run tests
dotnet test /src/AutomationTests/TestProjectBDD/TestProjectBDD.csproj --logger "console;verbosity=detailed"
