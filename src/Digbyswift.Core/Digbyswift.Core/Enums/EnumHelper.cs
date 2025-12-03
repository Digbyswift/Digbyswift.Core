namespace Digbyswift.Core.Enums;

public static class EnumHelper
{
#if NET48
    public static T Parse<T>(string value, T defaultValue = default) where T : struct
    {
        return Enum.TryParse(value, out T output) ? output : defaultValue;
    }
#endif
}
