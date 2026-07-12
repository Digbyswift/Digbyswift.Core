using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;

namespace Digbyswift.Core.Http;

public class ForwardedHttpRequest(HttpRequest httpRequest) : HttpRequest
{
    // ReSharper disable once InconsistentNaming
    private const string ForwardedHostHeaderName = "X-Forwarded-Host";

    public override HostString Host
    {
        get => new(GetHost());
        set => httpRequest.Host = value;
    }

    public override HttpContext HttpContext => httpRequest.HttpContext;
    public override IHeaderDictionary Headers
    {
        get
        {
            httpRequest.Headers[HeaderNames.Host] = GetHost();
            httpRequest.Headers.Remove(ForwardedHostHeaderName);

            return httpRequest.Headers;
        }
    }

    #region Decorated members

    public override bool HasFormContentType => httpRequest.HasFormContentType;

    public override string Method
    {
        get => httpRequest.Method;
        set => httpRequest.Method = value;
    }

    public override string Scheme
    {
        get => httpRequest.Scheme;
        set => httpRequest.Scheme = value;
    }

    public override bool IsHttps
    {
        get => httpRequest.IsHttps;
        set => httpRequest.IsHttps = value;
    }

    public override PathString PathBase
    {
        get => httpRequest.PathBase;
        set => httpRequest.PathBase = value;
    }

    public override PathString Path
    {
        get => httpRequest.Path;
        set => httpRequest.Path = value;
    }

    public override QueryString QueryString
    {
        get => httpRequest.QueryString;
        set => httpRequest.QueryString = value;
    }

    public override IQueryCollection Query
    {
        get => httpRequest.Query;
        set => httpRequest.Query = value;
    }

    public override string Protocol
    {
        get => httpRequest.Protocol;
        set => httpRequest.Protocol = value;
    }

    public override IRequestCookieCollection Cookies
    {
        get => httpRequest.Cookies;
        set => httpRequest.Cookies = value;
    }

    public override long? ContentLength
    {
        get => httpRequest.ContentLength;
        set => httpRequest.ContentLength = value;
    }

    public override string? ContentType
    {
        get => httpRequest.ContentType;
        set => httpRequest.ContentType = value;
    }

    public override Stream Body
    {
        get => httpRequest.Body;
        set => httpRequest.Body = value;
    }

    public override IFormCollection Form
    {
        get => httpRequest.Form;
        set => httpRequest.Form = value;
    }

    public override Task<IFormCollection> ReadFormAsync(CancellationToken cancellationToken = default) => httpRequest.ReadFormAsync(cancellationToken);

    #endregion

    private string? GetHost()
    {
        if (httpRequest.Headers.TryGetValue(ForwardedHostHeaderName, out var forwardedHost) && !String.IsNullOrWhiteSpace(forwardedHost))
            return forwardedHost;

        return httpRequest.Host.HasValue
            ? httpRequest.Host.Value
            : String.Empty;
    }
}
