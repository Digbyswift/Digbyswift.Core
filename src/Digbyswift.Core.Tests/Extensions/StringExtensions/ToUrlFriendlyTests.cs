using System;
using System.Text;
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

    [Test]
    public void ToUrlFriendly_Throws_WhenTheOutputEncodingIsNull()
    {
        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => "Hello".ToUrlFriendly(null));
    }

    [TestCase("Hello, World!", "hello-world")]
    [TestCase("John's blog", "johns-blog")]
    [TestCase("One / two? three#four&five", "one-two-three-four-five")]
    [TestCase("  one --- two  ", "one-two")]
    [TestCase("TITLE WITH SPACES", "title-with-spaces")]
    public void ToUrlFriendly_ReturnsAsciiFriendlySlug_WhenUsingDefaultEncoding(string input, string expectedResult)
    {
        // Act
        var result = input.ToUrlFriendly();

        // Assert
        Assert.That(result, Is.EqualTo(expectedResult));
    }

    [TestCase("café menu", "cafe-menu")]
    [TestCase("smörgåsbord", "smorgasbord")]
    [TestCase("crème brûlée", "creme-brulee")]
    [TestCase("東京 2026", "2026")]
    public void ToUrlFriendly_FoldsDiacriticsAndRemovesUnsupportedCharacters_WhenUsingAscii(string input, string expectedResult)
    {
        // Act
        var result = input.ToUrlFriendly(Encoding.ASCII);

        // Assert
        Assert.That(result, Is.EqualTo(expectedResult));
    }

    [TestCase("café menu", "cafe-menu")]
    [TestCase("東京 2026", "東京-2026")]
    public void ToUrlFriendly_PreservesSupportedUnicodeCharacters_WhenUsingUtf8(string input, string expectedResult)
    {
        // Act
        var result = input.ToUrlFriendly(Encoding.UTF8);

        // Assert
        Assert.That(result, Is.EqualTo(expectedResult));
    }
}
