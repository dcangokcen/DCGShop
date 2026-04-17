FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG TARGETARCH
WORKDIR /src
COPY ["Discount/DCGShop.Discount/DCGShop.Discount.csproj", "Discount/DCGShop.Discount/"]
RUN dotnet restore "Discount/DCGShop.Discount/DCGShop.Discount.csproj"
COPY . .
WORKDIR "/src/Discount/DCGShop.Discount"
RUN dotnet build "DCGShop.Discount.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DCGShop.Discount.csproj" -c Release -o /app/publish -a $TARGETARCH /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DCGShop.Discount.dll"]
