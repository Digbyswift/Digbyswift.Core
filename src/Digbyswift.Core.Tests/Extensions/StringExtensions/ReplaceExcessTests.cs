using Digbyswift.Core.Constants;
using Digbyswift.Core.Extensions;
using NUnit.Framework;

namespace Digbyswift.Core.Tests.Extensions.StringExtensions;

[TestFixture]
public class ReplaceExcessTests
{
#pragma warning disable S4144
    [TestCase("", "")]
    [TestCase(" ", " ")]
    [TestCase("x ", "x ")]
    [TestCase(" x", " x")]
    [TestCase(" x ", " x ")]
    [TestCase("x x x", "x x x")]
    [TestCase(" x x ", " x x ")]
    public void ReplaceExcess_DoesNotReplaceCharacters_WhenTheCharacterIsNotRepeated(string input, string expectedResult)
    {
        // Act
        var result = input.ReplaceExcess(CharConstants.Space, CharConstants.Hyphen);

        // Assert
        Assert.That(result, Is.EqualTo(expectedResult));
    }

    [TestCase("  ", "-")]
    [TestCase("     ", "-")]
    [TestCase("x     ", "x-")]
    [TestCase("     x", "-x")]
    [TestCase("   x   ", "-x-")]
    [TestCase("x     x", "x-x")]
    [TestCase("x   x   x", "x-x-x")]
    [TestCase("   x   x   ", "-x-x-")]
    public void ReplaceExcess_ReplacesCharactersWithASingleCharacter_WhenTheCharacterIsRepeated(string input, string expectedResult)
    {
        // Act
        var result = input.ReplaceExcess(CharConstants.Space, CharConstants.Hyphen);

        // Assert
        Assert.That(result, Is.EqualTo(expectedResult));
    }

    [TestCase(@"\\", "-")]
    [TestCase(@"\\\\", "-")]
    [TestCase(@"x\\\\\", "x-")]
    [TestCase(@"\\\\\x", "-x")]
    [TestCase(@"\\\x\\\", "-x-")]
    [TestCase(@"x\\\\\x", "x-x")]
    [TestCase(@"x\\\x\\\x", "x-x-x")]
    [TestCase(@"\\\x\\\x\\\", "-x-x-")]
    public void ReplaceExcess_ReplacesCharactersWithASingleCharacter_WhenTheCharacterIsAnEscapedBackslashAndRepeated(string input, string expectedResult)
    {
        // Act
        var result = input.ReplaceExcess(CharConstants.BackSlash, CharConstants.Hyphen);

        // Assert
        Assert.That(result, Is.EqualTo(expectedResult));
    }
#pragma warning restore S4144

    [TestCase("??", "-")]
    [TestCase("????", "-")]
    [TestCase(@"x????", "x-")]
    [TestCase(@"????x", "-x")]
    [TestCase(@"???x???", "-x-")]
    [TestCase(@"x?????x", "x-x")]
    [TestCase(@"x???x???x", "x-x-x")]
    [TestCase(@"???x???x???", "-x-x-")]
    public void ReplaceExcess_ReplacesCharactersWithASingleCharacter_WhenTheCharacterIsReservedAndRepeated(string input, string expectedResult)
    {
        // Act
        var result = input.ReplaceExcess(CharConstants.QuestionMark, CharConstants.Hyphen);

        // Assert
        Assert.That(result, Is.EqualTo(expectedResult));
    }

    [Test]
    public void ReplaceExcess_DoesntReplaceCharactersWithASingleCharacter_WhenTheCharacterIsAnEscapedBackslash()
    {
        // Arrange
        const string input = "\\";

        // Act
        var result = input.ReplaceExcess(CharConstants.BackSlash, CharConstants.Hyphen);

        // Assert
        Assert.That(result, Is.EqualTo(input));
    }
}
