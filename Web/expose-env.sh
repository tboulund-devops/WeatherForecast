mkdir /usr/share/nginx/html/config/
echo "YAY ${API_URL}"
echo "${API_URL}" > /usr/share/nginx/html/config/api-url.txt
/docker-entrypoint.sh