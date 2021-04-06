#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/Microservices/FootballClub/Api/Socca.FootballClub.Api/Socca.FootballClub.Api.csproj", "src/Microservices/FootballClub/Api/Socca.FootballClub.Api/"]
COPY ["src/Microservices/FootballClub/Application/Socca.FootballClub.Application/Socca.FootballClub.Application.csproj", "src/Microservices/FootballClub/Application/Socca.FootballClub.Application/"]
COPY ["src/Microservices/FootballClub/Data/Socca.FootballClub.Data/Socca.FootballClub.Data.csproj", "src/Microservices/FootballClub/Data/Socca.FootballClub.Data/"]
COPY ["src/Microservices/FootballClub/Domain/Socca.FootballClub.Domain/Socca.FootballClub.Domain.csproj", "src/Microservices/FootballClub/Domain/Socca.FootballClub.Domain/"]
COPY ["src/Domain/Socca.Domain.Core/Socca.Domain.Core.csproj", "src/Domain/Socca.Domain.Core/"]
COPY ["src/Infrastructure/Socca.Infrastructure.IoC/Socca.Infrastructure.IoC.csproj", "src/Infrastructure/Socca.Infrastructure.IoC/"]
COPY ["src/Infrastructure/Socca.Infrastructure.Bus/Socca.Infrastructure.Bus.csproj", "src/Infrastructure/Socca.Infrastructure.Bus/"]
RUN dotnet restore "src/Microservices/FootballClub/Api/Socca.FootballClub.Api/Socca.FootballClub.Api.csproj"
COPY . .
WORKDIR "/src/src/Microservices/FootballClub/Api/Socca.FootballClub.Api"
RUN dotnet build "Socca.FootballClub.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Socca.FootballClub.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Socca.FootballClub.Api.dll"]
