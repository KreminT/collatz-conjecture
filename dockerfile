#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM node:latest AS storefront

ENV BUILD_PATH=/out/
WORKDIR /app

COPY client/src/. ./client/src/
COPY client/public/. ./client/public/
COPY client/*.json ./client

WORKDIR /app/client
RUN npm install
RUN npm run build

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

WORKDIR /app

COPY service/src/. ./service/src/
COPY service/test/. ./service/test/
COPY service/*.sln ./service

WORKDIR /app/service
ENV DOTNET_CLI_HOME=/tmp/

RUN dotnet restore --no-cache 
RUN dotnet build --no-restore -c Release

FROM build as test
ENV OUTPUT_FOLDER "$OUTPUT_FOLDER"
WORKDIR /app/service/test/CollatzConjecture.Math.Test
CMD dotnet test --logger:"trx;LogFileName=$OUTPUT_FOLDER/testresults.trx" -c Release

FROM build as publish
RUN dotnet publish /app/service/src/CollatzConjecture/CollatzConjecture.csproj -c Release -r linux-x64 --self-contained false -p:PublishReadyToRun=true -o /out 


FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
COPY --from=publish /out/. /app/
COPY --from=storefront /out/. /app/client/
RUN chmod +x /app/

ENTRYPOINT ["dotnet", "CollatzConjecture.dll"]