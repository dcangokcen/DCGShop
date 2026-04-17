FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG TARGETARCH
WORKDIR /src
COPY ["Services/Comment/DCGShop.Comment/DCGShop.Comment.csproj", "Services/Comment/DCGShop.Comment/"]
RUN dotnet restore "Services/Comment/DCGShop.Comment/DCGShop.Comment.csproj"
COPY . .
WORKDIR "/src/Services/Comment/DCGShop.Comment"
RUN dotnet build "DCGShop.Comment.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DCGShop.Comment.csproj" -c Release -o /app/publish -a $TARGETARCH /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DCGShop.Comment.dll"]
