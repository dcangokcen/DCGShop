FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG TARGETARCH
WORKDIR /src
COPY ["Services/Payment/DCGShop.Payment/DCGShop.Payment.csproj", "Services/Payment/DCGShop.Payment/"]
RUN dotnet restore "Services/Payment/DCGShop.Payment/DCGShop.Payment.csproj"
COPY . .
WORKDIR "/src/Services/Payment/DCGShop.Payment"
RUN dotnet build "DCGShop.Payment.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DCGShop.Payment.csproj" -c Release -o /app/publish -a $TARGETARCH /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DCGShop.Payment.dll"]
