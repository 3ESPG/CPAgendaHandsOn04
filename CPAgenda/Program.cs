using AgendaConsole;

// Timezone padrão do sistema (pode ser sobrescrito pelo usuário)
string timezoneUsuario = TimeZoneInfo.Local.Id;
var agenda = new Agenda();

Console.WriteLine("╔══════════════════════════════════╗");
Console.WriteLine("║       AGENDA DE COMPROMISSOS     ║");
Console.WriteLine("╚══════════════════════════════════╝");
Console.WriteLine($"Timezone do sistema: {timezoneUsuario}\n");

bool continuar = true;
while (continuar)
{
    ExibirMenu();
    string opcao = Console.ReadLine()?.Trim() ?? "";

    switch (opcao)
    {
        case "1":
            AdicionarCompromisso(agenda);
            break;
        case "2":
            ExibirHoje(agenda, timezoneUsuario);
            break;
        case "3":
            ExibirPorData(agenda, timezoneUsuario);
            break;
        case "4":
            timezoneUsuario = AlterarTimezone();
            break;
        case "5":
            ListarTimezones();
            break;
        case "0":
            continuar = false;
            Console.WriteLine("\nAté logo! 👋");
            break;
        default:
            Console.WriteLine("Opção inválida. Tente novamente.\n");
            break;
    }
}

// ──────────────────────────────────────────
// FUNÇÕES
// ──────────────────────────────────────────

void ExibirMenu()
{
    Console.WriteLine("┌─────────────────────────────────┐");
    Console.WriteLine("│            MENU                 │");
    Console.WriteLine("│  1 - Adicionar compromisso      │");
    Console.WriteLine("│  2 - Ver compromissos de hoje   │");
    Console.WriteLine("│  3 - Ver por data               │");
    Console.WriteLine("│  4 - Alterar meu timezone       │");
    Console.WriteLine("│  5 - Listar timezones           │");
    Console.WriteLine("│  0 - Sair                       │");
    Console.WriteLine("└─────────────────────────────────┘");
    Console.Write("Escolha: ");
}

void AdicionarCompromisso(Agenda agenda)
{
    Console.WriteLine("\n── NOVO COMPROMISSO ──");

    Console.Write("Descrição: ");
    string descricao = Console.ReadLine() ?? "";

    Console.Write("Data e hora (dd/MM/yyyy HH:mm): ");
    string dataStr = Console.ReadLine() ?? "";

    Console.Write("Timezone do compromisso (ex: E. South America Standard Time): ");
    string tzId = Console.ReadLine() ?? "";

    try
    {
        var dataHora = DateTime.ParseExact(dataStr, "dd/MM/yyyy HH:mm",
            System.Globalization.CultureInfo.InvariantCulture);

        var tz = TimeZoneInfo.FindSystemTimeZoneById(tzId);
        var offset = tz.GetUtcOffset(dataHora);
        var dataHoraOffset = new DateTimeOffset(dataHora, offset);

        var compromisso = new Compromisso
        {
            Descricao = descricao,
            DataHora = dataHoraOffset,
            Timezone = tzId
        };

        agenda.AdicionarCompromisso(compromisso);
    }
    catch (FormatException)
    {
        Console.WriteLine("❌ Formato de data inválido. Use dd/MM/yyyy HH:mm\n");
    }
    catch (TimeZoneNotFoundException)
    {
        Console.WriteLine("❌ Timezone não encontrado. Use a opção 5 para listar.\n");
    }
}

void ExibirHoje(Agenda agenda, string tzId)
{
    var lista = agenda.ObterCompromissosHoje(tzId);
    var tz = TimeZoneInfo.FindSystemTimeZoneById(tzId);
    var hoje = TimeZoneInfo.ConvertTime(DateTimeOffset.UtcNow, tz).Date;
    agenda.ExibirCompromissos(lista, tzId, $"Hoje — {hoje:dd/MM/yyyy}");
}

void ExibirPorData(Agenda agenda, string tzId)
{
    Console.Write("\nDigite a data (dd/MM/yyyy): ");
    string dataStr = Console.ReadLine() ?? "";

    try
    {
        var data = DateTime.ParseExact(dataStr, "dd/MM/yyyy",
            System.Globalization.CultureInfo.InvariantCulture);

        var lista = agenda.ObterCompromissosPorData(data, tzId);
        agenda.ExibirCompromissos(lista, tzId, $"Compromissos em {data:dd/MM/yyyy}");
    }
    catch
    {
        Console.WriteLine("❌ Data inválida. Use o formato dd/MM/yyyy\n");
    }
}

string AlterarTimezone()
{
    Console.Write("\nNovo timezone (ex: E. South America Standard Time): ");
    string tzId = Console.ReadLine() ?? "";

    try
    {
        TimeZoneInfo.FindSystemTimeZoneById(tzId);
        Console.WriteLine($"✔ Timezone alterado para: {tzId}\n");
        return tzId;
    }
    catch
    {
        Console.WriteLine("❌ Timezone inválido. Mantendo o anterior.\n");
        return timezoneUsuario;
    }
}

void ListarTimezones()
{
    Console.WriteLine("\n── TIMEZONES DISPONÍVEIS ──");
    var tzs = TimeZoneInfo.GetSystemTimeZones();
    foreach (var tz in tzs)
    {
        Console.WriteLine($"  {tz.Id,-50} UTC{tz.BaseUtcOffset:hh\\:mm}");
    }
    Console.WriteLine();
}