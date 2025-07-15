using System;
using Digbyswift.Core.Extensions;
using NUnit.Framework;

namespace Digbyswift.Core.Tests.Extensions.StringExtensions;

[TestFixture]
public class MaskTests
{
    private const string Testing = "Testing";
    private const string TestingContainingText = "Testing a string that contains text";

    [TestCase(Testing, 10, "Testing")]
    [TestCase(TestingContainingText, 4, "Test*******************************")]
    public void MaskRight_ReturnsString_WithExpectedCharactersMasked(string source, int numberOfVisibleCharacters, string expectedResult)
    {
        // Arrange & Act
        var result = source.MaskRight(numberOfVisibleCharacters);

        // Assert
        Assert.That(result, Is.EqualTo(expectedResult));
    }

    [Test]
    public void MaskRight_ThrowsException_WhenNegativeCharactersVisible()
    {
        // Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => TestingContainingText.MaskRight(-4));
    }

    [TestCase(Testing, 10, "Testing")]
    [TestCase(TestingContainingText, 4, "*******************************text")]
    public void MaskLeft_ReturnsString_WithExpectedCharactersMasked(string source, int numberOfVisibleCharacters, string expectedResult)
    {
        // Arrange & Act
        var result = source.MaskLeft(numberOfVisibleCharacters);

        // Assert
        Assert.That(result, Is.EqualTo(expectedResult));
    }

    [Test]
    public void MaskLeft_ThrowsException_WhenNegativeCharactersVisible()
    {
        // Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => TestingContainingText.MaskLeft(-4));
    }
}