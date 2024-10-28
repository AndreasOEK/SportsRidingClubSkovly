FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["SportsRideKlubSkovly.API/SportsRideKlubSkovly.API.csproj", "SportsRideKlubSkovly.API/"]
COPY ["Module.User.Application/Module.User.Application.csproj", "Module.User.Application/"]
COPY ["Module.User.Domain/Module.User.Domain.csproj", "Module.User.Domain/"]
COPY ["Module.Shared/Module.Shared.csproj", "Module.Shared/"]
COPY ["Module.User.Domain.Test/Module.User.Domain.Test.csproj", "Module.User.Domain.Test/"]
COPY ["Module.User.Infrastructure/Module.User.Infrastructure.csproj", "Module.User.Infrastructure/"]
COPY ["Module.User/Module.User.csproj", "Module.User/"]
RUN dotnet restore "SportsRideKlubSkovly.API/SportsRideKlubSkovly.API.csproj"
COPY . .
WORKDIR "/src/SportsRideKlubSkovly.API"
RUN dotnet build "SportsRideKlubSkovly.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "SportsRideKlubSkovly.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SportsRideKlubSkovly.API.dll"]
