# Socca

# Create database migrations for each microservice

FootballClub
------------
Migrations have already been created for you however to create migration (from the directory src/Microservices/FootballClub/Api/Socca.FootballClub.Api)run the following command:
dotnet ef migrations add InitialMigration --context footballclubdbcontext -p ../../Data/Socca.FootballClub.Data/Socca.FootballClub.Data.csproj -s Socca.FootballClub.Api.csproj -o Migrations


FootballClubStadium
-------------------
Migrations have already been created for you however to create migration (from the directory src/Microservices/FootballClubStadium/Api/Socca.FootballClubStadium.Api) run the following command:
dotnet ef migrations add InitialMigration --context footballclubstadiumdbcontext -p ../../Data/Socca.FootballClubStadium.Data/Socca.FootballClubStadium.Data.csproj -s Socca.FootballClubStadium.Api.csproj -o Migrations

Players
-------
Migrations have already been created for you however to create migration (from the directory src/Microservices/Players/Api/Socca.Players.Api) and run the following command:
dotnet ef migrations add InitialMigration --context playerdbcontext -p ../../Data/Socca.Players.Data/Socca.Players.Data.csproj -s Socca.Players.Api.csproj -o Migrations

PlayerTransfers
---------------
Migrations have already been created for you however to create migration (from the directory src/Microservices/PlayerTransfers/Api/Socca.PlayerTransfers.Api) and run the following command:
dotnet ef migrations add InitialMigration --context playertransferdbcontext -p ../../Data/Socca.PlayerTransfers.Data/Socca.PlayerTransfers.Data.csproj -s Socca.PlayerTransfers.Api.csproj -o Migrations


Stadium
-------
Migrations have already been created for you however to create migration (from root directory src/Microservices/Stadium/Api/Socca.Stadium.Api) run the following command:
dotnet ef migrations add InitialMigration --context stadiumdbcontext -p ../../Data/Socca.Stadium.Data/Socca.Stadium.Data.csproj -s Socca.Stadium.Api.csproj -o Migrations


