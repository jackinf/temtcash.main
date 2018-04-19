FROM microsoft/aspnetcore-build:2.0.3
COPY . .
RUN dotnet restore ./TemtCash.Main.sln
RUN dotnet publish ./TemtCash.Main.sln -c Release -o ./obj/Docker/publish
ENV ASPNETCORE_ENVIRONMENT=Development
ENV ASPNETCORE_CONNECTION_STRING="Server=tcp:stylehopper.database.windows.net,1433;Initial Catalog=TemtCash.Main;Persist Security Info=False;User ID=jackyinf;Password=123456aA!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
ENV ASPNETCORE_OAUTH_AUTHORITY="https://speyscloud-auth.azurewebsites.net/"
EXPOSE 80
EXPOSE 1433
ENTRYPOINT ["dotnet", "App/TemtCash.Main.Api/bin/Release/netcoreapp2.0/TemtCash.Main.Api.dll"]
