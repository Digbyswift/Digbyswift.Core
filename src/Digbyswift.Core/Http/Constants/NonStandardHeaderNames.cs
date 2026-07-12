namespace Digbyswift.Core.Http.Constants;

public static class NonStandardHeaderNames
{
    /// <summary>
    /// https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/X-Forwarded-For.
    /// </summary>
    public const string XForwardedFor = "X-Forwarded-For";

    /// <summary>
    /// https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/X-Forwarded-Host.
    /// </summary>
    public const string XForwardedHost = "X-Forwarded-Host";

    /// <summary>
    /// Occasionally required in CDN implementations when the Accept header is not automatically forwarded.
    /// </summary>
    public const string XForwardedAccept = "X-Forwarded-Accept";

    /// <summary>
    /// https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/X-Forwarded-Proto.
    /// </summary>
    public const string XForwardedProto = "X-Forwarded-Proto";

    /// <summary>
    /// Often added to XHR requests (with a XMLHttpRequest value). This can prevent CSRF attacks because this
    /// header cannot be added to a cross domain AJAX request without the consent of the server via CORS.
    /// </summary>
    public const string XRequestedWith = "X-Requested-With";

    /// <summary>
    /// https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/X-Frame-Options.
    /// </summary>
    public const string XFrameOptions = "X-Frame-Options";

    /// <summary>
    /// https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/X-XSS-Protection.
    /// </summary>
    public const string XXssProtection = "X-XSS-Protection";

    /// <summary>
    /// https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/X-Content-Type-Options.
    /// </summary>
    public const string XContentTypeOptions = "X-Content-Type-Options";

    /// <summary>
    /// https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/X-DNS-Prefetch-Control.
    /// </summary>
    public const string XDnsPrefetchControl = "X-DNS-Prefetch-Control";

    /// <summary>
    /// A header used by Azure to forward the original Client IP.
    /// </summary>
    public const string XAzureClientIp = "X-Azure-ClientIP";
}
