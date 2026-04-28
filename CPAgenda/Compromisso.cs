namespace AgendaConsole;

public class Compromisso
{
    public string Descricao { get; set; } = string.Empty;
    public DateTimeOffset DataHora { get; set; }
    public string Timezone { get; set; } = string.Empty;

    // Converte o compromisso para um timezone específico
    public DateTimeOffset ConverterParaTimezone(string timezoneId)
    {
        var tz = TimeZoneInfo.FindSystemTimeZoneById(timezoneId);
        return TimeZoneInfo.ConvertTime(DataHora, tz);
    }

    public override string ToString()
    {
        return $"[{DataHora:dd/MM/yyyy HH:mm} {Timezone}] {Descricao}";
    }
}