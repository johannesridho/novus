FROM mhart/alpine-node:base-8.9.0
WORKDIR /source

RUN apk update && apk add sqlite

ADD . .

CMD ["node", "app.js"]
