# Vedere https://aka.ms/customizecontainer per informazioni su come personalizzare il contenitore di debug
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# Fase di compilazione
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copia SOLO i .csproj di ogni progetto coinvolto, per sfruttare la cache dei layer Docker
# (se non cambiano i .csproj, Docker non rifà il restore ad ogni build)
COPY ["eCommerce.ProductService.API/eCommerce.ProductService.API.csproj", "eCommerce.ProductService.API/"]
COPY ["eCommerce.ProductService.BusinessLogicLayer/eCommerce.ProductService.BusinessLogicLayer.csproj", "eCommerce.ProductService.BusinessLogicLayer/"]
COPY ["eCommerce.ProductService.DataAccessLayer/eCommerce.ProductService.DataAccessLayer.csproj", "eCommerce.ProductService.DataAccessLayer/"]

RUN dotnet restore "eCommerce.ProductService.API/eCommerce.ProductService.API.csproj"

# Ora copia tutto il resto del codice sorgente
COPY . .
WORKDIR "/src/eCommerce.ProductService.API"
RUN dotnet build "eCommerce.ProductService.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Fase di pubblicazione
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "eCommerce.ProductService.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Fase finale
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV MYSQL_HOST=localhost
ENV MYSQL_PASSWORD=admin
ENTRYPOINT ["dotnet", "eCommerce.ProductService.API.dll"]