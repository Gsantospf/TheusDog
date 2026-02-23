# 🐶 TheusDog Hotel API

API RESTful para gerenciamento de hotel para cães, desenvolvida com .NET 10 seguindo os princípios de Clean Architecture, Repository Pattern e Domain-Driven Design (DDD).

## 🏗️ Arquitetura

O projeto é dividido em 4 camadas independentes:
```
TheusDog/
  TheusDog.Core/           → Entidades, Enums e Interfaces (domínio puro)
  TheusDog.Infrastructure/ → Repositórios, EF Core e banco de dados
  TheusDog.Application/    → Services, DTOs e regras de negócio
  TheusDog.Api/            → Controllers, endpoints HTTP e configuração
```

## 🚀 Tecnologias

- .NET 10
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- Swagger / OpenAPI

## ▶️ Como rodar

### Pré-requisitos
- .NET 10 SDK
- SQL Server

### Passo a passo

1. Clone o repositório
```bash
   git clone https://github.com/SEU_USUARIO/TheusDog.git
   cd TheusDog
```

2. Configure a connection string no `appsettings.json`
```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=localhost;Database=TheusDogHotel;Trusted_Connection=True;TrustServerCertificate=True"
   }
```

3. Execute as migrations
```bash
   dotnet ef database update --project TheusDog.Infrastructure --startup-project TheusDog.Api
```

4. Rode a API
```bash
   dotnet run --project TheusDog.Api
```

5. Acesse o Swagger
```
   http://localhost:5046/swagger
```

## 📋 Fluxo de uso

Para testar a API, siga a ordem abaixo — cada passo depende do anterior:

| Passo | Endpoint | Descrição |
|-------|----------|-----------|
| 1 | `POST /api/room` | Criar um quarto |
| 2 | `POST /api/tutor` | Criar um tutor |
| 3 | `POST /api/dog` | Criar um cachorro (requer tutorId) |
| 4 | `POST /api/booking` | Criar uma reserva (requer dogId e roomId) |
| 5 | `PATCH /api/booking/{id}/confirm` | Confirmar a reserva |

## 📁 Padrões aplicados

- **Clean Architecture** — separação de responsabilidades em camadas
- **Repository Pattern** — abstração do acesso a dados
- **Rich Domain Model** — entidades com regras de negócio encapsuladas
- **Soft Delete** — registros nunca são removidos fisicamente
- **DTOs** — entidades nunca expostas diretamente na API
- **Dependency Injection** — inversão de dependência em todas as camadas
