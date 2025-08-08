#!/usr/bin/env sh
set -e
set -x

echo "Waiting for Selenium Grid..."
until curl -sf http://selenium-hub:4444/wd/hub/status | grep -q '"ready": true'; do
  sleep 5
done

echo "Selenium is ready. Starting tests..."
dotnet test TestProjectBDD.csproj --logger "console;verbosity=detailed"
