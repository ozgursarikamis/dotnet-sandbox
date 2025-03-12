FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["API/CQRS.Kafka.API/CQRS.Kafka.API.csproj", "API/CQRS.Kafka.API/"]
RUN dotnet restore "API/CQRS.Kafka.API/CQRS.Kafka.API.csproj"
COPY . .
WORKDIR "/src/API/CQRS.Kafka.API"
RUN dotnet build "CQRS.Kafka.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "CQRS.Kafka.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CQRS.Kafka.API.dll"]
