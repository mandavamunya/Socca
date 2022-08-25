#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Presentation/UI/Socca.UI.Web/Socca.UI.Web.csproj", "src/Presentation/UI/Socca.UI.Web/"]
COPY ["src/Presentation/UI/Socca.UI.Providers/Socca.UI.Providers.csproj", "src/Presentation/UI/Socca.UI.Providers/"]
RUN dotnet restore "src/Presentation/UI/Socca.UI.Web/Socca.UI.Web.csproj"
COPY . .
WORKDIR "/src/src/Presentation/UI/Socca.UI.Web"
RUN dotnet build "Socca.UI.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Socca.UI.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Socca.UI.Web.dll"]
