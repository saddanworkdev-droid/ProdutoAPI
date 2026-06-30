# 🚀 ProdutoAPI

API REST desenvolvida em **ASP.NET Core 8** utilizando **Entity Framework Core**, autenticação **JWT**, arquitetura em camadas e banco de dados **MySQL**.

O projeto é totalmente **containerizado com Docker e Docker Compose**, permitindo executar toda a aplicação com apenas alguns comandos.

---

# 📌 Tecnologias

- ASP.NET Core 8
- Entity Framework Core
- MySQL 8
- JWT Authentication
- Swagger (OpenAPI)
- Docker
- Docker Compose
- LINQ
- Git
- GitHub

---

# ✅ Funcionalidades

- CRUD de Produtos
- CRUD de Categorias
- Paginação
- Filtro por Nome
- Ordenação
- Login JWT
- Autenticação via Bearer Token
- Arquitetura em Camadas
- Migrations automáticas
- Seed automático do usuário administrador

---

# 🏗️ Arquitetura

```text
                Docker Compose
                       │
        ┌──────────────┴──────────────┐
        │                             │
        ▼                             ▼
 ProdutoAPI (.NET 8)             MySQL 8
        │
        ▼
 Swagger + JWT
```

---

# 📁 Estrutura do Projeto

```text
ProdutoAPI
│
├── Controllers
├── Data
├── DTOs
├── Interfaces
├── Migrations
├── Models
├── Services
├── Properties
├── Dockerfile
├── docker-compose.yml
├── Program.cs
└── appsettings.json
```

---

# ▶️ Executando Localmente

Clone o repositório:

```bash
git clone https://github.com/saddanworkdev-droid/ProdutoAPI.git
```

Entre na pasta do projeto:

```bash
cd ProdutoAPI
```

Restaure os pacotes:

```bash
dotnet restore
```

Crie o banco de dados:

```bash
dotnet ef database update
```

Execute a aplicação:

```bash
dotnet run
```

Swagger:

```
https://localhost:7186/swagger
```

---

# 🐳 Executando com Docker

Clone o projeto:

```bash
git clone https://github.com/saddanworkdev-droid/ProdutoAPI.git
```

Entre na pasta:

```bash
cd ProdutoAPI
```

Suba os containers:

```bash
docker compose up --build
```

Swagger:

```
http://localhost:8080/swagger
```

---

# 🔑 Usuário padrão

Após a primeira execução, o projeto cria automaticamente um usuário administrador.

**Login**

```
admin
```

**Senha**

```
123456
```

Utilize esse usuário no endpoint:

```
POST /api/Auth/Login
```

Depois copie o JWT retornado e clique em:

```
Authorize
```

no Swagger para acessar os endpoints protegidos.

---

# ⭐ Diferenciais

- API totalmente containerizada
- Banco MySQL executando em container Docker
- Docker Compose para orquestração
- Aplicação automática das Migrations
- Seed automático do usuário administrador
- JWT integrado ao Swagger
- Arquitetura organizada utilizando Services, DTOs e Interfaces

---

# 📚 Conceitos Utilizados

- ASP.NET Core
- Entity Framework Core
- LINQ
- DTO (Data Transfer Object)
- Service Layer
- Repository Pattern (parcial)
- Dependency Injection
- JWT Authentication
- Paginação
- Ordenação
- Filtros
- Docker
- Docker Compose

---

# 👨‍💻 Autor

**Saddan Nazik Soares Kalil**

📧 Email

saddanwork.dev@gmail.com

💼 LinkedIn

https://www.linkedin.com/in/saddan-nazik-soares-kalil-8a44a1418

💻 GitHub

https://github.com/saddanworkdev-droid