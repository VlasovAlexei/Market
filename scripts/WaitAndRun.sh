#!/usr/bin/env sh

set -e
set -x

until curl -f "http://selenium-hub:4444/wd/hub/status" 2>/dev/null | grep -q '"ready": true'; do
  echo "⏳ Waiting for Selenium Grid..."
  sleep 5
done

dotnet test /src/AutomationTests/TestProjectBDD/TestProjectBDD.csproj --logger "console;verbosity=detailed"