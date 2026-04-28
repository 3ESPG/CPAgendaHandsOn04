namespace AgendaConsole;

public class Agenda
{
    private readonly List<Compromisso> _compromissos = new();

    public void AdicionarCompromisso(Compromisso compromisso)
    {
        _compromissos.Add(compromisso);
        Console.WriteLine("✔ Compromisso adicionado com sucesso!\n");
    }

    // Retorna compromissos do dia atual no timezone informado
    public List<Compromisso> ObterCompromissosHoje(string timezoneId)
    {
        var tz = TimeZoneInfo.FindSystemTimeZoneById(timezoneId);
        var hoje = TimeZoneInfo.ConvertTime(DateTimeOffset.UtcNow, tz).Date;
        return FiltrarPorData(hoje, timezoneId);
    }

    // Retorna compromissos de uma data específica no timezone informado
    public List<Compromisso> ObterCompromissosPorData(DateTime data, string timezoneId)
    {
        return FiltrarPorData(data.Date, timezoneId);
    }

    private List<Compromisso> FiltrarPorData(DateTime data, string timezoneId)
    {
        return _compromissos
            .Where(c => c.ConverterParaTimezone(timezoneId).Date == data)
            .OrderBy(c => c.ConverterParaTimezone(timezoneId))
            .ToList();
    }

    public void ExibirCompromissos(List<Compromisso> lista, string timezoneId, string titulo)
    {
        Console.WriteLine($"\n📅 {titulo} [{timezoneId}]");
        Console.WriteLine(new string('-', 50));

        if (lista.Count == 0)
        {
            Console.WriteLine("Nenhum compromisso encontrado.");
        }
        else
        {
            foreach (var c in lista)
            {
                var horarioLocal = c.ConverterParaTimezone(timezoneId);
                Console.WriteLine($"  🕐 {horarioLocal:dd/MM/yyyy HH:mm} — {c.Descricao}");
                Console.WriteLine($"     (Salvo como: {c.DataHora:dd/MM/yyyy HH:mm} {c.Timezone})");
            }
        }
        Console.WriteLine(new string('-', 50));
    }
}