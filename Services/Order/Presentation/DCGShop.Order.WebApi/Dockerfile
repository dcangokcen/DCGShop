FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG TARGETARCH
WORKDIR /src
COPY ["Services/Order/Presentation/DCGShop.Order.WebApi/DCGShop.Order.WebApi.csproj", "Services/Order/Presentation/DCGShop.Order.WebApi/"]
COPY ["Services/Order/Core/DCGShop.Order.Application/DCGShop.Order.Application.csproj", "Services/Order/Core/DCGShop.Order.Application/"]
COPY ["Services/Order/Core/DCGShop.Order.Domain/DCGShop.Order.Domain.csproj", "Services/Order/Core/DCGShop.Order.Domain/"]
COPY ["Services/Order/Core/DCGShop.Order.Persistence/DCGShop.Order.Persistence.csproj", "Services/Order/Core/DCGShop.Order.Persistence/"]
RUN dotnet restore "Services/Order/Presentation/DCGShop.Order.WebApi/DCGShop.Order.WebApi.csproj"
COPY . .
WORKDIR "/src/Services/Order/Presentation/DCGShop.Order.WebApi"
RUN dotnet build "DCGShop.Order.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DCGShop.Order.WebApi.csproj" -c Release -o /app/publish -a $TARGETARCH /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DCGShop.Order.WebApi.dll"]
