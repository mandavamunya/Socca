#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Microservices/PlayerTransfers/Api/Socca.PlayerTransfers.Api/Socca.PlayerTransfers.Api.csproj", "src/Microservices/PlayerTransfers/Api/Socca.PlayerTransfers.Api/"]
COPY ["src/Infrastructure/Socca.Infrastructure/Socca.Infrastructure.csproj", "src/Infrastructure/Socca.Infrastructure/"]
COPY ["src/Domain/Socca.Domain.Core/Socca.Domain.Core.csproj", "src/Domain/Socca.Domain.Core/"]
COPY ["src/Microservices/PlayerTransfers/Data/Socca.PlayerTransfers.Data/Socca.PlayerTransfers.Data.csproj", "src/Microservices/PlayerTransfers/Data/Socca.PlayerTransfers.Data/"]
COPY ["src/Microservices/PlayerTransfers/Domain/Socca.PlayerTransfers.Domain/Socca.PlayerTransfers.Domain.csproj", "src/Microservices/PlayerTransfers/Domain/Socca.PlayerTransfers.Domain/"]
RUN dotnet restore "src/Microservices/PlayerTransfers/Api/Socca.PlayerTransfers.Api/Socca.PlayerTransfers.Api.csproj"
COPY . .
WORKDIR "/src/src/Microservices/PlayerTransfers/Api/Socca.PlayerTransfers.Api"
RUN dotnet build "Socca.PlayerTransfers.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Socca.PlayerTransfers.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Socca.PlayerTransfers.Api.dll"]
