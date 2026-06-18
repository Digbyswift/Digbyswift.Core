using System;
using Digbyswift.Core.Extensions.ThirdParty;
using NUnit.Framework;

namespace Digbyswift.Core.Tests.Extensions.ThirdParty;

[TestFixture]
[TestOf(typeof(VimeoStringExtensions))]
public class VimeoStringExtensionsTest
{
    #region IsVimeoUrl

    [TestCase("https://www.vimeo.com/347119375")]
    public void IsVimeoUrl_ReturnsTrue_WhenUrlProvided(string source)
    {
        // Arrange & Act
        var result = source.IsVimeoUrl();

        // Assert
        Assert.That(result, Is.True);
    }

    [TestCase("")]
    [TestCase("https://www.vimeo.com/")]
    [TestCase("https://player.vimeo.com/video//")]
    public void IsVimeoUrl_ReturnsFalse_WhenUrlIsIncorrect(string source)
    {
        // Arrange & Act
        var result = source.IsVimeoUrl();

        // Assert
        Assert.That(result, Is.False);
    }

    [TestCase("https://player.vimeo.com/video/347119375")]
    public void IsVimeoUrl_ReturnsTrue_WhenPlayerUrlProvided(string source)
    {
        // Arrange & Act
        var result = source.IsVimeoUrl();

        // Assert
        Assert.That(result, Is.True);
    }

    [TestCase("")]
    [TestCase("https://player.vimeo.com/video/")]
    [TestCase("https://player.vimeo.com/video/0000")]// This one fails, even though a 4 digit ID should be invalid
    public void IsVimeoUrl_ReturnsFalse_WhenPlayerUrlIsIncorrect(string source)
    {
        // Arrange & Act
        var result = source.IsVimeoUrl();

        // Assert
        Assert.That(result, Is.False);
    }

    #endregion

    #region IsVimeoEventUrl

    [TestCase("https://www.vimeo.com/event/347119375")]
    public void IsVimeoEventUrl_ReturnsTrue_WhenUrlProvided(string source)
    {
        // Arrange & Act
        var result = source.IsVimeoEventUrl();

        // Assert
        Assert.That(result, Is.True);
    }

    [TestCase("")]
    [TestCase("https://www.vimeo.com/")]
    [TestCase("https://player.vimeo.com/video//")]
    [TestCase("https://player.vimeo.com/event/")]
    public void IsVimeoEventUrl_ReturnsFalse_WhenUrlIsIncorrect(string source)
    {
        // Arrange & Act
        var result = source.IsVimeoEventUrl();

        // Assert
        Assert.That(result, Is.False);
    }

    [TestCase("https://player.vimeo.com/event/347119375")]
    public void IsVimeoEventUrl_ReturnsTrue_WhenPlayerUrlProvided(string source)
    {
        // Arrange & Act
        var result = source.IsVimeoEventUrl();

        // Assert
        Assert.That(result, Is.True);
    }

    [TestCase("")]
    [TestCase("https://player.vimeo.com/event/")]
    [TestCase("https://player.vimeo.com/event/0000")] // This one fails, even though a 4 digit ID should be invalid
    public void IsVimeoEventUrl_ReturnsFalse_WhenPlayerUrlIsIncorrect(string source)
    {
        // Arrange & Act
        var result = source.IsVimeoEventUrl();

        // Assert
        Assert.That(result, Is.False);
    }

    #endregion

    #region Extract VimeoId

    [TestCase("https://www.vimeo.com/347119375", "347119375")]
    [TestCase("https://player.vimeo.com/video/347119375", "347119375")]
    public void ExtractVimeoVideoId_ReturnsVideoId_WhenIdIsInUrl(string source, string expectedResult)
    {
        // Arrange & Act
        var result = source.ExtractVimeoVideoId();

        // Assert
        Assert.That(result, Is.EqualTo(expectedResult));
    }

    [TestCase("https://www.vimeo.com/")]
    [TestCase("https://player.vimeo.com/video/")]
    public void ExtractVimeoVideoId_ReturnsUrlWithEmptyPathSegment_WhenIdIsNotInUrl(string source)
    {
        // Arrange & Act
        var result = source.ExtractVimeoVideoId();

        // Assert
        Assert.That(result, Is.EqualTo(String.Empty));
    }

    #endregion

    #region ToVimeoEmbedUrl

    [TestCase("https://www.vimeo.com/347119375", "https://player.vimeo.com/video/347119375/")]
    public void ToVimeoEmbedUrl_ReturnsPlayerUrl_WhenUrlIsValid(string source, string expectedResult)
    {
        // Arrange & Act
        var result = source.ToVimeoEmbedUrl();

        // Assert
        Assert.That(result, Is.EqualTo(expectedResult));
    }

    [TestCase("https://player.vimeo.com/video/347119375", "https://player.vimeo.com/video/347119375/")]
    public void ToVimeoEmbedUrl_ReturnsOriginalUrl_WhenUrlIsAlreadyPlayerUrl(string source, string expectedResult)
    {
        // Arrange & Act
        var result = source.ToVimeoEmbedUrl();

        // Assert
        Assert.That(result, Is.EqualTo(expectedResult));
    }

    [TestCase("https://www.vimeo.com/video/", "https://player.vimeo.com/video/")]
    [TestCase("https://player.vimeo.com/video/", "https://player.vimeo.com/video/")] // This fails as it returns the non-embed url
    public void ToVimeoEmbedUrl_ReturnsUrlWithEmptyPathSegment_WhenUrlIsNotValid(string source, string expectedResult)
    {
        // Arrange & Act
        var result = source.ToVimeoEmbedUrl();

        // Assert
        Assert.That(result, Is.EqualTo(expectedResult));
    }

    #endregion
}