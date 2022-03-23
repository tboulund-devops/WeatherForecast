FROM nginx
COPY . /usr/share/nginx/html
RUN chmod 777 /usr/share/nginx/html/expose-env.sh
CMD /usr/share/nginx/html/expose-env.sh
ENTRYPOINT "/docker-entrypoint.sh"