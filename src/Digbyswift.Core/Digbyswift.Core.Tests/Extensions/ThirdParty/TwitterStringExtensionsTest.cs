using Digbyswift.Core.Extensions.ThirdParty;
using NUnit.Framework;

namespace Digbyswift.Core.Tests.Extensions.ThirdParty;

[TestFixture]
[TestOf(typeof(TwitterStringExtensions))]
public class TwitterStringExtensionsTest
{
    #region IsTweetUrl

    [TestCase("https://x.com/dotnet/status/1167169777414168576")]
    public void IsTweetUrl_ReturnsTrue_WhenUrlIsTweet(string source)
    {
        // Arrange & Act
        var result = source.IsTweetUrl();

        // Assert
        Assert.That(result, Is.True);
    }

    [TestCase("")]
    [TestCase("https://x.com/dotnet/1167169777414168576")]
    [TestCase("https://x.com/dotnet/status/")]
    public void IsTweetUrl_ReturnsFalse_WhenUrlIsNotTweet(string source)
    {
        // Arrange & Act
        var result = source.IsTweetUrl();

        // Assert
        Assert.That(result, Is.False);
    }

    #endregion

    #region ExtractIdFromTweetUrl

#if NET48
    [TestCase("https://x.com/dotnet/status/1167169777414168576", "1167169777414168576")]
    public void ExtractIdFromTweetUrl_ReturnsId_WhenTweetUrlContainsId(string source, string expectedResult)
    {
        // Arrange & Act
        var result = source.ExtractIdFromTweetUrl();

        // Assert
        Assert.That(result, Is.EqualTo(expectedResult));
    }

    [TestCase("")]
    [TestCase("https://x.com/dotnet/status/")]
    public void ExtractIdFromTweetUrl_ReturnsNull_WhenTweetUrlDoesNotContainId(string source)
    {
        // Arrange & Act
        var result = source.ExtractIdFromTweetUrl();

        // Assert
        Assert.That(result, Is.EqualTo(null));
    }
#else
    [TestCase("https://x.com/dotnet/status/1167169777414168576", "1167169777414168576")]
    public void ExtractIdFromTweetUrl_ReturnsId_WhenTweetUrlContainsId(string source, string expectedResult)
    {
        // Arrange & Act
        var result = source.ExtractIdFromTweetUrl();

        // Assert
        Assert.That(result, Is.EqualTo(expectedResult));
    }

    [TestCase("")]
    [TestCase("https://x.com/dotnet/status/")]
    public void ExtractIdFromTweetUrl_ReturnsNull_WhenTweetUrlDoesNotContainId(string source)
    {
        // Arrange & Act
        var result = source.ExtractIdFromTweetUrl();

        // Assert
        Assert.That(result, Is.EqualTo(null));
    }
#endif
    #endregion
}