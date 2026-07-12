using System.Globalization;
using Digbyswift.Core.Constants;

namespace Digbyswift.Core.Extensions;

public static class NumericExtensions
{
    private const double ZeroTolerance = 1e-12;

    /// <summary>
    /// Since a Double cannot reliably be exactly zero, this determines
    /// whether the absolute value passed is within a practical tolerance of
    /// zero. If so, then the value can be treated as zero.
    /// </summary>
    public static bool IsZero(this double value)
    {
        return Math.Abs(value) <= ZeroTolerance;
    }

    /// <summary>
    /// Determines whether an int is even or not. Zero is considered even (when 0 is divided by 2, the result is 0).
    /// </summary>
    public static bool IsEven(this int value)
    {
        if (value == NumericConstants.Zero)
            return true;

        return value % 2 == NumericConstants.Zero;
    }

    public static float AsPercentageOf(this int proportion, int total)
    {
        if (proportion == NumericConstants.Zero || total == NumericConstants.Zero)
            return NumericConstants.Zero;

        return (proportion / (float)total) * NumericConstants.Hundred;
    }

    public static decimal AsPercentageOf(this decimal proportion, decimal total)
    {
        if (proportion == Decimal.Zero || total == Decimal.Zero)
            return NumericConstants.Zero;

        return (proportion / total) * NumericConstants.Hundred;
    }

    public static double AsPercentageOf(this double proportion, double total)
    {
        if (proportion.IsZero() || total.IsZero())
            return NumericConstants.Zero;

        return (proportion / total) * NumericConstants.Hundred;
    }

    /// <summary>
    /// Determines the equality of two values based on decimal precision.
    /// </summary>
    /// <example>
    /// <para>123 and 123.5 are equal to zero places but not 1 decimal place.</para>
    /// <para>123.534 and 123.578 are equal to zero and one place but not 2 decimal places.</para>
    /// </example>
    /// <exception cref="ArgumentOutOfRangeException">The decimalPlaces parameter is less than zero.</exception>
    public static bool Equals(this double value, double compareTo, double decimalPlaces)
    {
        if (decimalPlaces < 0)
            throw new ArgumentOutOfRangeException(nameof(decimalPlaces), "Decimal places must be non-negative");

        var roundedDecimalPlaces = Math.Round(decimalPlaces);
        if (Math.Abs(decimalPlaces - roundedDecimalPlaces) > ZeroTolerance)
            throw new ArgumentException("Decimal places must be a whole number", nameof(decimalPlaces));

        var redundancy = 1 / Math.Pow(10, roundedDecimalPlaces);

        return Math.Abs(value - compareTo) <= redundancy;
    }

    /// <summary>
    /// <para>Takes a double and truncates the decimal part.</para>
    /// <para>This should not be used in calculations unless the precision of output is
    /// not critical. This is because since the storage of a double is non-precise and
    /// so usage in a calculation will result in inaccurate results.</para>
    /// </summary>
    /// <example>Truncating 123.889078 to 2 decimal places will return 123.88.</example>
    /// <exception cref="ArgumentOutOfRangeException">The decimalPlaces parameter is less than zero.</exception>
    public static double Truncate(this double value, int decimalPlaces)
    {
        if (decimalPlaces < 0)
            throw new ArgumentOutOfRangeException(nameof(decimalPlaces), "Decimal places must be non-negative");

        if (Double.IsNaN(value) || Double.IsInfinity(value))
            return value;

        var divisor = Math.Pow(10, decimalPlaces);
        if (Double.IsInfinity(divisor))
            return value;

        return Math.Truncate(value * divisor) / divisor;
    }

    /// <summary>
    /// Returns a string representation of the ushort value according to the <see cref="CultureInfo.InvariantCulture"/>. Equivalent to calling <c>.ToString(CultureInfo.InvariantCulture)</c>.
    /// <example>
    /// <list>
    /// <item>0 -> "0"</item>
    /// <item>1 -> "1"</item>
    /// <item>1000 -> "1000"</item>
    /// </list>
    /// </example>
    /// </summary>
    public static string ToInvariantString(this ushort value)
    {
        return value.ToString(CultureInfo.InvariantCulture);
    }

    /// <summary>
    /// Returns a string representation of the short value according to the <see cref="CultureInfo.InvariantCulture"/>. Equivalent to calling <c>.ToString(CultureInfo.InvariantCulture)</c>.
    /// <example>
    /// <list>
    /// <item>0 -> "0"</item>
    /// <item>1 -> "1"</item>
    /// <item>1000 -> "1000"</item>
    /// <item>-1000 -> "-1000"</item>
    /// </list>
    /// </example>
    /// </summary>
    public static string ToInvariantString(this short value)
    {
        return value.ToString(CultureInfo.InvariantCulture);
    }

    /// <summary>
    /// Returns a string representation of the uint value according to the <see cref="CultureInfo.InvariantCulture"/>. Equivalent to calling <c>.ToString(CultureInfo.InvariantCulture)</c>.
    /// <example>
    /// <list>
    /// <item>0 -> "0"</item>
    /// <item>1 -> "1"</item>
    /// <item>1000 -> "1000"</item>
    /// </list>
    /// </example>
    /// </summary>
    public static string ToInvariantString(this uint value)
    {
        return value.ToString(CultureInfo.InvariantCulture);
    }

    /// <summary>
    /// Returns a string representation of the int value according to the <see cref="CultureInfo.InvariantCulture"/>. Equivalent to calling <c>.ToString(CultureInfo.InvariantCulture)</c>.
    /// <example>
    /// <list>
    /// <item>0 -> "0"</item>
    /// <item>1 -> "1"</item>
    /// <item>1000 -> "1000"</item>
    /// <item>-1000 -> "-1000"</item>
    /// </list>
    /// </example>
    /// </summary>
    public static string ToInvariantString(this int value)
    {
        return value.ToString(CultureInfo.InvariantCulture);
    }

    /// <summary>
    /// Returns a string representation of the ulong value according to the <see cref="CultureInfo.InvariantCulture"/>. Equivalent to calling <c>.ToString(CultureInfo.InvariantCulture)</c>.
    /// <example>
    /// <list>
    /// <item>0 -> "0"</item>
    /// <item>1 -> "1"</item>
    /// <item>1000 -> "1000"</item>
    /// </list>
    /// </example>
    /// </summary>
    public static string ToInvariantString(this ulong value)
    {
        return value.ToString(CultureInfo.InvariantCulture);
    }

    /// <summary>
    /// Returns a string representation of the long value according to the <see cref="CultureInfo.InvariantCulture"/>. Equivalent to calling <c>.ToString(CultureInfo.InvariantCulture)</c>.
    /// <example>
    /// <list>
    /// <item>0 -> "0"</item>
    /// <item>1 -> "1"</item>
    /// <item>1000 -> "1000"</item>
    /// <item>-1000 -> "-1000"</item>
    /// </list>
    /// </example>
    /// </summary>
    public static string ToInvariantString(this long value)
    {
        return value.ToString(CultureInfo.InvariantCulture);
    }

    /// <summary>
    /// Returns a string representation of the decimal value according to the <see cref="CultureInfo.InvariantCulture"/>. Equivalent to calling <c>.ToString(CultureInfo.InvariantCulture)</c>.
    /// <example>
    /// <list>
    /// <item>0m -> "0"</item>
    /// <item>1m -> "1"</item>
    /// <item>1.0m -> "1"</item>
    /// <item>1.99m -> "1.99"</item>
    /// <item>1000.99m -> "1000.99"</item>
    /// <item>-1000.99m -> "-1000.99"</item>
    /// </list>
    /// </example>
    /// </summary>
    public static string ToInvariantString(this decimal value)
    {
        return value.ToString(CultureInfo.InvariantCulture);
    }

    /// <summary>
    /// Returns a string representation of the double value according to the <see cref="CultureInfo.InvariantCulture"/>. Equivalent to calling <c>.ToString(CultureInfo.InvariantCulture)</c>.
    /// <example>
    /// <list>
    /// <item>0d -> "0"</item>
    /// <item>1d-> "1"</item>
    /// <item>1.0d -> "1"</item>
    /// <item>1.99d -> "1.99"</item>
    /// <item>1000.99d -> "1000.99"</item>
    /// <item>-1000.99d -> "-1000.99"</item>
    /// </list>
    /// </example>
    /// </summary>
    public static string ToInvariantString(this double value)
    {
        return value.ToString(CultureInfo.InvariantCulture);
    }
}
