# metrics-example

## Запуск сервисов

```shell
docker-compose up -d
```

## Эндпойнты

- GET <http://localhost:8000/debug> - для отправки метрик
- GET <http://localhost:8000/swagger> - свагер

## Обнулить prometheus

```shell
docker-compose rm -sf prometheus && docker-compose up -d prometheus
```
