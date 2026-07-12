using Digbyswift.Core.Constants;
using Nager.PublicSuffix;

namespace Digbyswift.Core.Http.Extensions;

public static class UriExtensions
{
    public static Uri ToBaseUri(this Uri uri)
    {
        if (!uri.IsAbsoluteUri)
            throw new ArgumentNullException(nameof(uri), "Cannot get the base Uri of a relative Uri");

        return new UriBuilder
        {
            Scheme = uri.Scheme,
            Host = uri.Host
        }.Uri;
    }

    public static Uri ToBareUri(this Uri uri)
    {
        var hostParts = uri.Host.Split(CharConstants.Period);
        if (hostParts.Length == 2)
            return uri;

        var bareHost = String.Join(StringConstants.Period, hostParts.Skip(1));

        return new UriBuilder
        {
            Scheme = uri.Scheme,
            Host = bareHost,
            Fragment = uri.Fragment,
            Path = uri.AbsolutePath,
            Query = uri.Query
        }.Uri;
    }

    public static string ToBareUrl(this Uri uri)
    {
        return uri.IsAbsoluteUri
            ? uri.ToBareUri().AbsoluteUri
            : uri.ToBareUri().PathAndQuery;
    }

    public static DomainInfo GetDomainInfo(this Uri uri)
    {
        if (!uri.IsAbsoluteUri)
            throw new ArgumentException("Uri must be absolute", nameof(uri));

        var domainParser = new DomainParser(new WebTldRuleProvider());
        return domainParser.Parse(uri);
    }
}
