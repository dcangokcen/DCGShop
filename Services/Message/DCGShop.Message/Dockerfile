FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG TARGETARCH
WORKDIR /src
COPY ["Services/Message/DCGShop.Message/DCGShop.Message.csproj", "Services/Message/DCGShop.Message/"]
RUN dotnet restore "Services/Message/DCGShop.Message/DCGShop.Message.csproj"
COPY . .
WORKDIR "/src/Services/Message/DCGShop.Message"
RUN dotnet build "DCGShop.Message.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DCGShop.Message.csproj" -c Release -o /app/publish -a $TARGETARCH /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DCGShop.Message.dll"]
