FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG TARGETARCH
WORKDIR /src
COPY ["Services/Basket/DCGShop.Basket/DCGShop.Basket.csproj", "Services/Basket/DCGShop.Basket/"]
RUN dotnet restore "Services/Basket/DCGShop.Basket/DCGShop.Basket.csproj"
COPY . .
WORKDIR "/src/Services/Basket/DCGShop.Basket"
RUN dotnet build "DCGShop.Basket.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DCGShop.Basket.csproj" -c Release -o /app/publish -a $TARGETARCH /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DCGShop.Basket.dll"]
