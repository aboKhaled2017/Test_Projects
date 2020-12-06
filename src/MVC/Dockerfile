#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#get base image (.Net core sdk)
FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /app

#copy csproj and restore
COPY ["MVC/MVC.csproj", "MVC/"]
COPY ["MVC_Lib1/.", "MVC_Lib1/"]
RUN dotnet restore "MVC/MVC.csproj"
WORKDIR /app/MVC
#copy every thing else and build
COPY MVC/ .

FROM build AS publish
RUN dotnet publish  -c Release -o /app/out

#generate runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim 
WORKDIR /app
EXPOSE 80
COPY --from=publish /app/out .
## Add the wait script to the image
ADD https://github.com/ufoscout/docker-compose-wait/releases/download/2.7.3/wait /wait
RUN chmod +x /wait
CMD /wait && dotnet MVC.dll
