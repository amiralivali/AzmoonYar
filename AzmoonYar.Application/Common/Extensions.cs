using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace AzmoonYar.Application.Common;

public static class Extensions
{
    public static string ToPersian(this Enum value)
    {
        var field = value.GetType().GetField(value.ToString());
        var attr = field?.GetCustomAttribute<DisplayAttribute>();
        return attr?.Name ?? value.ToString();
    }
}