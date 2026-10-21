using System.Globalization;
using Desafio1;

Venda[] vendas =
[
    new() { Vendedor = "João Silva", Valor = 1200.50m },
    new() { Vendedor = "João Silva", Valor = 950.75m },
    new() { Vendedor = "João Silva", Valor = 1800.00m },
    new() { Vendedor = "João Silva", Valor = 1400.30m },
    new() { Vendedor = "João Silva", Valor = 1100.90m },
    new() { Vendedor = "João Silva", Valor = 1550.00m },
    new() { Vendedor = "João Silva", Valor = 1700.80m },
    new() { Vendedor = "João Silva", Valor = 250.30m },
    new() { Vendedor = "João Silva", Valor = 480.75m },
    new() { Vendedor = "João Silva", Valor = 320.40m },

    new() { Vendedor = "Maria Souza", Valor = 2100.40m },
    new() { Vendedor = "Maria Souza", Valor = 1350.60m },
    new() { Vendedor = "Maria Souza", Valor = 950.20m },
    new() { Vendedor = "Maria Souza", Valor = 1600.75m },
    new() { Vendedor = "Maria Souza", Valor = 1750.00m },
    new() { Vendedor = "Maria Souza", Valor = 1450.90m },
    new() { Vendedor = "Maria Souza", Valor = 400.50m },
    new() { Vendedor = "Maria Souza", Valor = 180.20m },
    new() { Vendedor = "Maria Souza", Valor = 90.75m },

    new() { Vendedor = "Carlos Oliveira", Valor = 800.50m },
    new() { Vendedor = "Carlos Oliveira", Valor = 1200.00m },
    new() { Vendedor = "Carlos Oliveira", Valor = 1950.30m },
    new() { Vendedor = "Carlos Oliveira", Valor = 1750.80m },
    new() { Vendedor = "Carlos Oliveira", Valor = 1300.60m },
    new() { Vendedor = "Carlos Oliveira", Valor = 300.40m },
    new() { Vendedor = "Carlos Oliveira", Valor = 500.00m },
    new() { Vendedor = "Carlos Oliveira", Valor = 125.75m },

    new() { Vendedor = "Ana Lima", Valor = 1000.00m },
    new() { Vendedor = "Ana Lima", Valor = 1100.50m },
    new() { Vendedor = "Ana Lima", Valor = 1250.75m },
    new() { Vendedor = "Ana Lima", Valor = 1400.20m },
    new() { Vendedor = "Ana Lima", Valor = 1550.90m },
    new() { Vendedor = "Ana Lima", Valor = 1650.00m },
    new() { Vendedor = "Ana Lima", Valor = 75.30m },
    new() { Vendedor = "Ana Lima", Valor = 420.90m },
    new() { Vendedor = "Ana Lima", Valor = 315.40m }
];

Dictionary<string, decimal> comissoes = Venda.CalcularComissoesPorVendedor(vendas);
CultureInfo culturaBrasileira = CultureInfo.GetCultureInfo("pt-BR");

foreach ((string vendedor, decimal comissao) in comissoes)
{
    Console.WriteLine($"{vendedor}: {comissao.ToString("C", culturaBrasileira)}");
}
