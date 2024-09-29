#pragma warning disable SA1402
#if NET6_0_OR_GREATER
using System;
#endif
using System.Collections.Generic;
#if NET48 || NETSTANDARD2_0
using System.Runtime.InteropServices;
using System.Security;
#endif

namespace Digbyswift.Core.Comparisons;

#if NET6_0_OR_GREATER

/// <summary>
/// Taken from this answer on Stackoverflow https://stackoverflow.com/a/66354540/549820 provided by https://stackoverflow.com/users/98713/thomas-levesque.
/// </summary>
public class NaturalStringComparer : IComparer<string>
{
    public static NaturalStringComparer Ordinal { get; } = new(StringComparison.Ordinal);
    public static NaturalStringComparer OrdinalIgnoreCase { get; } = new(StringComparison.OrdinalIgnoreCase);
    public static NaturalStringComparer CurrentCulture { get; } = new(StringComparison.CurrentCulture);
    public static NaturalStringComparer CurrentCultureIgnoreCase { get; } = new(StringComparison.CurrentCultureIgnoreCase);
    public static NaturalStringComparer InvariantCulture { get; } = new(StringComparison.InvariantCulture);
    public static NaturalStringComparer InvariantCultureIgnoreCase { get; } = new(StringComparison.InvariantCultureIgnoreCase);

    private readonly StringComparison _comparison;

    public NaturalStringComparer(StringComparison comparison)
    {
        _comparison = comparison;
    }

    public int Compare(string? x, string? y)
    {
        // Let string.Compare handle the case where x or y is null
        if (x is null || y is null)
            return String.Compare(x, y, _comparison);

        var xSegments = GetSegments(x);
        var ySegments = GetSegments(y);

        while (xSegments.MoveNext() && ySegments.MoveNext())
        {
            int cmp;

            // If they're both numbers, compare the value
            if (xSegments.CurrentIsNumber && ySegments.CurrentIsNumber)
            {
                var xValue = Int64.Parse(xSegments.Current);
                var yValue = Int64.Parse(ySegments.Current);
                cmp = xValue.CompareTo(yValue);
                if (cmp != 0)
                {
                    return cmp;
                }
            }

            // If x is a number and y is not, x is "lesser than" y
            else if (xSegments.CurrentIsNumber)
            {
                return -1;
            }

            // If y is a number and x is not, x is "greater than" y
            else if (ySegments.CurrentIsNumber)
            {
                return 1;
            }

            // OK, neither are number, compare the segments as text
            cmp = xSegments.Current.CompareTo(ySegments.Current, _comparison);
            if (cmp != 0)
                return cmp;
        }

        // At this point, either all segments are equal, or one string is shorter than the other

        // If x is shorter, it's "lesser than" y
        if (x.Length < y.Length)
            return -1;

        // If x is longer, it's "greater than" y
        if (x.Length > y.Length)
            return 1;

        // If they have the same length, they're equal
        return 0;
    }

    private static StringSegmentEnumerator GetSegments(string s) => new(s);

    private struct StringSegmentEnumerator
    {
        private readonly string _s;
        private int _start;
        private int _length;

        public StringSegmentEnumerator(string s)
        {
            _s = s;
            _start = -1;
            _length = 0;
            CurrentIsNumber = false;
        }

        public ReadOnlySpan<char> Current => _s.AsSpan(_start, _length);

        public bool CurrentIsNumber { get; private set; }

        public bool MoveNext()
        {
            var currentPosition = _start >= 0
                ? _start + _length
                : 0;

            if (currentPosition >= _s.Length)
                return false;

            var start = currentPosition;
            var isFirstCharDigit = Char.IsDigit(_s[currentPosition]);

            while (++currentPosition < _s.Length && Char.IsDigit(_s[currentPosition]) == isFirstCharDigit)
            {
            }

            _start = start;
            _length = currentPosition - start;
            CurrentIsNumber = isFirstCharDigit;

            return true;
        }
    }
}
#elif NET48 || NETSTANDARD2_0
[SuppressUnmanagedCodeSecurity]
public sealed class NaturalStringComparer : IComparer<string>
{
    public int Compare(string a, string b)
    {
        return SafeNativeMethods.StrCmpLogicalW(a, b);
    }
}

internal static class SafeNativeMethods
{
    [DllImport("shlwapi.dll", CharSet = CharSet.Unicode)]
    public static extern int StrCmpLogicalW(string psz1, string psz2);
}
#endif
