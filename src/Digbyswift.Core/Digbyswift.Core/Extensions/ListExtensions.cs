namespace Digbyswift.Core.Extensions;

public static class ListExtensions
{
    /// <summary>
    /// Resizes a list by removing any additional items from the end of the list.
    /// </summary>
    /// <typeparam name="T">The type of elements in the list.</typeparam>
#if NET48
    /// <exception cref="ArgumentNullException">The source parameter is null</exception>
#endif
    /// <exception cref="ArgumentOutOfRangeException">The toSize parameter is greater than the source size.</exception>
    public static IList<T> Crop<T>(this IList<T> source, int toSize)
    {
#if NET48
        if (source == null)
            throw new ArgumentNullException(nameof(source));
#endif
#if NET7_0_OR_GREATER
        ArgumentOutOfRangeException.ThrowIfLessThan(source.Count, toSize, nameof(source));
#else
        if (source.Count < toSize)
            throw new ArgumentOutOfRangeException(nameof(source));
#endif

        while (source.Count > toSize)
        {
            source.RemoveAt(source.Count - 1);
        }

        return source;
    }

    public static bool Any<T>(this List<T> list)
    {
        return list.Count > 0;
    }
}
