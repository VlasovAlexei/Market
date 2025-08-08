#!/usr/bin/env sh

set -e
set -x

project="e2etest"

cd "$(dirname "${0}")/.."

export COMPOSE_HTTP_TIMEOUT=200

docker-compose -p "$project" build

docker-compose -p "$project" up -d product_api webapp db selenium-hub firefox chrome 

docker-compose -p "$project" up --no-deps test_project

exit_code=$(docker inspect test_project --format='{{.State.ExitCode}}')

if [ $exit_code -eq 0 ]; then
    exit $exit_code
else 
    echo "Tests failed"
fi
