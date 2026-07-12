// ReSharper disable InconsistentNaming

using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;

namespace Digbyswift.Core.Http.Extensions;

public static class HttpResponseExtensions
{
    private const string CacheControlValue = "no-cache, no-store, must-revalidate";
    private const string ExpiresValue = "-1";
    private const string PragmaValue = "no-cache";

    public static void SetNoCacheHeaders(this HttpResponse response)
    {
        response.Headers[HeaderNames.CacheControl] = CacheControlValue;
        response.Headers[HeaderNames.Expires] = ExpiresValue;
        response.Headers[HeaderNames.Pragma] = PragmaValue;
    }
}
