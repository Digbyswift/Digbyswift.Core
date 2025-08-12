using System;
using Digbyswift.Core.Extensions.ThirdParty;
using NUnit.Framework;

namespace Digbyswift.Core.Tests.Extensions.ThirdParty;

[TestFixture]
[TestOf(typeof(YouTubeStringExtensions))]
public class YouTubeStringExtensionsTest
{
    #region IsYoutubeUrl

    [TestCase("https://www.youtube.com/watch?v=lJIrF4YjHfQ&t=2s")]
    public void IsYouTubeUrl_ReturnsTrue_WhenWatchUrlProvided(string source)
    {
       // Arrange & Act
       var result = source.IsYouTubeUrl();

       // Assert
       Assert.That(result, Is.True);
    }

    [TestCase("")]
    [TestCase("https://www.youtube.com/")]
    [TestCase("https://www.youtube.com/watch?")]
    public void IsYouTubeUrl_ReturnsFalse_WhenWatchUrlIsIncorrect(string source)
    {
        // Arrange & Act
        var result = source.IsYouTubeUrl();

        // Assert
        Assert.That(result, Is.False);
    }

    [TestCase("https://www.youtube.com/embed/lJIrF4YjHfQ?si=isrdMegKebVIZ8Su")]
    public void IsYouTubeUrl_ReturnsTrue_WhenEmbedUrlProvided(string source)
    {
        // Arrange & Act
        var result = source.IsYouTubeUrl();

        // Assert
        Assert.That(result, Is.True);
    }

    [TestCase("")]
    [TestCase("https://www.youtube.com/")]
    [TestCase("https://www.youtube.com/embed?")]
    public void IsYouTubeUrl_ReturnsFalse_WhenEmbedUrlIsIncorrect(string source)
    {
        // Arrange & Act
        var result = source.IsYouTubeUrl();

        // Assert
        Assert.That(result, Is.False);
    }

    #endregion

    #region ExtractYouTubeVideoId

    [TestCase("https://www.youtube.com/watch?v=lJIrF4YjHfQ&t=2s", "lJIrF4YjHfQ")]
    [TestCase("https://www.youtube.com/embed/lJIrF4YjHfQ?si=isrdMegKebVIZ8Su", "lJIrF4YjHfQ")]
    public void ExtractYouTubeVideoId_ReturnsVideoId_WhenIdIsInUrl(string source, string expectedResult)
    {
        // Arrange & Act
        var result = source.ExtractYouTubeVideoId();

        // Assert
        Assert.That(result, Is.EqualTo(expectedResult));
    }

    [TestCase("https://www.youtube.com/watch/")]
    [TestCase("https://www.youtube.com/embed/")]
    public void ExtractYouTubeVideoId_ReturnsUrlWithEmptyPathSegment_WhenIdIsNotInUrl(string source)
    {
        // Arrange & Act
        var result = source.ExtractYouTubeVideoId();

        // Assert
        Assert.That(result, Is.EqualTo(String.Empty));
    }

    #endregion

    #region ToYouTubeThumbnailUrl

    [TestCase("", "https://i.ytimg.com/vi//0.jpg")]
    [TestCase("https://www.youtube.com/watch?v=lJIrF4YjHfQ&t=2s", "https://i.ytimg.com/vi/lJIrF4YjHfQ/0.jpg")]
    [TestCase("https://www.youtube.com/embed/lJIrF4YjHfQ?si=isrdMegKebVIZ8Su", "https://i.ytimg.com/vi/lJIrF4YjHfQ/0.jpg")]
    public void ToYouTubeThumbnailUrl_ReturnsThumbnailUrl_WhenUrlIsValid(string source, string expectedResult)
    {
        // Arrange & Act
        var result = source.ToYouTubeThumbnailUrl();

        // Assert
        Assert.That(result, Is.EqualTo(expectedResult));
    }

    [TestCase("https://www.youtube.com/watch/", "https://i.ytimg.com/vi//0.jpg")]
    [TestCase("https://www.youtube.com/embed/", "https://i.ytimg.com/vi//0.jpg")]
    public void ToYouTubeThumbnailUrl_ReturnsUrlWithEmptyPathSegment_WhenUrlIsNotValid(string source, string expectedResult)
    {
        // Arrange & Act
        var result = source.ToYouTubeThumbnailUrl();

        // Assert
        Assert.That(result, Is.EqualTo(expectedResult));
    }

    #endregion

    #region ToYouTubeEmbedUrl

    [TestCase("https://www.youtube.com/watch?v=lJIrF4YjHfQ", "https://www.youtube-nocookie.com/embed/lJIrF4YjHfQ/?v=lJIrF4YjHfQ&rel=0&modestbranding=1&controls=0")]
    public void ToYouTubeEmbedUrl_ReturnsEmbedUrl_WhenUrlIsValid(string source, string expectedResult)
    {
        // Arrange & Act
        var result = source.ToYouTubeEmbedUrl();

        // Assert
        Assert.That(result, Is.EqualTo(expectedResult));
    }

    [TestCase("https://www.youtube.com/embed/lJIrF4YjHfQ?si=isrdMegKebVIZ8Su", "https://www.youtube-nocookie.com/embed/lJIrF4YjHfQ/?si=isrdMegKebVIZ8Su&rel=0&modestbranding=1&controls=0")]
    public void ToYouTubeEmbedUrl_ReturnsOriginalUrl_WhenUrlIsAlreadyAnEmbedUrl(string source, string expectedResult)
    {
        // Arrange & Act
        var result = source.ToYouTubeEmbedUrl();

        // Assert
        Assert.That(result, Is.EqualTo(expectedResult));
    }

    [TestCase("https://www.youtube.com/watch?v=lJIrF4YjHfQ", "https://www.youtube-nocookie.com/embed/lJIrF4YjHfQ/?v=lJIrF4YjHfQ&rel=0&modestbranding=1&controls=0")]
    [TestCase("https://www.youtube.com/embed/?si=isrdMegKebVIZ8Su", "https://www.youtube-nocookie.com/embed//?si=isrdMegKebVIZ8Su&rel=0&modestbranding=1&controls=0")]
    public void ToYouTubeEmbedUrl_ReturnsUrlWithEmptyPathSegment_WhenUrlIsNotValid(string source, string expectedResult)
    {
        // Arrange & Act
        var result = source.ToYouTubeEmbedUrl();

        // Assert
        Assert.That(result, Is.EqualTo(expectedResult));
    }

    #endregion
}