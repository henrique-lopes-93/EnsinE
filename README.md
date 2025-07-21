
# EnsinE.CRM

Sistema web simples desenvolvido em **ASP.NET Core MVC** com **SQL Server**, como parte de um desafio técnico para a vaga de Analista Full Stack Júnior.

O sistema permite o cadastro e gerenciamento de clientes associados a produtos. Os dados podem ser analisados posteriormente no Power BI.

## 🚀 Tecnologias Utilizadas

- ASP.NET Core MVC (.NET 8)
- Entity Framework Core (Code First)
- SQL Server
- Razor Views + Bootstrap
- Power BI


# 🛠️ Como Rodar Localmente

## 1. **Pré-requisitos**

- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- [SQL Server](https://www.microsoft.com/pt-br/sql-server/sql-server-downloads)
- Visual Studio 2022 (recomendado) ou VS Code com extensão C# (C# Dev Kit)


## 2. **Clone o Repositório**

```bash
git clone https://github.com/henrique-lopes-93/EnsinE.git
cd EnsinE.CRM
```
## 3. Configure a String de Conexão
Abra o arquivo appsettings.json e edite a conexão com o seu banco:

```json

"ConnectionStrings": {
  "DefaultConnection": "Server=localhost\\SQLEXPRESS;Database=EnsinECRM;Trusted_Connection=True;TrustServerCertificate=True;"
}

```

## 4. Crie o Banco de Dados com Entity Framework
No terminal, execute:
```bash

dotnet ef database update
```
Isso vai aplicar as migrations e criar o banco com as tabelas de Produtos e Clientes.

## 5. Execute a Aplicação
```bash
dotnet build
dotnet run
```

**Acesse a aplicação em: [http://localhost:5109](http://localhost:5109) (ou conforme informado no terminal)**





# 📌 Funcionalidades

### Produtos
- Listagem com nome, preço, situação (com cor verde se disponível)

- Lista de clientes relacionados a cada produto acessível pelo botão clientes.

### Clientes
- Cadastro (com validação simples, apenas campos requeridos)

- Edição

- Exclusão

- Listagem

### 📝 Observações

- A estrutura utiliza Bootstrap para a interface.

- O cadastro de cliente é feito em uma única view.

- As operações relacionadas a clientes acontecem em modal e são chamadas de maneira assíncrona.

- Considerado a relação de 1 para N, onde cada cliente terá apenas 1 produto.





