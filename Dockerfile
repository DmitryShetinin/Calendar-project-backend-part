# Базовый образ для .NET 9.0
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# 1. Копируем ВСЕ .csproj файлы
COPY ["backEnd/backEnd.csproj", "backEnd/"]
COPY ["src/BackEnd.Application/BackEnd.Application.csproj", "src/BackEnd.Application/"]
COPY ["src/BackEnd.Infrastructure/BackEnd.Infrastructure.csproj", "src/BackEnd.Infrastructure/"]
COPY ["src/BackEnd.Persistence/BackEnd.Persistence.csproj", "src/BackEnd.Persistence/"]

# 2. Восстанавливаем зависимости
RUN dotnet restore "backEnd/backEnd.csproj"

# 3. Копируем исходный код
COPY . .

# 4. Собираем и публикуем
WORKDIR "/src/backEnd"
RUN dotnet publish -c Release -o /app/publish

# Финальный образ
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "backEnd.dll"]