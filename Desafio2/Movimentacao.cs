internal sealed record Movimentacao(
    long Identificador,
    int CodigoProduto,
    string DescricaoProduto,
    TipoMovimentacao Tipo,
    string Descricao,
    int Quantidade,
    int EstoqueFinal);
