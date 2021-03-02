FROM nginx:alpine AS final
WORKDIR /usr/share/nginx/html
COPY bin/Release/net5.0/publish .
COPY nginx.conf /etc/nginx/nginx.conf