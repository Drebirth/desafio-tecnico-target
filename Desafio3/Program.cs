using System.Globalization;

CultureInfo culturaBrasileira = CultureInfo.GetCultureInfo("pt-BR");
const decimal taxaDiaria = 0.025m;
bool continuar;

Console.WriteLine("=== Cálculo de juros por atraso ===");

do
{
    decimal valor;
    while (true)
    {
        Console.Write("Informe o valor original (ex.: 150,00): R$ ");
        string? entradaValor = Console.ReadLine();

        if (decimal.TryParse(entradaValor, NumberStyles.Number, culturaBrasileira, out valor) && valor > 0)
        {
            break;
        }

        Console.WriteLine("Informe um valor numérico maior que zero.");
    }

    DateOnly dataVencimento;
    while (true)
    {
        Console.Write("Informe a data de vencimento (dd/MM/aaaa): ");
        string? entradaData = Console.ReadLine();

        if (DateOnly.TryParseExact(
            entradaData,
            "dd/MM/yyyy",
            culturaBrasileira,
            DateTimeStyles.None,
            out dataVencimento))
        {
            break;
        }

        Console.WriteLine("Data inválida. Use o formato dd/MM/aaaa.");
    }

    DateOnly hoje = DateOnly.FromDateTime(DateTime.Today);
    int diasEmAtraso = dataVencimento < hoje ? hoje.DayNumber - dataVencimento.DayNumber : 0;
    decimal juros = valor * taxaDiaria * diasEmAtraso;
    decimal valorAtualizado = valor + juros;

    Console.WriteLine("\n=== Resultado ===");
    Console.WriteLine($"Valor original: {valor.ToString("C2", culturaBrasileira)}");
    Console.WriteLine($"Vencimento: {dataVencimento.ToString("dd/MM/yyyy", culturaBrasileira)}");
    Console.WriteLine($"Data de hoje: {hoje.ToString("dd/MM/yyyy", culturaBrasileira)}");
    Console.WriteLine($"Dias em atraso: {diasEmAtraso}");
    Console.WriteLine($"Juros por atraso (2,5% ao dia): {juros.ToString("C2", culturaBrasileira)}");
    Console.WriteLine($"Valor total atualizado: {valorAtualizado.ToString("C2", culturaBrasileira)}");

    while (true)
    {
        Console.Write("\nDeseja continuar? (1 - Sim, 0 - Não): ");
        string? resposta = Console.ReadLine()?.Trim();

        if (resposta == "1")
        {
            continuar = true;
            break;
        }

        if (resposta == "0")
        {
            continuar = false;
            break;
        }

        Console.WriteLine("Opção inválida. Digite 1 para continuar ou 0 para encerrar.");
    }
} while (continuar);

Console.WriteLine("Programa encerrado.");
