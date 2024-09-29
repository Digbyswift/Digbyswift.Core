using System;
using System.Collections.Generic;
using System.Linq;
using Digbyswift.Core.Constants;

namespace Digbyswift.Core.Extensions;

public static class EnumerableExtensions
{
    public static bool NotContains<T>(this IEnumerable<T> source, T item)
    {
        if (source == null)
            throw new ArgumentNullException(nameof(source));

        return !source.Contains(item);
    }

    public static bool IsEmpty<T>(this IEnumerable<T> source)
    {
        if (source == null)
            throw new ArgumentNullException(nameof(source));

        return !source.Any();
    }

    public static IEnumerable<T> WhereNotNull<T>(this IEnumerable<T> source)
    {
        return source.Where(x => x is not null);
    }

    public static bool None<T>(this IEnumerable<T> source, Func<T, bool> func)
    {
        if (source == null)
            throw new ArgumentNullException(nameof(source));

        if (func == null)
            throw new ArgumentNullException(nameof(func));

        return !source.Any(func);
    }

#if NET48
    public static T MinOrDefault<T>(this IEnumerable<T> sequence)
    {
        if (sequence == null)
            throw new ArgumentNullException(nameof(sequence));

        return sequence.Any() ? sequence.Min() : default(T);
    }

    public static T MaxOrDefault<T>(this IEnumerable<T> sequence)
    {
        if (sequence == null)
            throw new ArgumentNullException(nameof(sequence));

        return sequence.Any() ? sequence.Max() : default(T);
    }
#else
    public static T? MinOrDefault<T>(this IEnumerable<T> sequence)
    {
        if (sequence == null)
            throw new ArgumentNullException(nameof(sequence));

        return sequence.Any() ? sequence.Min() : default(T);
    }

    public static T? MaxOrDefault<T>(this IEnumerable<T> sequence)
    {
        if (sequence == null)
            throw new ArgumentNullException(nameof(sequence));

        return sequence.Any() ? sequence.Max() : default(T);
    }
#endif

    public static bool CountIs<T>(this IEnumerable<T> source, int count)
    {
        if (source == null)
            throw new ArgumentNullException(nameof(source));

        if (count < 0)
            throw new ArgumentOutOfRangeException(nameof(count), "Must be zero or greater");

        return source.Count() == count;
    }

    public static bool CountIsLt<T>(this IEnumerable<T> source, int count)
    {
        if (source == null)
            throw new ArgumentNullException(nameof(source));

        if (count < NumericConstants.One)
            throw new ArgumentOutOfRangeException(nameof(count), "Must be one or greater");

        return source.Count() < count;
    }

    public static bool CountIsLe<T>(this IEnumerable<T> source, int count)
    {
        if (source == null)
            throw new ArgumentNullException(nameof(source));

        if (count < NumericConstants.Zero)
            throw new ArgumentOutOfRangeException(nameof(count), "Must be zero or greater");

        return source.Count() <= count;
    }

    public static bool CountIsGt<T>(this IEnumerable<T> source, int count)
    {
        if (source == null)
            throw new ArgumentNullException(nameof(source));

        if (count < NumericConstants.Zero)
            throw new ArgumentOutOfRangeException(nameof(count), "Must be zero or greater");

        return source.Count() > count;
    }

    public static bool CountIsGe<T>(this IEnumerable<T> source, int count)
    {
        if (source == null)
            throw new ArgumentNullException(nameof(source));

        if (count < NumericConstants.Zero)
            throw new ArgumentOutOfRangeException(nameof(count), "Must be zero or greater");

        return source.Count() >= count;
    }

    public static IEnumerable<T> SkipLast<T>(this IEnumerable<T> source)
    {
        if (source == null)
            throw new ArgumentNullException(nameof(source));

        using (var e = source.GetEnumerator())
        {
            if (e.MoveNext())
            {
                for (var value = e.Current; e.MoveNext(); value = e.Current)
                    yield return value;
            }
        }
    }
}
