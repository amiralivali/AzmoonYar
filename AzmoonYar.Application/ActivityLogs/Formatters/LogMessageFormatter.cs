using AzmoonYar.Application.Logs.Contracts;

namespace AzmoonYar.Application.Logs.Formatters;

public static class LogMessageFormatter
{
    public static string Format(string template, ILogData date)
    {
        var properties = date.GetType().GetProperties();

        foreach (var property in properties)
        {
            var value = property.GetValue(date);
            
            template = template.Replace(
                $"{{{property.Name}}}",
                value?.ToString() ?? string.Empty);
        }
        return template;
    }
}