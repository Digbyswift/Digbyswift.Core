using System;
using System.Collections.Generic;
using System.Linq;
using Digbyswift.Core.Extensions;
using NUnit.Framework;

namespace Digbyswift.Core.Tests.Extensions.StringExtensions;

[TestFixture]
public class StringExtensionsTest
{
    private const string Testing = "Testing";
    private const string TestingLowercase = "testing";
    private const string TestingFallback = "Testing Fallback";
    private const string TestingContainingText = "Testing a string that contains text";

    [TestCase("", "")]
    [TestCase("testing lowercase string", "testing lowercase string")]
    [TestCase("Testing a string with Uppercased characters", "testing a string with uppercased characters")]
    public void EqualsIgnoreCase_ReturnsTrue_WhenStringIsMatch(string source, string stringToCompareAgainst)
    {
        // Arrange & Act
        var result = source.EqualsIgnoreCase(stringToCompareAgainst);

        // Assert
        Assert.IsTrue(result);
    }

    [Test]
    public void Coalesce_ReturnsExpectedString_WhenSourceHasValue()
    {
        // Arrange
        var source = Testing;
        var fallback = TestingFallback;

        // Act
        var result = source.Coalesce(fallback);

        // Assert
        Assert.That(result.Equals("Testing"));
    }

    [Test]
    public void Coalesce_ReturnsFallbackString_WhenSourceHasNoValue()
    {
        // Arrange
        var source = String.Empty;
        var fallback = TestingFallback;

        // Act
        var result = source.Coalesce(fallback);

        // Assert
        Assert.That(result.Equals("Testing Fallback"));
    }

    [Test]
    public void Coalesce_ReturnsFallbackString_WhenSourceIsNull()
    {
        // Arrange
        string? source = null;
        var fallback = TestingFallback;

        // Act
        var result = source.Coalesce(fallback);

        // Assert
        Assert.That(result.Equals("Testing Fallback"));
    }

    [Test]
    public void Coalesce_ReturnsEmptyString_WhenSourceIsNullAndFallbackIsEmpty()
    {
        // Arrange
        string? source = null;
        var fallback = string.Empty;

        // Act
        var result = source.Coalesce(fallback);

        // Assert
        Assert.That(result.Equals(String.Empty));
    }

    [Test]
    public void Contains_ReturnsTrue_WhenValueIsWithinSource()
    {
        // Arrange & Act
        var result = TestingContainingText.Contains(TestingLowercase);

        // Assert
        Assert.IsTrue(result);
    }

    [Test]
    public void Contains_ReturnsTrue_WhenValueIsWithinSourceWord()
    {
        // Arrange
        var match = "ring";

        // Act
        var result = TestingContainingText.Contains(match);

        // Assert
        Assert.IsTrue(result);
    }

    [Test]
    public void Contains_ReturnsFalse_WhenValueIsWithinSource_ButNotTheSameCase()
    {
        // Arrange
        string? source = TestingContainingText;

        // Act
        var result = source.Contains(TestingLowercase);

        // Assert
        Assert.IsFalse(result);
    }

    [Test]
    public void Contains_ReturnsTrue_WhenValueIsWithinSource_ButNotTheSameCase_AndOrdinalCaseSpecified()
    {
        // Arrange & Act
        var result = TestingContainingText.Contains(TestingLowercase, StringComparison.OrdinalIgnoreCase);

        // Assert
        Assert.IsTrue(result);
    }

    [Test]
    public void ContainsIgnoreCase_ReturnsTrue_WhenValueIsWithinSource()
    {
        // Arrange
        string? source = TestingContainingText;
        var match = "text";

        // Act
        var result = source.ContainsIgnoreCase(match);

        // Assert
        Assert.IsTrue(result);
    }

    [Test]
    public void ContainsIgnoreCase_ReturnsTrue_WhenValueIsWithinSourceWord()
    {
        // Arrange
        string? source = TestingContainingText;
        var match = "ring";

        // Act
        var result = source.ContainsIgnoreCase(match);

        // Assert
        Assert.IsTrue(result);
    }

    [Test]
    public void ContainsIgnoreCase_ReturnsTrue_WhenValueIsWithinList()
    {
        // Arrange
        var source = new List<string>
        {
            TestingContainingText,
            String.Empty,
            "Testing another"
        };

        var match = "another";

        // Act
        var result = source.ContainsIgnoreCase(match);

        // Assert
        Assert.IsTrue(result);
    }

    [Test]
    public void ContainsIgnoreCase_ReturnsTrue_WhenPhraseIsWithinList()
    {
        // Arrange
        var source = new List<string>
        {
            TestingContainingText,
            String.Empty,
            "Testing another"
        };

        var match = "Testing another";

        // Act
        var result = source.ContainsIgnoreCase(match);

        // Assert
        Assert.IsTrue(result);
    }

    [Test]
    public void ContainsIgnoreCase_ReturnsTrue_WhenValueIsWithinWord_WithinListOfWords()
    {
        // Arrange
        var source = new List<string>
        {
            TestingContainingText,
            String.Empty,
            "Testing another"
        };

        var match = "ring";

        // Act
        var result = source.ContainsIgnoreCase(match);

        // Assert
        Assert.IsTrue(result);
    }

    [Test]
    public void Truncate_ReturnsString_OfSpecifiedLength()
    {
        // Arrange
        var expectedResult = "Testing a string";

        // Act
        var result = TestingContainingText.Truncate(16);

        // Assert
        Assert.IsTrue(result == expectedResult);
    }

    [Test]
    public void Truncate_ThrowsException_IfNegativeSpecifiedLength()
    {
        // Arrange

        // Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>(
            () =>
            {
                TestingContainingText.Truncate(-20);
            });
    }

    [Test]
    public void Truncate_ReturnsString_OfSpecifiedLength_WithSuffix()
    {
        // Arrange
        var expectedResult = "Testing a string...";

        // Act
        var result = TestingContainingText.Truncate(16, "...");

        // Assert
        Assert.IsTrue(result == expectedResult);
    }

    [Test]
    public void Truncate_ReturnsString_EndingAtSpecifiedWord()
    {
        // Arrange
        var expectedResult = "Testing a";

        // Act
        var result = TestingContainingText.TruncateAtWord(12);

        // Assert
        Assert.IsTrue(result == expectedResult);
    }

    [Test]
    public void TruncateAtWord_ReturnsString_EndingAtSpecifiedWord_WithSuffix()
    {
        // Arrange
        var expectedResult = "Testing a...";

        // Act
        var result = TestingContainingText.TruncateAtWord(12, "...");

        // Assert
        Assert.IsTrue(result == expectedResult);
    }

    [Test]
    public void TrimWithin_ReturnsString_WithDuplicateSpacesRemoved()
    {
        // Arrange
        var source = "Testing  a string that contains  text";
        var expectedResult = "Testing a string that contains text";

        // Act
        var result = source.TrimWithin();

        // Assert
        Assert.IsTrue(result == expectedResult);
    }

    [Test]
    public void TrimWithin_ReturnsEmptyString_WhenSourceIsEmpty()
    {
        // Arrange
        var source = String.Empty;
        var expectedResult = String.Empty;

        // Act
        var result = source.TrimWithin();

        // Assert
        Assert.IsTrue(result == expectedResult);
    }

    [Test]
    public void TrimToNull_ReturnsString_WithDuplicateSpacesRemoved()
    {
        // Arrange
        var source = "Testing  a string that contains  text";
        var expectedResult = "Testing a string that contains text";

        // Act
        var result = source.TrimToNull();

        // Assert
        Assert.IsTrue(result == expectedResult);
    }

    [Test]
    public void TrimToNull_ReturnsNull_WhenOnlyWhitespaceRemains()
    {
        // Arrange
        var source = "    ";

        // Act
        var result = source.TrimToNull();

        // Assert
        Assert.IsNull(result);
    }

    [Test]
    public void TrimToNull_ReturnsNull_WhenPassedEmptyString()
    {
        // Arrange
        var source = String.Empty;

        // Act
        var result = source.TrimToNull();

        // Assert
        Assert.IsNull(result);
    }

    [Test]
    public void TrimToDefault_ReturnsString_WithDuplicateSpacesRemoved()
    {
        // Arrange
        var source = "Testing  a string that contains  text";
        var expectedResult = "Testing a string that contains text";

        // Act
        var result = source.TrimToDefault();

        // Assert
        Assert.IsTrue(result == expectedResult);
    }

    [Test]
    public void TrimToDefault_ReturnsNull_WhenOnlyWhitespaceRemains_AndNoDefaultProvided()
    {
        // Arrange
        var source = "    ";

        // Act
        var result = source.TrimToDefault();

        // Assert
        Assert.IsNull(result);
    }

    [Test]
    public void TrimToDefault_ReturnsDefault_WhenOnlyWhitespaceRemains()
    {
        // Arrange
        var source = "    ";

        // Act
        var result = source.TrimToDefault("Default string");

        // Assert
        Assert.IsNull(result);
    }

    [Test]
    public void TrimToDefault_ReturnsNull_WhenPassedEmptyString()
    {
        // Arrange
        var source = String.Empty;

        // Act
        var result = source.TrimToDefault();

        // Assert
        Assert.IsNull(result);
    }

    [Test]
    public void SplitAndTrim_ReturnsListOfStrings_WithNoWhiteSpace()
    {
        // Arrange
        var source = TestingContainingText;
        var expectedResult = new List<string> { "Testing", "a", "string", "that", "contains", "text" };

        // Act
        var result = source.SplitAndTrim()?.ToList();

        // Assert
        for (int i = 0; i < result.Count; i++)
        {
            Assert.That(result[i], Is.EqualTo(expectedResult[i]));
        }
    }

    [Test]
    public void RemoveWhitespace_ReturnsString_WithNoWhiteSpace()
    {
        // Arrange
        var expectedResult = "Testingastringthatcontainstext";

        // Act
        var result = TestingContainingText.RemoveWhitespace();

        // Assert
        Assert.That(result, Is.EqualTo(expectedResult));
    }

    [Test]
    [Ignore("Test not implemented yet")]
    public void StripMarkup()
    {
    }

    [Test]
    [Ignore("Test not implemented yet")]
    public void ReplaceExcess()
    {
    }

    [Test]
    [Ignore("Test not implemented yet")]
    public void RemoveNonWordCharacters()
    {
    }

    [Test]
    [Ignore("Test not implemented yet")]
    public void Base64Encode()
    {
    }

    [Test]
    [Ignore("Test not implemented yet")]
    public void MaskRight()
    {
    }

    [Test]
    [Ignore("Test not implemented yet")]
    public void MaskLeft()
    {
    }

    [Test]
    [Ignore("Test not implemented yet")]
    public void ToUrlFriendly()
    {
    }

    [Test]
    [Ignore("Test not implemented yet")]
    public void ToBool()
    {
    }

    [Test]
    [Ignore("Test not implemented yet")]
    public void CapitalizeWords()
    {
    }

    [Test]
    [Ignore("Test not implemented yet")]
    public void ToEnum()
    {
    }
}