using System.Collections.Specialized;
using Digbyswift.Core.Constants;

namespace Digbyswift.Core.Extensions;

public static class NameValueCollectionExtensions
{
#if NET48
    public static IDictionary<string, string> ToDictionary(this NameValueCollection source)
    {
        if (source == null)
            throw new ArgumentNullException(nameof(source));

        return source.Count > 0
            ? source.AllKeys.Where(k => k != null).ToDictionary(k => k, k => source[k])
            : [];
    }

    public static void CopyTo(this NameValueCollection source, IDictionary<string, string> dict)
    {
        if (source == null)
            throw new ArgumentNullException(nameof(source));

        if (source.Count == 0)
            return;

        foreach (var k in source.AllKeys)
        {
            if (k == null)
                continue;

            dict.Add(k, source[k]);
        }
    }

    public static string ToQueryString(this NameValueCollection source)
    {
        if (source == null)
            throw new ArgumentNullException(nameof(source));

        return source.Count > 0
            ? String.Join(StringConstants.Ampersand, source.AllKeys.Select(x => $"{x}={source[x]}"))
            : null;
    }
#elif NETSTANDARD2_1
    public static IDictionary<string, string?> ToDictionary(this NameValueCollection source)
    {
        return source.Count > 0
            ? source.AllKeys.Where(x => x != null).ToDictionary(k => k, string? (k) => source[k])
            : [];
    }
#else
    public static IDictionary<string, string?> ToDictionary(this NameValueCollection source)
    {
        return source.Count > 0
            ? source.AllKeys.OfType<string>().ToDictionary(k => k, string? (k) => source[k])
            : [];
    }
#endif

#if !NET48
    public static void CopyTo(this NameValueCollection nvc, IDictionary<string, string?> dict)
    {
        if (nvc.Count == 0)
            return;

        foreach (var k in nvc.AllKeys)
        {
            if (k == null)
                continue;

            dict.Add(k, nvc[k]);
        }
    }

    public static string? ToQueryString(this NameValueCollection source)
    {
        return source.Count > 0
            ? String.Join(StringConstants.Ampersand, source.AllKeys.Select(x => $"{x}={source[x]}"))
            : null;
    }
#endif
}
