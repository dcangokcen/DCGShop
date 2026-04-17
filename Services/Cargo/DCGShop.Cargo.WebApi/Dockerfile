FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG TARGETARCH
WORKDIR /src
COPY ["Services/Cargo/DCGShop.Cargo.WebApi/DCGShop.Cargo.WebApi.csproj", "Services/Cargo/DCGShop.Cargo.WebApi/"]
COPY ["Services/Cargo/DCGShop.Cargo.BusinessLayer/DCGShop.Cargo.BusinessLayer.csproj", "Services/Cargo/DCGShop.Cargo.BusinessLayer/"]
COPY ["Services/Cargo/DCGShop.Cargo.DataAccessLayer/DCGShop.Cargo.DataAccessLayer.csproj", "Services/Cargo/DCGShop.Cargo.DataAccessLayer/"]
COPY ["Services/Cargo/DCGShop.Cargo.Dto.Layer/DCGShop.Cargo.Dto.Layer.csproj", "Services/Cargo/DCGShop.Cargo.Dto.Layer/"]
COPY ["Services/Cargo/DCGShop.Cargo.EntityLayer/DCGShop.Cargo.EntityLayer.csproj", "Services/Cargo/DCGShop.Cargo.EntityLayer/"]
RUN dotnet restore "Services/Cargo/DCGShop.Cargo.WebApi/DCGShop.Cargo.WebApi.csproj"
COPY . .
WORKDIR "/src/Services/Cargo/DCGShop.Cargo.WebApi"
RUN dotnet build "DCGShop.Cargo.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DCGShop.Cargo.WebApi.csproj" -c Release -o /app/publish -a $TARGETARCH /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DCGShop.Cargo.WebApi.dll"]
