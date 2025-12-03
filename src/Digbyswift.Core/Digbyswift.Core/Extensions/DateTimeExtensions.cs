using System.Globalization;
using Digbyswift.Core.Constants;
using Digbyswift.Core.Models;

namespace Digbyswift.Core.Extensions;

public static class DateTimeExtensions
{
    public static string ToInvariantString(this DateTime value)
    {
        return value.ToString(CultureInfo.InvariantCulture);
    }

    public static string ToSortableString(this DateTime value)
    {
        return value.ToString("s");
    }

    public static long ToUnixTimeSeconds(this DateTime value)
    {
#if NET6_0_OR_GREATER
        return (long)value.Subtract(DateTime.UnixEpoch).TotalSeconds;
#else
        return (long)value.Subtract(new DateTime(1970, 1, 1, 0, 0, 0, value.Kind)).TotalSeconds;
#endif
    }

    public static int DaysUntil(this DateTime value)
    {
        return (value - SystemTime.LocalNow.Date).Days;
    }

    public static int AgeNextBirthday(this DateTime dob)
    {
        var today = SystemTime.LocalToday;
        if (dob > today)
            return NumericConstants.Zero;

        return Age(dob.Date) + 1;
    }

    public static int Age(this DateTime dob)
    {
        var today = SystemTime.LocalToday;
        if (dob > today)
            return NumericConstants.Zero;

        var yearsSinceBirth = today.Year - dob.Year;
        if (dob.Date > today.SubtractYears(yearsSinceBirth))
        {
            yearsSinceBirth--;
        }

        return yearsSinceBirth;
    }

    public static bool IsBefore(this DateTime dateTime, DateTime otherDate)
    {
        return dateTime < otherDate;
    }

    public static bool IsAfter(this DateTime dateTime, DateTime otherDate)
    {
        return dateTime > otherDate;
    }

    public static DateTime SubtractDays(this DateTime dateTime, int days)
    {
        return days == 0 ? dateTime : dateTime.AddDays(-1 * days);
    }

    public static DateTime SubtractMonths(this DateTime dateTime, int months)
    {
        return months == 0 ? dateTime : dateTime.AddMonths(-1 * months);
    }

    public static DateTime SubtractYears(this DateTime dateTime, int years)
    {
        return years == 0 ? dateTime : dateTime.AddYears(-1 * years);
    }

    public static DateTime AsKind(this DateTime dateTime, DateTimeKind kind)
    {
        return new DateTime(dateTime.Ticks, kind);
    }

    /// <summary>
    /// Truncates a date by zeroing the hours, minutes and seconds, depending on
    /// the precision required.
    /// <example>
    /// <para>
    /// Truncating a DateTime of <c>2025-09-23T10:59:23.456</c> with <see cref="Digbyswift.Core.Extensions.TimePrecision.Second">TimePrecision.Seconds</see>
    /// will return <c>2025-09-23T10:59:23.000</c>. Truncating the same value with <see cref="Digbyswift.Core.Extensions.TimePrecision.Hour">TimePrecision.Hour</see>
    /// will return <c>2025-09-23T10:00:00.000</c>.
    /// </para>
    /// </example>
    /// </summary>
    /// <exception cref="ArgumentOutOfRangeException">An unrecognized TimePrecision value was passed.</exception>
    public static DateTime TruncateTime(this DateTime value, TimePrecision precision)
    {
        switch (precision)
        {
            case TimePrecision.Hour:
                return new DateTime(value.Year, value.Month, value.Day, value.Hour, 0, 0, value.Kind);

            case TimePrecision.Minute:
                return new DateTime(value.Year, value.Month, value.Day, value.Hour, value.Minute, 0, value.Kind);

            case TimePrecision.Second:
                return new DateTime(value.Year, value.Month, value.Day, value.Hour, value.Minute, value.Second, value.Kind);

            case TimePrecision.Millisecond:
                return new DateTime(value.Year, value.Month, value.Day, value.Hour, value.Minute, value.Second, value.Millisecond, value.Kind);
        }

        throw new ArgumentOutOfRangeException(nameof(precision));
    }
}

public enum TimePrecision
{
    /// <summary>
    /// Hour precision.
    /// </summary>
    Hour,

    /// <summary>
    /// Minute precision.
    /// </summary>
    Minute,

    /// <summary>
    /// Second precision.
    /// </summary>
    Second,

    /// <summary>
    /// Millisecond precision.
    /// </summary>
    Millisecond
}
