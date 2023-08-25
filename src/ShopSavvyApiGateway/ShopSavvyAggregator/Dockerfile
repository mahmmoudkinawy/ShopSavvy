FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["ShopSavvyApiGateway/ShopSavvyAggregator/ShopSavvyAggregator.csproj", "ShopSavvyApiGateway/ShopSavvyAggregator/"]
RUN dotnet restore "ShopSavvyApiGateway/ShopSavvyAggregator/ShopSavvyAggregator.csproj"
COPY . .
WORKDIR "/src/ShopSavvyApiGateway/ShopSavvyAggregator"
RUN dotnet build "ShopSavvyAggregator.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ShopSavvyAggregator.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ShopSavvyAggregator.dll"]