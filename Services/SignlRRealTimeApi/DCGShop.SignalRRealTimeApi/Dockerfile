FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG TARGETARCH
WORKDIR /src
COPY ["Services/SignlRRealTimeApi/DCGShop.SignalRRealTimeApi/DCGShop.SignalRRealTimeApi.csproj", "Services/SignlRRealTimeApi/DCGShop.SignalRRealTimeApi/"]
RUN dotnet restore "Services/SignlRRealTimeApi/DCGShop.SignalRRealTimeApi/DCGShop.SignalRRealTimeApi.csproj"
COPY . .
WORKDIR "/src/Services/SignlRRealTimeApi/DCGShop.SignalRRealTimeApi"
RUN dotnet build "DCGShop.SignalRRealTimeApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DCGShop.SignalRRealTimeApi.csproj" -c Release -o /app/publish -a $TARGETARCH /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DCGShop.SignalRRealTimeApi.dll"]
