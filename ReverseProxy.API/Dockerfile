﻿FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 9000
EXPOSE 9001

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ReverseProxy.API/ReverseProxy.API.csproj", "ReverseProxy.API/"]
RUN dotnet restore "ReverseProxy.API/ReverseProxy.API.csproj"
COPY . .
WORKDIR "/src/ReverseProxy.API"
RUN dotnet build "ReverseProxy.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "ReverseProxy.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ReverseProxy.API.dll"]
