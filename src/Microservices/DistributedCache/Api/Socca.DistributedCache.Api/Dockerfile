#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Microservices/DistributedCache/Api/Socca.DistributedCache.Api/Socca.DistributedCache.Api.csproj", "src/Microservices/DistributedCache/Api/Socca.DistributedCache.Api/"]
COPY ["src/Infrastructure/Socca.Infrastructure.IoC/Socca.Infrastructure.IoC.csproj", "src/Infrastructure/Socca.Infrastructure.IoC/"]
COPY ["src/Infrastructure/Socca.Infrastructure.Bus/Socca.Infrastructure.Bus.csproj", "src/Infrastructure/Socca.Infrastructure.Bus/"]
COPY ["src/Domain/Socca.Domain.Core/Socca.Domain.Core.csproj", "src/Domain/Socca.Domain.Core/"]
COPY ["src/Microservices/DistributedCache/Data/Socca.DistributedCache.Data/Socca.DistributedCache.Data.csproj", "src/Microservices/DistributedCache/Data/Socca.DistributedCache.Data/"]
COPY ["src/Microservices/DistributedCache/Domain/Socca.DistributedCache.Domain/Socca.DistributedCache.Domain.csproj", "src/Microservices/DistributedCache/Domain/Socca.DistributedCache.Domain/"]
RUN dotnet restore "src/Microservices/DistributedCache/Api/Socca.DistributedCache.Api/Socca.DistributedCache.Api.csproj"
COPY . .
WORKDIR "/src/src/Microservices/DistributedCache/Api/Socca.DistributedCache.Api"
RUN dotnet build "Socca.DistributedCache.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Socca.DistributedCache.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Socca.DistributedCache.Api.dll"]
