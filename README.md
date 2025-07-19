### Отладка
#### Настройка окружения для разработки
##### Конфигурация API:
1. Открыть/создать файл `MajorExpress.Delivery/MajorExpress.Delivery.Api/appsettings.Development.json`
2. Настроить строку подключения к БД:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Port=5432;Database=MajorExpress;Username=postgres;Password=postgres;"
  }
}
```
##### Конфигурация клиента:
1. В файле инициализации клиента настроить базовый URL:
```csharp
services.AddDeliveryClient(config => 
{
    config.BaseUrl = "http://localhost:8080"; // Адрес API сервера
});
```
### Развертывание в Docker

#### Очистка старых контейнеров:
```shell
docker-compose down -v
```
#### Сборка и запуск контейнеров:
```shell
docker-compose up -d
```
#### Проверка состояния контейнеров:
```shell
docker-compose ps
```
#### Просмотр логов:
```shell
docker-compose logs -f
```

#### Доступ к приложению
После успешного запуска:
- API будет доступно по адресу: `http://localhost:8080`
- PostgreSQL будет доступна на порту: `5432`
- Swagger UI: `http://localhost:8080/swagger`

### Создание миграций
#### Добавление новой миграции:
```shell
dotnet ef migrations add <ИмяМиграции> \
  --project ./MajorExpress.Delivery.Infrastructure \
  --startup-project ./MajorExpress.Delivery.Api \
  --context ApplicationDbContext \
  --output-dir Adapters/<БазаДанных>/Migrations
```
#### Пример для начальной миграции:
```shell
dotnet ef migrations add InitialCreate \
  --project ./MajorExpress.Delivery.Infrastructure \
  --startup-project ./MajorExpress.Delivery.Api \
  --context ApplicationDbContext \
  --output-dir Adapters/Postgres/Migrations
```
#### Применение миграций:
```shell
dotnet ef database update \
  --project ./MajorExpress.Delivery.Infrastructure \
  --startup-project ./MajorExpress.Delivery.Api \
  --context ApplicationDbContext
```