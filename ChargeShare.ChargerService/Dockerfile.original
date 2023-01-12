#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["ChargeShare.ChargerService/ChargeShare.ChargerService.csproj", "ChargeShare.ChargerService/"]
RUN dotnet restore "ChargeShare.ChargerService/ChargeShare.ChargerService.csproj"
COPY . .
WORKDIR "/src/ChargeShare.ChargerService"
RUN dotnet build "ChargeShare.ChargerService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ChargeShare.ChargerService.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ChargeShare.ChargerService.dll"]