FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG TARGETARCH
WORKDIR /src
COPY ["ApiGateway/DCGShop.OcelotGateway/DCGShop.OcelotGateway.csproj", "ApiGateway/DCGShop.OcelotGateway/"]
RUN dotnet restore "ApiGateway/DCGShop.OcelotGateway/DCGShop.OcelotGateway.csproj"
COPY . .
WORKDIR "/src/ApiGateway/DCGShop.OcelotGateway"
RUN dotnet build "DCGShop.OcelotGateway.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DCGShop.OcelotGateway.csproj" -c Release -o /app/publish -a $TARGETARCH /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DCGShop.OcelotGateway.dll"]
