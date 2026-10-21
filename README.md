# Desafios de programação em C#

Repositório com três aplicações de console independentes, desenvolvidas com .NET 10.

## Projetos

| Projeto | Descrição |
| --- | --- |
| [Desafio 1](Desafio1/README.md) | Calcula a comissão de vendas conforme o valor de cada venda e totaliza a comissão por vendedor. |
| [Desafio 2](Desafio2/README.md) | Registra entradas e saídas de produtos, identifica cada movimentação e informa o estoque atualizado. |
| [Desafio 3](Desafio3/README.md) | Calcula juros simples de 2,5% ao dia sobre um valor vencido e permite fazer vários cálculos na mesma execução. |

## Requisitos

- .NET 10 SDK

## Executar os projetos

Execute os comandos a partir da raiz do repositório. Cada projeto pode ser restaurado, compilado e executado separadamente.

### Desafio 1 — Comissão de vendas

```bash
dotnet restore Desafio1/Desafio1.csproj
dotnet build Desafio1/Desafio1.csproj
dotnet run --project Desafio1/Desafio1.csproj
```

### Desafio 2 — Movimentação de estoque

```bash
dotnet restore Desafio2/Desafio2.csproj
dotnet build Desafio2/Desafio2.csproj
dotnet run --project Desafio2/Desafio2.csproj
```

### Desafio 3 — Juros por atraso

```bash
dotnet restore Desafio3/Desafio3.csproj
dotnet build Desafio3/Desafio3.csproj
dotnet run --project Desafio3/Desafio3.csproj
```

Os diretórios `bin/` e `obj/` contêm arquivos gerados durante a restauração e compilação. O `.gitignore` na raiz os exclui do Git para os três projetos.
