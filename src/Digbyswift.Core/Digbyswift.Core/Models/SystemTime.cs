using System;

namespace Digbyswift.Core.Models;

public static class SystemTime
{
    private static DateTime? _utcNow;
    private static DateTime? _utcToday;
    private static DateTime? _localNow;
    private static DateTime? _localToday;

    public static DateTime UtcNow => _utcNow ?? DateTime.UtcNow;
    public static DateTime UtcToday => _utcToday ?? UtcNow.Date;
    public static DateTime LocalNow => _localNow ?? DateTime.Now;
    public static DateTime LocalToday => _localToday ?? LocalNow.Date;

    public static void Freeze(DateTime? frozenDate = null)
    {
        var workingDate = frozenDate ?? new DateTime(DateTime.UtcNow.Ticks, DateTimeKind.Utc);

        _utcNow = workingDate;
        _utcToday = workingDate.Date;
        _localNow = workingDate.ToLocalTime();
        _localToday = workingDate.ToLocalTime().Date;
    }

    public static void UnFreeze()
    {
        _utcNow = null;
        _utcToday = null;
        _localNow = null;
        _localToday = null;
    }
}
