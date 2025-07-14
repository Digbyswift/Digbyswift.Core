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

    [TestCase("", "")]
    [TestCase("Testing", "Testing")]
    [TestCase("<p>Testing</p>", "Testing")]
    [TestCase("<p><span>Testing<span></p>", "Testing")]
    public void StripMarkup_ReturnsStringWithoutMarkup_IfMarkupIsPresent(string source, string expectedResult)
    {
        // Arrange & Act
        var result = source.StripMarkup();

        // Assert
        Assert.That(result, Is.EqualTo(expectedResult));
    }

    [TestCase("", "")]
    [TestCase("Tesst", "Tedt")]
    [TestCase("Tesst aagain", "Tedt aagain")]
    public void ReplaceExcess_ReturnsStringWithExcessCharacterReplaces_IfDuplicateCharacterIsPresent(string source, string expectedResult)
    {
        // Arrange & Act
        var result = source.ReplaceExcess('s', 'd');

        // Assert
        Assert.That(result, Is.EqualTo(expectedResult));
    }

    [TestCase("", "")]
    [TestCase("Test./?", "Test")]
    [TestCase("Test./? ", "Test")]
    [TestCase("123Test./? ", "Test")]
    [TestCase("123Test./?123 ", "Test")]
    public void RemoveNonWordCharacters_ReturnsString_WithNoNonAlphanumericCharacters(string source, string expectedResult)
    {
        // Arrange & Act
        var result = source.RemoveNonWordCharacters();

        // Assert
        Assert.That(result, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Base64Encode_ReturnsEncodedString()
    {
        // Arrange
        var expectedResult = "VGVzdGluZyBhIHN0cmluZyB0aGF0IGNvbnRhaW5zIHRleHQ=";

        // Act
        var result = TestingContainingText.Base64Encode();

        // Assert
        Assert.That(result, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Base64Decode_ReturnsDecodedString()
    {
        // Arrange
        var source = "VGVzdGluZyBhIHN0cmluZyB0aGF0IGNvbnRhaW5zIHRleHQ=";
        var expectedResult = TestingContainingText;

        // Act
        var result = source.Base64Decode();

        // Assert
        Assert.That(result, Is.EqualTo(expectedResult));
    }

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
        Assert.Throws<ArgumentOutOfRangeException>(
            () =>
            {
                TestingContainingText.MaskRight(-4);
            });
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
        Assert.Throws<ArgumentOutOfRangeException>(
            () =>
            {
                TestingContainingText.MaskLeft(-4);
            });
    }

    [TestCase(Testing, "testing")]
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

    [TestCase("True", true)]
    [TestCase("true", true)]
    public void ToBool_ReturnsTrue_WhenValueIsTrue(string source, bool expectedResult)
    {
        // Arrange & Act
        var result = source.ToBool(null);

        // Assert
        Assert.IsTrue(result);
    }

    [TestCase("False", false)]
    [TestCase("false", false)]
    public void ToBool_ReturnsFalse_WhenValueIsFalse(string source, bool expectedResult)
    {
        // Arrange & Act
        var result = source.ToBool(null);

        // Assert
        Assert.IsFalse(result);
    }

    [TestCase("", false)]
    [TestCase(Testing, false)]
    public void ToBool_ReturnsFalse_WhenValueIsEmptyOrInvalid(string source, bool expectedResult)
    {
        // Arrange & Act
        var result = source.ToBool(null);

        // Assert
        Assert.That(result, Is.EqualTo(expectedResult));
    }

    [TestCase("", false)]
    [TestCase(Testing, false)]
    public void ToBool_ReturnsDefault_WhenValueIsEmptyOrInvalid(string source, bool expectedResult)
    {
        // Arrange
        bool defaultValue = true;

        // Act
        var result = source.ToBool(defaultValue);

        // Assert
        Assert.IsTrue(result);
    }

    [TestCase("", false)]
    [TestCase(Testing, false)]
    public void ToBool_ReturnsFalse_WhenValueIsEmptyOrInvalid_AndNoDefaultSupplied(string source, bool expectedResult)
    {
        // Arrange & Act
        var result = source.ToBool(null);

        // Assert
        Assert.IsFalse(result);
    }

    [TestCase("", "")]
    [TestCase(Testing, "Testing")]
    [TestCase(TestingContainingText, "Testing A String That Contains Text")]
    public void CapitalizeWords_ReturnsString_WithCorrectCasing(string source, string expectedResult)
    {
        // Arrange & Act
        var result = source.CapitalizeWords();

        // Assert
        Assert.That(result, Is.EqualTo(expectedResult));
    }

    [Test]
    [Ignore("Test not implemented yet")]
    public void ToEnum()
    {
    }
}