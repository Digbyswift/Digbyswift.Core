using System;
using Digbyswift.Core.Constants;
using Digbyswift.Core.Models;

namespace Digbyswift.Core.Extensions;

public static class DateTimeExtensions
{
    public static int GetDaysUntil(this DateTime dateTime)
    {
        return (dateTime - SystemTime.LocalNow.Date).Days;
    }

    public static int GetAgeNextBirthday(this DateTime dob)
    {
        var today = SystemTime.LocalToday;
        if (dob >= today)
            return 0;

        var ageNextBirthday = today.Year - dob.Year;

        if (dob.AddYears(ageNextBirthday) < today)
        {
            ageNextBirthday++;
        }

        return ageNextBirthday;
    }

    public static int GetCurrentAge(this DateTime dob)
    {
        if (dob >= SystemTime.LocalToday)
            return NumericConstants.Zero;

        return GetAgeNextBirthday(dob) - NumericConstants.One;
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
}
