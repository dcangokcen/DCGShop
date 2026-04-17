FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG TARGETARCH
WORKDIR /src
COPY ["Frontends/DCGShop.WebUI/DCGShop.WebUI.csproj", "Frontends/DCGShop.WebUI/"]
COPY ["Frontends/DCGShop.DtoLayer/DCGShop.DtoLayer.csproj", "Frontends/DCGShop.DtoLayer/"]
RUN dotnet restore "Frontends/DCGShop.WebUI/DCGShop.WebUI.csproj"
COPY . .
WORKDIR "/src/Frontends/DCGShop.WebUI"
RUN dotnet build "DCGShop.WebUI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DCGShop.WebUI.csproj" -c Release -o /app/publish -a $TARGETARCH /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DCGShop.WebUI.dll"]
