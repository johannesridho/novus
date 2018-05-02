#!/bin/sh

docker rm -f novus-api
docker rmi -f novus-api
docker build -t novus-api .
docker run -d -p 4000:4000 --name novus-api --restart unless-stopped novus-api
