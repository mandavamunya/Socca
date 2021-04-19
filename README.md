<!--# N.B. DOCUMENTATION/README IS OUTDATED AND NEEDS TO BE UPDATED -->

# Technology used

.Net Core 5, RabbitMq, MsSQL, MediatR, Swagger, Docker, Kurbernetes, Azure AKS, Azure SQL Server, Redis Cache, React

# Topics cover

Microservices architecture, event driven architecture, CQRS, event sourcing, clean architecture, unit tests 


# Assumptions

- The football clubs do not have a permanent home stadiums and can be reassigned to a new stadium before the beginning of each season.
- Multiple events will be generated and possibly the event processors / consumers might take long to process hence why the use of an event bus.

## Requirements

- An Event is generated when a football player is transfered between teams. 
- An Event is generated when linking a football team to a stadium.

# In progress

- Update documentation (On going)
- Distributed Caching with Redis Cache (95% complete)
- Dockerize the application (95% complete)
- Add Kubernetes support (just started)
- Add React frontend application (just started)

# What's next
- Add a security microservice
- Add centralized logging and health checks
- Make use of Azure SQL Server
- Deploy to Azure AKS
- Add more unit tests
- Add functional tests and integration tests


# Redis Cache and Kubernetes

## Define Redis Cache
?

## Define Kubernetes
?

## Considerations should be made when load balancing a web app
The way states are managed in a web application (session persistence) has an impact  on the load balancing configuration and scalability.

Non sticky persistence: in the case that the session state is saved in a distributed cache or database (e.g. Redis Cache). The load balancer can route requests to any web server that has access to that distributed cache. 

Sticky persistence: in the case that the session state is saved in an in-memory cache which is an in-process memory state in the web server. The load balancer must route the requests or traffic from the client to a specific web server that saved its session state.


## Event Sourcing

A distributed cache service was added to keep track of each application client's state. Only the current state of the client is saved in redis cache. 

### Entity Relationship Diagram (ERD) for the application states that will be saved in the distributed Redis cache.
![](https://github.com/mandavamunya/Socca/blob/main/image/entity_relational_diagram.png)

As an example we are only going to save the state of the FootballClubStadium and PlayerTransfer entities i.e. LinkToStadiumCreatedEvent and PlayerTransferCreatedEvent respectively.
In real life scenarios the Stadium, Player, FootballClub entities are actually look up data and do not get changed that often.

## Outstanding work

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

# Dockerizing

### How to Run

- Simply click the run button in Visual Studio 2019. Please see button encircled in an orange oval in the image below.

![](https://github.com/mandavamunya/Socca/blob/main/image/run_docker_containers.png)

### Dockerized microservices

![](https://github.com/mandavamunya/Socca/blob/main/image/dockerized_socca.png)

### Accessing dockerized APIs

![](https://github.com/mandavamunya/Socca/blob/main/image/accessing_containerized_app.png)

### Accessing all your microservices in the browser

FootballClub: https://localhost:44301/swagger/index.html

Players: https://localhost:44328/swagger/index.html

FootballClubStadium: https://localhost:44350/swagger/index.html

PlayerTransfers: https://localhost:44370/swagger/index.html

Stadium: https://localhost:44309/swagger/index.html

Distributed Cache: https://localhost:44305/swagger/index.html



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



## Important RabbitMq Commands

rabbitmqctl stop_app

rabbitmqctl start_app

rabbitmqctl reset

rabbitmqctl add_user test test

rabbitmqctl set_user_tags test administrator

rabbitmqctl set_permissions -p / test ".*" ".*" ".*"

## Important docker commands

List all images:
```powershell
docker images
```

List all containers:
```powershell
docker ps
```

Delete every Docker containers:
```powershell
docker-compose down 
```

Remove all docker containers:

```powershell
docker rm -f $(docker ps -a -q)
```

Delete a docker container with CONTAINER ID 10e62ea29d83:

```powershell
docker rm –f 10e62ea29d83
```

Delete all docker images:
```powershell
docker rmi -f $(docker images -q)
```

Delete a docker image with IMAGE ID 870fda08c907:
```powershell
docker rmi –f 870fda08c907
```

Build your application:
```powershell
docker-compose build
```

```powershell
Run your application: docker-compose up
```

You migh be prompted to create a network. Create a network by running the following command:

```powershell
docker network create soccanet
```

## important dotnet cli commands
To use secretes run the following command in the project directory

```powershell
dotnet user-secrets init
```

# Optional (setting up development environment)

### Rabbit Mq docker image for testing on my local MAC

```powershell
docker pull rabbitmq
```

```powershell
docker run --name rediscache -p 5090:6379 -d redis
```

```powershell
docker start rediscache
```

```powershell
docker exec -it rediscache redis-cli
```

## MSSQL DB docker image for testing on my local MAC

Pull MSSQL docker image:
```powershell
sudo docker pull mcr.microsoft.com/mssql/server:2019-latest
```
Run MSSQL docker image:
```powershell
sudo docker run -d --name Mssqldb -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=Password2021' -p 1433:1433 mcr.microsoft.com/mssql/server:2019-latest
```

<!--
Execute MSSQL docker image:
```powershell
sudo docker exec -it Mssqldb "bash"/opt/mssql-tools/bin/sqlcmd -S localhost -U SA -P "Password2021"
```

Run a quick test:
```powershell
SELECT @@versionGO
```
-->


# References
1. Introducing CQRS, The Microsoft Press Store by Pearson [https://www.microsoftpressstore.com/articles/article.aspx?p=2248809&seqNum=3]
2. [https://docs.microsoft.com/en-us/sql/linux/sql-server-linux-docker-container-deployment?view=sql-server-ver15&pivots=cs1-bash]
3. [https://www.nginx.com/resources/glossary/load-balancing/]
