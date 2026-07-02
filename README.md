# CadastroProdutos

API RESTful em ASP.NET Core 10 para cadastro de produtos com autenticação JWT e persistência em SQLite.

## 🔧 Visão geral

- Projeto: `CadastroProdutos`
- Plataforma: .NET 10
- Autenticação: JWT
- Persistência: SQLite (`Produtos.db`) ⚠️ database original não inclusa.
- API documentada com Swagger em ambiente de desenvolvimento
- Serviços:
  - `ProdutosController` com autenticação e autorização
  - `LoginController` para emissão do token JWT
  - `ProdutosDatabaseService` para acessar o banco via Entity Framework Core

## 🚀 Requisitos

- .NET 10 SDK
- `dotnet ef` disponível (já incluso via `Microsoft.EntityFrameworkCore.Tools`)
- Visual Studio / VS Code / terminal

## ⚙️ Configuração

1. Abra o terminal na pasta do projeto:
   ```bash
   cd "CadastroProdutos"
   ```

2. Defina a chave JWT:
   ```bash
   dotnet user-secrets set "Jwt:Key" "SUA_CHAVE_AQUI"
   ```

3. Restaure os pacotes:
   ```bash
   dotnet restore
   ```

4. Atualize o banco de dados (o SQLite será criado automaticamente):
   ```bash
   dotnet ef database update
   ```

## ▶️ Executar

```bash
dotnet run
```

ou

```bash
dotnet run --project CadastroProdutos.csproj
```

---

## 📖 Documentação da API

Após rodar a aplicação, a documentação interativa da API estará disponível em:

> **[https://localhost:7xxx/swagger/index.html](https://localhost:7xxx/swagger/index.html)**

*(Substitua `7xxx` pela porta gerada pelo seu servidor no terminal ao executar o `dotnet run`)*

⚠️ Nota de Autenticação: Para testar os endpoints protegidos, clique no botão Authorize no topo da página do Swagger e insira o seu token no formato: Bearer {seu_token}.

## 📌 Endpoints principais

### Autenticação

`POST /api/login`

Corpo JSON:
```json
{
  "usuario": "admin",
  "senha": "admin"
}
```

Usuários suportados:
- `admin` / `admin`
- `cliente` / `cliente`

Retorna:
```json
{
  "Token": "..."
}
```

### Produtos protegidos (JWT)

`GET /api/produtos`  
`GET /api/produtos/{id}`

`POST /api/produtos`  
`PUT /api/produtos/{id}`  
`DELETE /api/produtos/{id}`

- `POST`, `PUT` e `DELETE` exigem role `admin`
- `GET` exige apenas token válido

### Produtos públicos (endpoints mínimos em Program.cs)

`GET /produtos`  
`GET /produtos/{id}`  
`POST /produtos`  
`PUT /produtos/{id}`  
`DELETE /produtos/{id}`

> Esses endpoints são definidos diretamente em Program.cs e não usam autenticação.

---

## 🧾 Modelo de produto

```json
{
  "id": 1,
  "nome": "Mouse sem fio",
  "preco": 99.90,
  "estoque": 50
}
```

Validações:
- `nome`: obrigatório, até 100 caracteres
- `preco`: maior que zero
- `estoque`: entre 0 e 1000

---

## 🗂️ Arquivos importantes

- Program.cs
- LoginController.cs
- ProdutosController.cs
- IProdutosService.cs
- ProdutosDatabaseService.cs
- ApplicationDbContext.cs
- appsettings.json

---

## 💡 Observações

- A chave JWT é carregada via `dotnet user-secrets` em Program.cs
- A API usa `Swashbuckle.AspNetCore` para Swagger em desenvolvimento
- Se quiser usar somente o banco, `ProdutosController` já está configurado para `ProdutosDatabaseService`