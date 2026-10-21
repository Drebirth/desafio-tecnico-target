# Desafio 1 — Comissão de Vendas

Aplicação de console em C# que calcula a comissão de cada venda e apresenta o total por vendedor.

## Regras de comissão

- Vendas abaixo de R$ 100,00: não geram comissão.
- Vendas a partir de R$ 100,00 e abaixo de R$ 500,00: geram 1% de comissão.
- Vendas a partir de R$ 500,00: geram 5% de comissão.

A comissão é calculada separadamente para cada venda. Depois, as comissões são somadas por vendedor.

## Dados

Os registros estão no array `Venda[] vendas`, em `Program.cs`. Cada item informa o vendedor e o valor da venda. Para trocar os dados, edite os itens desse array.

## Executar

É necessário ter o .NET 10 SDK instalado. Na pasta do workspace, execute:

```bash
dotnet restore Desafio1/Desafio1.csproj
dotnet build Desafio1/Desafio1.csproj
dotnet run --project Desafio1/Desafio1.csproj
```

`dotnet restore` restaura os pacotes do projeto e `dotnet build` compila a aplicação.

O programa imprime a comissão total de cada vendedor em reais.

