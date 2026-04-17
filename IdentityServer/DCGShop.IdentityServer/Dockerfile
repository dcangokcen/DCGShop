FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG TARGETARCH
WORKDIR /src
COPY ["IdentityServer/DCGShop.IdentityServer/DCGShop.IdentityServer.csproj", "IdentityServer/DCGShop.IdentityServer/"]
RUN dotnet restore "IdentityServer/DCGShop.IdentityServer/DCGShop.IdentityServer.csproj"
COPY . .
WORKDIR "/src/IdentityServer/DCGShop.IdentityServer"
RUN dotnet build "DCGShop.IdentityServer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DCGShop.IdentityServer.csproj" -c Release -o /app/publish -a $TARGETARCH /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DCGShop.IdentityServer.dll"]
