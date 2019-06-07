# Desafio DITO
> Requisitos
- [Docker](https://docs.docker.com/install/)
## Info
> Iniciando o projeto com `docker-compose`
```
docker-compose up -d
```

> `API`
  - Endpoint para persistir os `eventos`
    ```
      POST localhost:5000/Event/Insert
      {
         "eventName": "Comprou",
         "timestamp": "2016-09-22T13:57:31.2311892-04:00"
      }

      POST localhost:5000/Event/InsertList
      {
         "eventName": "Comprou",
         "timestamp": "2016-09-22T13:57:31.2311892-04:00"
      },
      {
         "eventName": "Comprou",
         "timestamp": "2016-09-22T13:57:31.2311892-04:00"
      },
      .....
    ```
  - Endpoint para serviço de `autocomplete`
    ```
      GET localhost:5000/Event?search=comp
      {
         "eventName": "Comprou",
         "timestamp": "2016-09-22T13:57:31.2311892-04:00"
      }
    ```
  - Endpoint para gerar `Timeline`
    ```
      GET localhost:5000/TimeLine

    ```

## Tecnologia utilizada
> Docker

> .net core 2.2

> mongoDB