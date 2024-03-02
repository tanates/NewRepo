FROM node:14-alpine
ENV PATH=/usr/local/bin:$PATH
WORKDIR /app
COPY package*.json ./
COPY ./stroitrendtesttask.client .
RUN npm install
COPY . .
RUN npm run build
EXPOSE 3000
CMD ["npm", "start"]
