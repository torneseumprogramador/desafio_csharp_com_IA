# Contexto de build: pasta "Ecommerce.Web" (pai de Ecommerce.Web e Ecommerce.Web.Client).
# Subir com o compose unificado:
#   cd deploy && docker compose up --build

FROM node:22-alpine AS tailwind
WORKDIR /src/Ecommerce.Web

COPY Ecommerce.Web/package.json Ecommerce.Web/package-lock.json ./
RUN npm ci

COPY Ecommerce.Web/tailwind.config.js ./
COPY Ecommerce.Web/wwwroot/css/tailwind.input.css ./wwwroot/css/
COPY Ecommerce.Web/Components/ ./Components/
COPY Ecommerce.Web.Client/ ../Ecommerce.Web.Client/

RUN npm run css:build

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY ["Ecommerce.Web/Ecommerce.Web.csproj", "Ecommerce.Web/"]
COPY ["Ecommerce.Web.Client/Ecommerce.Web.Client.csproj", "Ecommerce.Web.Client/"]

RUN dotnet restore "Ecommerce.Web/Ecommerce.Web.csproj"

COPY ["Ecommerce.Web/", "Ecommerce.Web/"]
COPY ["Ecommerce.Web.Client/", "Ecommerce.Web.Client/"]

COPY --from=tailwind /src/Ecommerce.Web/wwwroot/css/tailwind.css Ecommerce.Web/wwwroot/css/tailwind.css

WORKDIR /src/Ecommerce.Web
RUN dotnet publish "Ecommerce.Web.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app

ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "Ecommerce.Web.dll"]
