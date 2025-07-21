# 📊 Relatório Power BI — EnsinE.CRM

Este relatório foi desenvolvido como parte do sistema **EnsinE.CRM**, com o objetivo de apresentar visualmente os dados de **clientes** e **produtos**, facilitando a análise de desempenho comercial da plataforma.

## 📁 Arquivos

- `relatorio-ensine-crm.pbix` — Arquivo principal do Power BI Desktop contendo todas as visualizações e medidas desenvolvidas.
- `analise-EnsinE.pdf` - PDF com visualização do relatório com dados do meu banco local.

## 🧩 Indicadores disponíveis

-  Número total de clientes
-  Total de produtos cadastrados
-  Média percentual de desconto por cliente
-  Valor total de comissão por vendedor


## 📈 Visualizações incluídas

- Gráfico de **pizza** com a quantidade de clientes por vendedor
- Gráfico de **barras** com produtos por situação (ativo/inativo) e faixa de preço
- Gráfico de **donut** com valor da comissão por vendedor
- Gráfico de **pizza** com total de desconto concedido por vendedor

- Obs.: o filtro por data de venda foi omitido, pois a data da venda pertence conceitualmente a uma entidade de Vendas, não ao Cliente. Adicionar esse campo ao Cliente comprometeria a responsabilidade do modelo, e o desafio não requisitou o relacionamento com vendas.


## ⚙️ Como abrir e configurar

1. Abra o Power BI Desktop e selecione o arquivo `relatorio-ensine-crm.pbix`.

2. Caso o relatório não consiga se conectar automaticamente ao banco de dados, siga os passos abaixo:

   - Vá em **Transformar dados > Configurações de fonte de dados**
   - Clique em **Alterar Fonte**
   - Insira o nome da instância local do seu SQL Server, como:

     - `(localdb)\MSSQLLocalDB`
     - `localhost\SQLEXPRESS`
 

   - Aponte para o banco de dados: `EnsinECRM`
   - Clique em **Aplicar alterações**

   A autenticação será feita conforme você escolher, utilizei autenticação do sistema operacional.

## 🔗 Requisitos

- Power BI Desktop instalado
- Banco de dados `EnsinECRM` devidamente populado

## ✅ Observações finais

- Rodar a aplicação web antes do relatório do powerBI para garantir a criação do banco.
- Caso ainda não consiga estabelecer a conexão com o banco deixo um PDF em anexo, com o relatório realizado com dados do meu banco local durante o desenvolvimento.