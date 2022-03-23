mkdir /usr/share/nginx/html/config/
echo "YAY ${API_URL}"
echo "${API_URL}" > /usr/share/nginx/html/config/api-url.txt
cat /docker-entrypoint.sh
/docker-entrypoint.sh