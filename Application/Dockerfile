FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim
WORKDIR /app
EXPOSE 5000
EXPOSE 5001
COPY bin/Release/net5.0/publish .
ENTRYPOINT ["dotnet", "Application.dll"]