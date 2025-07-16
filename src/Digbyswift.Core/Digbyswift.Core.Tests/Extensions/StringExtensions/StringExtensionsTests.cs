using Digbyswift.Core.Extensions;
using NUnit.Framework;

namespace Digbyswift.Core.Tests.Extensions.StringExtensions;

[TestFixture]
public class StringExtensionsTests
{
    private const string Testing = "Testing";
    private const string TestingContainingText = "Testing a string that contains text";

    [TestCase("", "")]
    [TestCase("testing lowercase string", "testing lowercase string")]
    [TestCase("Testing a string with Uppercased characters", "testing a string with uppercased characters")]
    public void EqualsIgnoreCase_ReturnsTrue_WhenStringIsMatch(string source, string stringToCompareAgainst)
    {
        // Arrange & Act
        var result = source.EqualsIgnoreCase(stringToCompareAgainst);

        // Assert
        Assert.That(result, Is.True);
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
    [TestCase("123Test./? ", "123Test")]
    [TestCase("123Test./?123 ", "123Test123")]
    public void RemoveNonWordCharacters_ReturnsString_WithNoNonWordCharacters(string source, string expectedResult)
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
}