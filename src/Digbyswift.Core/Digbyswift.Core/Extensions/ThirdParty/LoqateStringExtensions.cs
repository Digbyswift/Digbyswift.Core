using System.Text.RegularExpressions;

namespace Digbyswift.Core.Extensions.ThirdParty;

public static class LoqateStringExtensions
{
    private static TimeSpan IsTimeout { get; } = TimeSpan.FromMilliseconds(150);

    private static readonly Regex _loqateAddressId = new Regex(@"^GB\|[A-Z]+\|A\|\d+$", RegexOptions.IgnoreCase, IsTimeout);
    private static readonly Regex _loqateContainerId = new Regex(@"^GB\|[A-Z]+\|[A-Z]+\|[A-Z\d\-]+\|[A-Z]{3}$", RegexOptions.IgnoreCase, IsTimeout);

    /// <summary>
    /// Validates a Loqate address ID.
    /// </summary>
    public static bool IsLoqateAddressId(this string value)
    {
        if (String.IsNullOrWhiteSpace(value))
            return false;

        return _loqateAddressId.IsMatch(value);
    }

    /// <summary>
    /// Validates a Loqate container ID.
    /// </summary>
    public static bool IsLoqateContainerId(this string value)
    {
        if (String.IsNullOrWhiteSpace(value))
            return false;

        return _loqateContainerId.IsMatch(value);
    }
}
