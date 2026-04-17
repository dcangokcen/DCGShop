FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG TARGETARCH
WORKDIR /src
COPY ["Services/Catalog/DCGShop.Catalog/DCGShop.Catalog.csproj", "Services/Catalog/DCGShop.Catalog/"]
RUN dotnet restore "Services/Catalog/DCGShop.Catalog/DCGShop.Catalog.csproj"
COPY . .
WORKDIR "/src/Services/Catalog/DCGShop.Catalog"
RUN dotnet build "DCGShop.Catalog.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DCGShop.Catalog.csproj" -c Release -o /app/publish -a $TARGETARCH /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DCGShop.Catalog.dll"]
