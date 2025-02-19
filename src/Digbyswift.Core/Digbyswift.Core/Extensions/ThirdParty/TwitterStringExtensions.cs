﻿using System;
using System.Text.RegularExpressions;

namespace Digbyswift.Core.Extensions.ThirdParty;

public static class TwitterStringExtensions
{
    public const string TweetUrl = @"^https?:\/\/twitter\.com\/(?:#!\/)?(\w+)\/status(es)?\/(\d+)$";
    public static readonly Regex TweetUrlRegex = new Regex(TweetUrl, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(150));

    public static bool IsTweetUrl(this string value)
    {
        if (String.IsNullOrWhiteSpace(value))
            return false;

        return TweetUrlRegex.IsMatch(value);
    }

#if NET48
    public static string ExtractIdFromTweetUrl(this string value)
    {
        var matches = TweetUrlRegex.Matches(value);
        if (matches.Count != 1 && matches[0].Groups.Count != 4)
            return null;

        var id = matches[0].Groups[3].Value;
        return id;
    }
#else
    public static string? ExtractIdFromTweetUrl(this string value)
    {
        var matches = TweetUrlRegex.Matches(value);
        if (matches.Count != 1 && matches[0].Groups.Count != 4)
            return null;

        var id = matches[0].Groups[3].Value;
        return id;
    }
#endif
}
