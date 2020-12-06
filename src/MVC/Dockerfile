#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
ARG BUILD_CONFIGURATION=Debug
ENV ASPNETCORE_ENVIRONMENT=Development
ENV DOTNET_USE_POLLING_FILE_WATCHER=true
EXPOSE 80

WORKDIR /src

COPY ["MVC/MVC.csproj","MVC/"]
COPY ["MVC_Lib1/MVC_Lib1.csproj","MVC_Lib1/"]

RUN dotnet restore "MVC/MVC.csproj"
COPY . .
WORKDIR "/src/MVC"
RUN dotnet build --no-restore -c $BUILD_CONFIGURATION
ENTRYPOINT ["dotnet","run","--no-build","--no-launch-profile","-c","$BUILD_CONFIGURATION --"]
