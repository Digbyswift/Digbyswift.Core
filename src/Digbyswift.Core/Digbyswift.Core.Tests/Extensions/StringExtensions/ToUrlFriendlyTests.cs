using System;
using Digbyswift.Core.Extensions;
using NUnit.Framework;

namespace Digbyswift.Core.Tests.Extensions.StringExtensions;

[TestFixture]
public class ToUrlFriendlyTests
{
#if NET48
    [Test]
    public void ToUrlFriendly_ReturnsNull_WhenTheInputIsNull()
    {
        // Act
        var result = ((string)null).ToUrlFriendly();

        // Assert
        Assert.That(result, Is.Null);
    }
#endif
    [Test]
    public void ToUrlFriendly_ReturnsEmptyString_WhenTheInputIsEmpty()
    {
        // Act
        var result = String.Empty.ToUrlFriendly();

        // Assert
        Assert.That(result, Is.EqualTo(String.Empty));
    }

    [TestCase("Testing", "testing")]
    [TestCase("Testing url Transform", "testing-url-transform")]
    [TestCase(" Testing url Transform with whitespace ", "testing-url-transform-with-whitespace")]
    [TestCase(" Testing url Transform's with quotes", "testing-url-transforms-with-quotes")]
    [TestCase(" Testing url & Transform's ", "testing-url-transforms")]
    public void ToUrlFriendly_ReturnsUrlFormattedString_WithoutIncorrectCharactersOrFormatting(string source, string expectedResult)
    {
        // Arrange & Act
        var result = source.ToUrlFriendly();

        // Assert
        Assert.That(result, Is.EqualTo(expectedResult));
    }
}
