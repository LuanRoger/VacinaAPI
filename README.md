# VacinaAPI

## Tecnológias e Ferramentas

- .NET 8 (C# 12)
- SQLite
- Entity Framework Core
- Swagger
- Docker
- AutoMapper
- FluentValidation

## Como executar

1. Clone o repositório

2. Na raiz do projeto `VacinaAPI.csproj` ([./VacinaAPI](https://github.com/LuanRoger/VacinaAPI/tree/main/VacinaAPI)), execute:

```bash
dotnet run
```

A API vai executar em `localhost:5205`.
Pronto.

### Observações

- Você pode acessar a documentação da API em [`http://localhost:5205/swagger`](http://localhost:5205/swagger/).
- O banco de dados SQLite é criado automaticamente ao executar a aplicação.
- O banco de dados é persistido no arquivo `sqlite.db` na raiz do projeto.
- O banco já vem populado com alguns dados de exemplo.

## Endpoints

Os endpoints estão disponíveis na [documentação da API (Swagger)](http://localhost:5205/swagger/).

Todos os endpoints também esta exemplificados no arquivo [`VacinaAPI.http`](https://github.com/LuanRoger/VacinaAPI/blob/main/VacinaAPI/VacinaAPI.http)

### Postman

[![Postman](https://img.shields.io/badge/Postman-FF6C37?style=for-the-badge&logo=postman&logoColor=white)](https://github.com/LuanRoger/VacinaAPI/blob/main/VacinasAPI.postman_collection.json)

Você pode importar a collection do Postman disponível em [`VacinaAPI.postman_collection.json`](https://github.com/LuanRoger/VacinaAPI/blob/main/VacinasAPI.postman_collection.json).
