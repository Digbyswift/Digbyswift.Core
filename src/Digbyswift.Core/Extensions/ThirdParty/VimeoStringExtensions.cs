using System.Text.RegularExpressions;

namespace Digbyswift.Core.Extensions.ThirdParty;

public static class VimeoStringExtensions
{
    private static readonly Regex _vimeoUrlRegex = new(@"vimeo\.com/(?:.*#|.*(videos?|event)/)?([0-9]+)", RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(150));

    public static bool IsVimeoUrl(this string videoUrl)
    {
        if (String.IsNullOrWhiteSpace(videoUrl))
            return false;

        return _vimeoUrlRegex.IsMatch(videoUrl);
    }

    public static bool IsVimeoEventUrl(this string videoUrl)
    {
        if (String.IsNullOrWhiteSpace(videoUrl))
            return false;

        var matches = _vimeoUrlRegex.Matches(videoUrl);
        if (matches.Count == 0 || matches[0].Groups.Count != 3)
            return false;

        return matches[0].Groups[1].Value.EqualsIgnoreCase("event");
    }

    public static string ExtractVimeoVideoId(this string videoUrl)
    {
        if (String.IsNullOrWhiteSpace(videoUrl))
            return String.Empty;

        var matches = _vimeoUrlRegex.Matches(videoUrl);
        if (matches.Count == 0 || matches[0].Groups.Count != 3)
            return String.Empty;

        return matches[0].Groups[2].Value;
    }

    /// <summary>
    /// If the given URL is a valid Vimeo video URL it is parsed to a Vimeo embed URL. Otherwise, it is returned as-is.
    /// </summary>
    public static string ToVimeoEmbedUrl(this string videoUrl)
    {
        if (!videoUrl.IsVimeoUrl())
            return videoUrl;

        var videoId = videoUrl.ExtractVimeoVideoId();
        var query = new Uri(videoUrl).Query;
        var workingUrl = videoUrl.IsVimeoEventUrl()
            ? $"https://vimeo.com/event/{videoId}/embed/"
            : $"https://player.vimeo.com/video/{videoId}/";

        return !String.IsNullOrWhiteSpace(query)
            ? $"{workingUrl}?{query}"
            : workingUrl;
    }
}
