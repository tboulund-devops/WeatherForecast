FROM nginx
COPY . /usr/share/nginx/html
COPY expose-env.sh /docker-entrypoint.d/40-expose-env.sh
RUN chmod /docker-entrypoint.d/40-expose-env.sh