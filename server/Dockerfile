FROM mhart/alpine-node:8.9.0
WORKDIR /source

RUN apk update && apk add sqlite

ADD . .

RUN npm i

CMD ["node", "app.js"]
