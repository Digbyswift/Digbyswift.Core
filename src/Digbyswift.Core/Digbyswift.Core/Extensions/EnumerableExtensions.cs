using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Digbyswift.Core.Constants;

namespace Digbyswift.Core.Extensions;

public static class EnumerableExtensions
{
    public static bool NotContains<T>(this IEnumerable<T> source, T item)
    {
#if NET48
        if (source == null)
            throw new ArgumentNullException(nameof(source));
#endif
        return !source.Contains(item);
    }

    public static bool IsEmpty<T>(this IEnumerable<T> source)
    {
#if NET48
        if (source == null)
            throw new ArgumentNullException(nameof(source));
#endif
        return !source.Any();
    }

    public static IEnumerable<T> WhereNotNull<T>(this IEnumerable<T> source)
    {
#if NET48
        if (source == null)
            throw new ArgumentNullException(nameof(source));
#endif
        return source.Where(x => x is not null);
    }

    public static bool None<T>(this IEnumerable<T> source, Func<T, bool> func)
    {
#if NET48
        if (source == null)
            throw new ArgumentNullException(nameof(source));

        if (func == null)
            throw new ArgumentNullException(nameof(func));
#endif
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
    public static T? MinOrDefault<T>(this IEnumerable<T> source)
    {
#if NET48
        if (source == null)
            throw new ArgumentNullException(nameof(source));
#endif
        return source.Any() ? source.Min() : default(T);
    }

    public static T? MaxOrDefault<T>(this IEnumerable<T> source)
    {
#if NET48
        if (source == null)
            throw new ArgumentNullException(nameof(source));
#endif
        return source.Any() ? source.Max() : default(T);
    }
#endif

    /// <summary>
    /// Gets the number of items in the collection without iterating over all the
    /// items. This is more performant than Count() as it avoids allocating a list.
    /// However, this method should probably be avoided for checking the size of
    /// large collections since it will potentially iterate over a large number of
    /// items and a list allocation may be better.
    /// </summary>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public static bool CountIs<T>(this IEnumerable<T> source, int count)
    {
#if NET48
        if (source == null)
            throw new ArgumentNullException(nameof(source));
#endif
        if (count < 0)
            throw new ArgumentOutOfRangeException(nameof(count), "Must be zero or greater");

        if (source.IsEmpty())
            return count == 0;

        if (source is ICollection<T> collectionOfType)
            return collectionOfType.Count == count;

        if (source is ICollection collection)
            return collection.Count == count;

        return RawCount(source) == count;
    }

    /// <summary>
    /// Gets the number of items in the collection without iterating over all the
    /// items. This is more performant than Count() as it avoids allocating a list.
    /// However, this method should probably be avoided for checking the size of
    /// large collections since it will potentially iterate over a large number of
    /// items and a list allocation may be better.
    /// </summary>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public static bool CountIs<T>(this IEnumerable<T> source, int count, Func<T, bool> predicate)
    {
#if NET48
        if (source == null)
            throw new ArgumentNullException(nameof(source));

        if (predicate == null)
            throw new ArgumentNullException(nameof(predicate));
#endif
        if (source.IsEmpty())
            return false;

        return RawCount(source, predicate) == count;
    }

    public static bool CountIsLt<T>(this IEnumerable<T> source, int count)
    {
#if NET48
        if (source == null)
            throw new ArgumentNullException(nameof(source));
#endif
        if (count < NumericConstants.One)
            throw new ArgumentOutOfRangeException(nameof(count), "Must be one or greater");

        if (source.IsEmpty())
            return true;

        if (source is ICollection<T> collectionOfType)
            return collectionOfType.Count < count;

        if (source is ICollection collection)
            return collection.Count < count;

        return RawCount(source) < count;
    }

    public static bool CountIsLt<T>(this IEnumerable<T> source, int count, Func<T, bool> predicate)
    {
#if NET48
        if (source == null)
            throw new ArgumentNullException(nameof(source));
#endif
        if (count < NumericConstants.One)
            throw new ArgumentOutOfRangeException(nameof(count), "Must be one or greater");

        if (source.IsEmpty())
            return true;

        return RawCount(source, predicate) < count;
    }

    public static bool CountIsLe<T>(this IEnumerable<T> source, int count)
    {
#if NET48
        if (source == null)
            throw new ArgumentNullException(nameof(source));
#endif
        if (count < NumericConstants.Zero)
            throw new ArgumentOutOfRangeException(nameof(count), "Must be zero or greater");

        if (source.IsEmpty())
            return true;

        if (source is ICollection<T> collectionOfType)
            return collectionOfType.Count <= count;

        if (source is ICollection collection)
            return collection.Count <= count;

        return RawCount(source) <= count;
    }

    public static bool CountIsLe<T>(this IEnumerable<T> source, int count, Func<T, bool> predicate)
    {
#if NET48
        if (source == null)
            throw new ArgumentNullException(nameof(source));
#endif
        if (count < NumericConstants.Zero)
            throw new ArgumentOutOfRangeException(nameof(count), "Must be zero or greater");

        if (source.IsEmpty())
            return true;

        return RawCount(source, predicate) <= count;
    }

    public static bool CountIsGt<T>(this IEnumerable<T> source, int count)
    {
#if NET48
        if (source == null)
            throw new ArgumentNullException(nameof(source));
#endif
        if (count < NumericConstants.Zero)
            throw new ArgumentOutOfRangeException(nameof(count), "Must be zero or greater");

        if (source.IsEmpty())
            return false;

        if (count == 0 && source.Any())
            return true;

        if (source is ICollection<T> collectionOfType)
            return collectionOfType.Count > count;

        if (source is ICollection collection)
            return collection.Count > count;

        var foundCount = 0;

        using var e = source.GetEnumerator();
        checked
        {
            while (e.MoveNext())
            {
                foundCount++;

                if (foundCount > count)
                    return true;
            }
        }

        return false;
    }

    public static bool CountIsGt<T>(this IEnumerable<T> source, int count, Func<T, bool> predicate)
    {
#if NET48
        if (source == null)
            throw new ArgumentNullException(nameof(source));
#endif
        if (count < NumericConstants.Zero)
            throw new ArgumentOutOfRangeException(nameof(count), "Must be zero or greater");

        var foundCount = 0;

        foreach (var element in source)
        {
            checked
            {
                if (!predicate(element))
                    continue;

                if (foundCount >= count)
                    return true;

                foundCount++;
            }
        }

        return false;
    }

    public static IEnumerable<int> FindIndexes<T>(this IEnumerable<T> source, Func<T, bool> predicate)
    {
#if NET48
        if (source == null)
            throw new ArgumentNullException(nameof(source));

        if (predicate == null)
            throw new ArgumentNullException(nameof(predicate));
#endif
        var index = 0;

        foreach (var item in source)
        {
            if (predicate(item))
                yield return index;

            index++;
        }
    }

    public static int FindFirstIndex<T>(this IEnumerable<T> source, Func<T, bool> predicate)
    {
#if NET48
        if (source == null)
            throw new ArgumentNullException(nameof(source));

        if (predicate == null)
            throw new ArgumentNullException(nameof(predicate));
#endif
        var index = 0;

        foreach (var item in source)
        {
            if (predicate(item))
                return index;

            index++;
        }

        return -1;
    }

    public static int FindLastIndex<T>(this IEnumerable<T> source, Func<T, bool> predicate)
    {
#if NET48
        if (source == null)
            throw new ArgumentNullException(nameof(source));

        if (predicate == null)
            throw new ArgumentNullException(nameof(predicate));
#endif
        var lastIndex = -1;
        var index = 0;

        foreach (var item in source)
        {
            if (predicate(item))
            {
                lastIndex = index;
            }

            index++;
        }

        return lastIndex;
    }

    public static IEnumerable<T> SkipLast<T>(this IEnumerable<T> source)
    {
#if NET48
        if (source == null)
            throw new ArgumentNullException(nameof(source));
#endif
        using var e = source.GetEnumerator();
        if (!e.MoveNext())
            yield break;

        for (var value = e.Current; e.MoveNext(); value = e.Current)
        {
            yield return value;
        }
    }

    private static long RawCount<T>(IEnumerable<T> source)
    {
        var foundCount = 0;

        using var e = source.GetEnumerator();
        checked
        {
            while (e.MoveNext())
            {
                foundCount++;
            }
        }

        return foundCount;
    }

    private static long RawCount<T>(IEnumerable<T> source, Func<T, bool> predicate)
    {
        var foundCount = 0;

        foreach (var element in source)
        {
            checked
            {
                if (!predicate(element))
                    continue;

                foundCount++;
            }
        }

        return foundCount;
    }
}
