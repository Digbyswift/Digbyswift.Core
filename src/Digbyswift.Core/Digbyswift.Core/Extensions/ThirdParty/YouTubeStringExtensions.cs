using System;
using System.Collections.Specialized;
using System.Linq;
using System.Text.RegularExpressions;
using Digbyswift.Core.Constants;

namespace Digbyswift.Core.Extensions.ThirdParty;

public static class YouTubeStringExtensions
{
    private static readonly Regex YouTubeUrl = new(@".*(?:(?:youtu\.be\/|v\/|vi\/|u\/\w\/|embed\/)|(?:(?:watch)?\?v(?:i)?=|\&v(?:i)?=))([^#\&\?]*).*", RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));

    public static bool IsYouTubeUrl(this string fullYouTubeVideoUrl)
    {
        return YouTubeUrl.IsMatch(fullYouTubeVideoUrl);
    }

    public static string ExtractYouTubeVideoId(this string fullYouTubeVideoUrl)
    {
        var matches = YouTubeUrl.Matches(fullYouTubeVideoUrl);
        if (matches.Count == 0)
            return String.Empty;

        var match = matches[0];
        return match.Groups.Count > 0 ? match.Groups[1].Value : String.Empty;
    }

    public static string ToYouTubeThumbnailUrl(this string fullYouTubeVideoUrl)
    {
        var videoId = fullYouTubeVideoUrl.ExtractYouTubeVideoId();
        return $"https://i.ytimg.com/vi/{videoId}/0.jpg";
    }

    /// <summary>
    /// If the given URL is a valid YouTube video URL it is parsed to a YT embed URL. Otherwise, it is returned as-is.
    /// </summary>
    public static string ToYouTubeEmbedUrl(this string fullYouTubeVideoUrl)
    {
        if (fullYouTubeVideoUrl.IsYouTubeUrl())
        {
            var videoId = fullYouTubeVideoUrl.ExtractYouTubeVideoId();
            var query = ParseYoutubeQueryString(fullYouTubeVideoUrl);
            query.Set("rel", StringConstants.Zero);
            query.Set("modestbranding", StringConstants.One);
            query.Set("controls", StringConstants.Zero);

            return $"https://www.youtube-nocookie.com/embed/{videoId}/?{query.ToQueryString()}";
        }

        return fullYouTubeVideoUrl;
    }

    private static NameValueCollection ParseYoutubeQueryString(string fullYouTubeVideoUrl)
    {
        var nvc = new NameValueCollection();
        Uri.TryCreate(fullYouTubeVideoUrl, UriKind.RelativeOrAbsolute, out var youtubeUri);
        if (youtubeUri == null)
            return nvc;

        if (!youtubeUri.IsAbsoluteUri)
        {
            Uri.TryCreate($"https://{fullYouTubeVideoUrl}", UriKind.RelativeOrAbsolute, out youtubeUri);
        }

        if (String.IsNullOrWhiteSpace(youtubeUri?.Query))
            return nvc;

        foreach (var item in youtubeUri!.Query.Replace(StringConstants.QuestionMark, String.Empty).SplitAndTrim(CharConstants.Ampersand))
        {
            var itemParts = item.SplitAndTrim(CharConstants.Equal).ToArray();
            if (itemParts.Length != 2)
                continue;

            nvc.Add(itemParts[0], itemParts[1]);
        }

        return nvc;
    }
}
