#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Microservices/FootballClubStadium/Api/Socca.FootballClubStadium.Api/Socca.FootballClubStadium.Api.csproj", "src/Microservices/FootballClubStadium/Api/Socca.FootballClubStadium.Api/"]
COPY ["src/Infrastructure/Socca.Infrastructure.IoC/Socca.Infrastructure.IoC.csproj", "src/Infrastructure/Socca.Infrastructure.IoC/"]
COPY ["src/Infrastructure/Socca.Infrastructure.Bus/Socca.Infrastructure.Bus.csproj", "src/Infrastructure/Socca.Infrastructure.Bus/"]
COPY ["src/Domain/Socca.Domain.Core/Socca.Domain.Core.csproj", "src/Domain/Socca.Domain.Core/"]
COPY ["src/Microservices/FootballClubStadium/Data/Socca.FootballClubStadium.Data/Socca.FootballClubStadium.Data.csproj", "src/Microservices/FootballClubStadium/Data/Socca.FootballClubStadium.Data/"]
COPY ["src/Microservices/FootballClubStadium/Domain/Socca.FootballClubStadium.Domain/Socca.FootballClubStadium.Domain.csproj", "src/Microservices/FootballClubStadium/Domain/Socca.FootballClubStadium.Domain/"]
RUN dotnet restore "src/Microservices/FootballClubStadium/Api/Socca.FootballClubStadium.Api/Socca.FootballClubStadium.Api.csproj"
COPY . .
WORKDIR "/src/src/Microservices/FootballClubStadium/Api/Socca.FootballClubStadium.Api"
RUN dotnet build "Socca.FootballClubStadium.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Socca.FootballClubStadium.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Socca.FootballClubStadium.Api.dll"]
