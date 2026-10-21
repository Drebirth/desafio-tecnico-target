using System.Text.Json;

internal sealed class SistemaEstoque
{
    private const string EstoqueInicialJson = """
    {
      "estoque": [
        { "codigoProduto": 101, "descricaoProduto": "Caneta Azul", "estoque": 150 },
        { "codigoProduto": 102, "descricaoProduto": "Caderno Universitário", "estoque": 75 },
        { "codigoProduto": 103, "descricaoProduto": "Borracha Branca", "estoque": 200 },
        { "codigoProduto": 104, "descricaoProduto": "Lápis Preto HB", "estoque": 320 },
        { "codigoProduto": 105, "descricaoProduto": "Marcador de Texto Amarelo", "estoque": 90 }
      ]
    }
    """;

    private readonly List<Produto> produtos = JsonSerializer.Deserialize<EstoqueInicial>(
        EstoqueInicialJson,
        new JsonSerializerOptions { PropertyNameCaseInsensitive = true })!.Estoque;

    private readonly List<Movimentacao> movimentacoes = [];
    private long proximoIdentificador = 1;

    public void Executar()
    {
        Console.WriteLine("=== Movimentação de estoque ===");

        while (true)
        {
            ExibirEstoque();
            int codigoProduto = LerInteiro("Código do produto (0 para sair): ", 0);

            if (codigoProduto == 0)
            {
                break;
            }

            Produto? produto = produtos.Find(item => item.CodigoProduto == codigoProduto);
            if (produto is null)
            {
                Console.WriteLine("Produto não encontrado. Confira o código e tente novamente.");
                continue;
            }

            TipoMovimentacao tipo = LerTipoMovimentacao();
            if (tipo == TipoMovimentacao.Saida && produto.Estoque == 0)
            {
                Console.WriteLine("Não há estoque disponível para saída desse produto.");
                continue;
            }

            int limiteQuantidade = tipo == TipoMovimentacao.Saida
                ? produto.Estoque
                : int.MaxValue - produto.Estoque;
            if (limiteQuantidade == 0)
            {
                Console.WriteLine("O estoque desse produto atingiu o limite suportado.");
                continue;
            }

            int quantidade = LerInteiro("Quantidade: ", 1, limiteQuantidade);
            string descricao = LerDescricao();

            produto.Estoque += tipo == TipoMovimentacao.Entrada ? quantidade : -quantidade;

            var movimentacao = new Movimentacao(
                proximoIdentificador++,
                produto.CodigoProduto,
                produto.DescricaoProduto,
                tipo,
                descricao,
                quantidade,
                produto.Estoque);

            movimentacoes.Add(movimentacao);
            ExibirConfirmacao(movimentacao);
        }

        Console.WriteLine($"\nPrograma encerrado. Movimentações registradas: {movimentacoes.Count}.");
    }

    private void ExibirEstoque()
    {
        Console.WriteLine("\nEstoque atual:");
        foreach (Produto produto in produtos)
        {
            Console.WriteLine($"  {produto.CodigoProduto} - {produto.DescricaoProduto}: {produto.Estoque} unidade(s)");
        }
    }

    private static TipoMovimentacao LerTipoMovimentacao()
    {
        while (true)
        {
            Console.Write("Tipo de movimentação (1 - Entrada, 2 - Saída): ");
            string? entrada = Console.ReadLine();

            if (entrada == "1")
            {
                return TipoMovimentacao.Entrada;
            }

            if (entrada == "2")
            {
                return TipoMovimentacao.Saida;
            }

            Console.WriteLine("Opção inválida. Digite 1 para entrada ou 2 para saída.");
        }
    }

    private static int LerInteiro(string prompt, int minimo, int maximo = int.MaxValue)
    {
        while (true)
        {
            Console.Write(prompt);
            string? entrada = Console.ReadLine();

            if (int.TryParse(entrada, out int valor) && valor >= minimo && valor <= maximo)
            {
                return valor;
            }

            if (minimo == 1 && maximo < int.MaxValue)
            {
                Console.WriteLine($"Digite uma quantidade entre 1 e {maximo} (estoque disponível).");
            }
            else
            {
                Console.WriteLine($"Digite um número inteiro igual ou maior que {minimo}.");
            }
        }
    }

    private static string LerDescricao()
    {
        while (true)
        {
            Console.Write("Descrição da movimentação: ");
            string? descricao = Console.ReadLine()?.Trim();

            if (!string.IsNullOrWhiteSpace(descricao))
            {
                return descricao;
            }

            Console.WriteLine("A descrição não pode ficar em branco.");
        }
    }

    private static void ExibirConfirmacao(Movimentacao movimentacao)
    {
        string tipo = movimentacao.Tipo == TipoMovimentacao.Entrada ? "Entrada" : "Saída";
        Console.WriteLine("\nMovimentação registrada com sucesso:");
        Console.WriteLine($"  Identificador: {movimentacao.Identificador}");
        Console.WriteLine($"  Tipo: {tipo}");
        Console.WriteLine($"  Descrição: {movimentacao.Descricao}");
        Console.WriteLine($"  Produto: {movimentacao.DescricaoProduto} (código {movimentacao.CodigoProduto})");
        Console.WriteLine($"  Quantidade movimentada: {movimentacao.Quantidade}");
        Console.WriteLine($"  Estoque final do produto: {movimentacao.EstoqueFinal}");
    }
}
