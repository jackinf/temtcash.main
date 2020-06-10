# TemtCash - Main

## Description

This is the core logic for the TemtCash portal.
It depends on the authority server - TemtCash.Auth.

## Before running

1. Make sure that you have dotnet core 2.1 installed
2. Make sure that you have MSSQL server and Connection String is defined both in `TemtCash.Main.Api` and `TemtCash.Main.IntegrationTests`

## How to run the app

Just run the application (`dotnet run`). It will auto-migrate the MSSQL database & pop-up the swagger.
Note that the routes are protected. To see the routes in action, just have TemtCash.Auth server running.

Alternatively, you can uncomment `[Authorized]` attribute on top of the controllers but I won't guarantee that everything would work correctly.
TODO: Need to check that.

## Running the tests

This project has only integration tests, and they are dependent on real MSSQL db.
Configure connection strings in `appsettings.json` & `DbContextHelper.cs` before running integration tests.

## What needs to be done in order to improve the code

1. Add unit test project
2. Fix code in integration tests for better maintainability. E.g. it's a mistake to have connection string in two places.
3. Migrate to dotnet core 3.1
4. Integration tests should use in-memory DB (or Sqlite).
5. Have Auth0 as an authentication server instead of the custom `TemtCash.Auth` one.