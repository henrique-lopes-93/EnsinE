
# Relatório Power BI - EnsinE.CRM

Este relatório foi desenvolvido como parte complementar do sistema EnsinE.CRM, com o objetivo de apresentar visualmente os dados de clientes e produtos.

## 📁 Arquivo

- `relatorio-ensine-crm.pbix` — Arquivo principal do Power BI Desktop.

## 🔧 Como Usar

### 1. **Abra o arquivo**

Abra o Power BI Desktop e selecione o arquivo `relatorio-ensine-crm.pbix`.

### 2. **Atualize a fonte de dados (se necessário)**

Caso o relatório não consiga se conectar automaticamente ao banco de dados local, siga os passos abaixo:

1. Vá até o menu **Transformar dados > Configurações de fonte de dados**.
2. Clique em **Alterar fonte** e insira o nome da instância local do seu SQL Server, por exemplo:

localhost\SQLEXPRESS


3. Aponte para o banco de dados `EnsinECRM`.

4. Clique em **Aplicar alterações** e aguarde a atualização dos dados.

## 📌 Visões disponíveis

- **Resumo de Clientes**
  - Quantidade total
  - Clientes por produto
  - Distribuição por vendedor
- **Resumo de Produtos**
  - Quantidade cadastrada
  - Situação (ativos/inativos)
  - Preço médio

---

## 📝 Observações

- Certifique-se de que o banco de dados esteja populado antes de abrir o relatório.

---

