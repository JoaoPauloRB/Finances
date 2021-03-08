FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["Domain/Domain.csproj", "Domain/"]
COPY ["Service/Service.csproj", "Service/"]
COPY ["Infra/Infra.csproj", "Infra/"]
COPY ["Application/Application.csproj", "Application/"]
RUN dotnet restore "Application/Application.csproj"
COPY ["Domain/", "Domain/"]
COPY ["Service/", "Service/"]
COPY ["Infra/", "Infra/"]
COPY ["Application/", "Application/"]
WORKDIR "/src/Application"
RUN dotnet build "Application.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Application.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Application.dll"]