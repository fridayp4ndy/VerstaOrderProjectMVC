# Versta Order Project

Тестовое задание на ASP.NET Core MVC (.NET 9).

## Требования

* Docker Desktop

## Запуск через Docker

Клонировать репозиторий:

```bash
git clone https://github.com/fridayp4ndy/VerstaOrderProjectMVC.git
cd VerstaOrderProjectMVC
```

Собрать образ:

```bash
docker build -t versta-order .
```

Запустить контейнер:

```bash
docker run -p 5001:5001 -v sqlite-data:/app/DataBaseSqlite versta-order
```

После запуска приложение будет доступно по адресу:

```
http://localhost:5001
```

## Альтернативный запуск без Docker

Требования:

* .NET SDK 9.0

Клонировать репозиторий:

```bash
git clone https://github.com/fridayp4ndy/VerstaOrderProjectMVC.git
cd VerstaOrderProjectMVC
```

Запустить приложение:

```bash
dotnet run
```

После запуска приложение будет доступно по адресу, указанному в консоли ASP.NET Core.

```
Now listening on: http://localhost:5001
```
