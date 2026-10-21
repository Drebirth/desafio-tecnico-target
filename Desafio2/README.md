# Desafio 2 — Movimentação de estoque

Aplicação de console em C# para registrar entradas e saídas dos produtos do depósito e consultar o saldo atualizado após cada movimentação.

## Como executar

É necessário ter o .NET 10 SDK instalado. No terminal, dentro da pasta `Desafio2`, execute:

```bash
dotnet restore
dotnet build
dotnet run
```

`dotnet restore` restaura os pacotes do projeto e `dotnet build` compila a aplicação.

## Como usar

1. Consulte a lista de produtos e seus saldos atuais.
2. Digite o código do produto que deseja movimentar.
3. Escolha `1` para entrada ou `2` para saída.
4. Informe a quantidade e uma descrição para a movimentação.
5. Confira a confirmação, que mostra o identificador, os dados da movimentação e o estoque final do produto.

Digite `0` no campo do código do produto para encerrar o programa.

O programa valida os códigos informados, exige uma quantidade positiva e impede uma saída maior que o estoque disponível.

## Estoque inicial

| Código | Produto | Quantidade |
| 101 | Caneta Azul | 150 |
| 102 | Caderno Universitário | 75 |
| 103 | Borracha Branca | 200 |
| 104 | Lápis Preto HB | 320 |
| 105 | Marcador de Texto Amarelo | 90 |

Os identificadores das movimentações começam em `1` e aumentam a cada registro durante a execução. O estoque e os registros ficam em memória; ao encerrar o programa, eles voltam aos valores iniciais na próxima execução.
