#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

ARG DOTNET_RUNTIME=mcr.microsoft.com/dotnet/aspnet:8.0
ARG DOTNET_SDK=mcr.microsoft.com/dotnet/sdk:8.0

FROM $DOTNET_RUNTIME AS base
USER $APP_UID
WORKDIR /app
EXPOSE 519
EXPOSE 403

FROM $DOTNET_SDK AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["StudentCredits.API/StudentCredits.API.csproj", "StudentCredits.API/"]
COPY ["StudentCredits.Contracts/StudentCredits.Contracts.csproj", "StudentCredits.Contracts/"]
COPY ["StudentCredits.Domain/StudentCredits.Domain.csproj", "StudentCredits.Domain/"]
COPY ["StudentCredits.Domain.Entities/StudentCredits.Domain.Entities.csproj", "StudentCredits.Domain.Entities/"]
COPY ["StudentCredits.Helpers/StudentCredits.Helpers.csproj", "StudentCredits.Helpers/"]
COPY ["StudentCredits.Infrastructure/StudentCredits.Infrastructure.csproj", "StudentCredits.Infrastructure/"]

COPY ["StudentCredits.Tests/StudentCredits.Tests.csproj", "StudentCredits.Tests/"]

RUN dotnet restore "./StudentCredits.API/StudentCredits.API.csproj"
COPY . .
WORKDIR "/src/StudentCredits.API"
RUN dotnet build "./StudentCredits.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./StudentCredits.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "StudentCredits.API.dll"]
