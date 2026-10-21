# Desafio 3 — Cálculo de juros por atraso

Aplicação de console em C# que calcula os juros sobre um valor vencido usando uma taxa simples de 2,5% por dia de atraso.

## Como executar

É necessário ter o .NET 10 SDK instalado. No terminal, dentro da pasta `Desafio3`, execute:

```bash
dotnet restore
dotnet build
dotnet run
```

`dotnet restore` restaura os pacotes do projeto e `dotnet build` compila a aplicação.

## Como usar

1. Informe o valor original usando vírgula para os centavos, por exemplo `150,00`.
2. Informe a data de vencimento no formato `dd/MM/aaaa`, por exemplo `10/03/2026`.
3. Consulte o valor original, os dias de atraso, os juros calculados e o total atualizado.
4. Ao final, digite `1` para fazer outro cálculo ou `0` para encerrar.

O programa valida o valor, a data e a opção de continuidade antes de prosseguir.

## Regra de cálculo

Os juros são simples e calculados sobre o valor original:

```text
juros = valor original × 0,025 × dias de atraso
valor atualizado = valor original + juros
```

A data atual é obtida pelo sistema. Se o vencimento for hoje ou estiver no futuro, os dias de atraso e os juros serão zero.
