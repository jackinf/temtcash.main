Param(
  [Parameter(Mandatory=$true)][string]$MigrationName
)
dotnet ef migrations add $MigrationName -p ..\TemtCash.Main.DAL\TemtCash.Main.DAL.csproj