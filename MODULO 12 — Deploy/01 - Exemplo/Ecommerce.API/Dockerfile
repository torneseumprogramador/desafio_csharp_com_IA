# Contexto de build: pasta "01 - Exemplo" (pai deste projeto).
#   cd deploy && docker compose up --build

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY ["Ecommerce.API/Ecommerce.API.csproj", "Ecommerce.API/"]
COPY ["Ecommerce.Repositories/Ecommerce.Repositories.csproj", "Ecommerce.Repositories/"]
COPY ["Ecommerce.Services/Ecommerce.Services.csproj", "Ecommerce.Services/"]

RUN dotnet restore "Ecommerce.API/Ecommerce.API.csproj"

COPY ["Ecommerce.API/", "Ecommerce.API/"]
COPY ["Ecommerce.Repositories/", "Ecommerce.Repositories/"]
COPY ["Ecommerce.Services/", "Ecommerce.Services/"]

WORKDIR /src/Ecommerce.API
RUN dotnet publish "Ecommerce.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app

ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "Ecommerce.API.dll"]
