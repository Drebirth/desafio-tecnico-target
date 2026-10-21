namespace Desafio1;

public sealed class Venda
{
    public string Vendedor { get; init; } = string.Empty;

    public decimal Valor { get; init; }

    public decimal CalcularComissao()
    {
        if (Valor < 100m)
        {
            return 0m;
        }

        if (Valor < 500m)
        {
            return Valor * 0.01m;
        }

        return Valor * 0.05m;
    }

    public static Dictionary<string, decimal> CalcularComissoesPorVendedor(Venda[] vendas)
    {
        ArgumentNullException.ThrowIfNull(vendas);

        return vendas
            .GroupBy(venda => venda.Vendedor)
            .ToDictionary(
                grupo => grupo.Key,
                grupo => grupo.Sum(venda => venda.CalcularComissao()));
    }
}
