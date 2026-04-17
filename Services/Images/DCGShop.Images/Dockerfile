FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG TARGETARCH
WORKDIR /src
COPY ["Services/Images/DCGShop.Images/DCGShop.Images.csproj", "Services/Images/DCGShop.Images/"]
RUN dotnet restore "Services/Images/DCGShop.Images/DCGShop.Images.csproj"
COPY . .
WORKDIR "/src/Services/Images/DCGShop.Images"
RUN dotnet build "DCGShop.Images.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DCGShop.Images.csproj" -c Release -o /app/publish -a $TARGETARCH /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DCGShop.Images.dll"]
