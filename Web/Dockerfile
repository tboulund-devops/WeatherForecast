FROM nginx
COPY . /usr/share/nginx/html
RUN chmod 777 /usr/share/nginx/html/expose-env.sh

ENTRYPOINT ["/usr/share/nginx/html/expose-env.sh"]
CMD ["nginx" "-g" "daemon 