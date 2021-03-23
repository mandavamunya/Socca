# Technology used

.Net Core 5, RabbitMq, MsSQL, MediatR, Swagger

# Topics cover

Microservices architecture, event driven architecture, domain driven design, clean architetcure, unit test 

# Assumption

- The football clubs do not have a permanent home stadium and can be reassigned to a new stadium before the beginning of each season.
- Multiple events will be generated and possibly the event processors / consumers might take long to process hence why the use of an event bus.

# What's next

- Dockerize and use a RabbitMq docker image for a start
- Add Kubernetes support and deploy to Azure AKS
- Make use of Azure SQL Server

# Outstanding work

The entities FootballClubStadium and PlayerTransfer are actually event logs or history data and are not meant to be deleted. Each event must have a date occured or CreatedDate property. 

A property IsCurrent will also be added to each event and therefore another update old event implementation is needed to set IsCurrent to false before adding a new event.

```powershell
    public class FootballClubStadium
    {
        ...
        public DateTime DateCreated { get; set;}
        public bool IsCurrent { get; set; }
    }
```

```powershell
    public class PlayerTransfer
    {
        ...
        public DateTime DateCreated { get; set;}
        public bool IsCurrent { get; set; }
    }
```


# How to Run

- Make sure you update the ConnectionString for each microservice to match your machine''s configuration.
- Install rabbitmq on your machine or simple get a docker image and run it
- You are good to go. This is a multiple startup project you can simple hit the run project button and all the projects will start. 

NOTE: The steps will change once docker and kurbernetes are setup. There after no configuration will be needed before running the project.

# Create database migrations for each microservice

FootballClub
------------
Migrations have already been created for you however to create migration (from the directory src/Microservices/FootballClub/Api/Socca.FootballClub.Api)run the following command:
```powershell
dotnet ef migrations add InitialMigration --context footballclubdbcontext -p ../../Data/Socca.FootballClub.Data/Socca.FootballClub.Data.csproj -s Socca.FootballClub.Api.csproj -o Migrations
```

FootballClubStadium
-------------------
Migrations have already been created for you however to create migration (from the directory src/Microservices/FootballClubStadium/Api/Socca.FootballClubStadium.Api) run the following command:
```powershell
dotnet ef migrations add InitialMigration --context footballclubstadiumdbcontext -p ../../Data/Socca.FootballClubStadium.Data/Socca.FootballClubStadium.Data.csproj -s Socca.FootballClubStadium.Api.csproj -o Migrations
```

Players
-------
Migrations have already been created for you however to create migration (from the directory src/Microservices/Players/Api/Socca.Players.Api) and run the following command:
```powershell
dotnet ef migrations add InitialMigration --context playerdbcontext -p ../../Data/Socca.Players.Data/Socca.Players.Data.csproj -s Socca.Players.Api.csproj -o Migrations
```

PlayerTransfers
---------------
Migrations have already been created for you however to create migration (from the directory src/Microservices/PlayerTransfers/Api/Socca.PlayerTransfers.Api) and run the following command:
```powershell
dotnet ef migrations add InitialMigration --context playertransferdbcontext -p ../../Data/Socca.PlayerTransfers.Data/Socca.PlayerTransfers.Data.csproj -s Socca.PlayerTransfers.Api.csproj -o Migrations
```

Stadium
-------
Migrations have already been created for you however to create migration (from the directory src/Microservices/Stadium/Api/Socca.Stadium.Api) run the following command:
```powershell
dotnet ef migrations add InitialMigration --context stadiumdbcontext -p ../../Data/Socca.Stadium.Data/Socca.Stadium.Data.csproj -s Socca.Stadium.Api.csproj -o Migrations
```


# References
1. Introducing CQRS, The Microsoft Press Store by Pearson [https://www.microsoftpressstore.com/articles/article.aspx?p=2248809&seqNum=3]