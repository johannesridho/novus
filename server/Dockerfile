FROM mhart/alpine-node:8.9.0
WORKDIR /source

RUN apk update && apk add sqlite

RUN npm i

ADD . .

CMD ["node", "app.js"]
