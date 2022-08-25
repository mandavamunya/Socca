#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Microservices/Players/Api/Socca.Players.Api/Socca.Players.Api.csproj", "src/Microservices/Players/Api/Socca.Players.Api/"]
COPY ["src/Infrastructure/Socca.Infrastructure.IoC/Socca.Infrastructure.IoC.csproj", "src/Infrastructure/Socca.Infrastructure.IoC/"]
COPY ["src/Infrastructure/Socca.Infrastructure.Bus/Socca.Infrastructure.Bus.csproj", "src/Infrastructure/Socca.Infrastructure.Bus/"]
COPY ["src/Domain/Socca.Domain.Core/Socca.Domain.Core.csproj", "src/Domain/Socca.Domain.Core/"]
COPY ["src/Microservices/Players/Data/Socca.Players.Data/Socca.Players.Data.csproj", "src/Microservices/Players/Data/Socca.Players.Data/"]
COPY ["src/Microservices/Players/Domain/Socca.Players.Domain/Socca.Players.Domain.csproj", "src/Microservices/Players/Domain/Socca.Players.Domain/"]
RUN dotnet restore "src/Microservices/Players/Api/Socca.Players.Api/Socca.Players.Api.csproj"
COPY . .
WORKDIR "/src/src/Microservices/Players/Api/Socca.Players.Api"
RUN dotnet build "Socca.Players.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Socca.Players.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Socca.Players.Api.dll"]
