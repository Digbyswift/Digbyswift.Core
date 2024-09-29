using System;
using System.Collections.Generic;

namespace Digbyswift.Core.Comparisons;

public enum DateTimeComparePrecision : long
{
    /// <summary>
    /// Millisecond precision.
    /// </summary>
    Millisecond = TimeSpan.TicksPerMillisecond,

    /// <summary>
    /// Second precision.
    /// </summary>
    Second = TimeSpan.TicksPerSecond,

    /// <summary>
    /// Minute precision.
    /// </summary>
    Minute = TimeSpan.TicksPerMinute,

    /// <summary>
    /// Hour precision.
    /// </summary>
    Hour = TimeSpan.TicksPerHour,

    /// <summary>
    /// Day precision.
    /// </summary>
    Day = TimeSpan.TicksPerDay,
}

/// <summary>
/// Based on https://stackoverflow.com/a/71321411/549820.
/// </summary>
public class DateTimeComparer : Comparer<DateTime>
{
    public DateTimeComparePrecision Precision { get; }

    public DateTimeComparer(DateTimeComparePrecision precision)
    {
        Precision = precision;
    }

    public override int Compare(DateTime d1, DateTime d2)
    {
        var day1 = (d1.Ticks - (d1.Ticks % (long)Precision));
        var day2 = (d2.Ticks - (d2.Ticks % (long)Precision));

        if (day2 > day1)
            return -1;

        if (day2 < day1)
            return 1;

        return 0;
    }

    public bool AreEqual(DateTime d1, DateTime d2)
    {
        return Compare(d1, d2) == 0;
    }
}
