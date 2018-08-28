FROM microsoft/dotnet:2.1-aspnetcore-runtime-alpine AS base
WORKDIR /app
EXPOSE 80
ENV ASPNETCORE_ENVIRONMENT=Development
ENV TEMTCASH_CONNECTION_STRING=""
ENV TEMTCASH_AUTHORITY=""

FROM microsoft/dotnet:2.1-sdk-alpine AS build
WORKDIR /src
COPY . .
WORKDIR /src/App/TemtCash.Main.Api
RUN dotnet restore -nowarn:msb3202,nu1503
RUN dotnet build --no-restore -c Release -o /app

FROM build AS publish
RUN dotnet publish --no-restore -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "TemtCash.Main.Api.dll"]