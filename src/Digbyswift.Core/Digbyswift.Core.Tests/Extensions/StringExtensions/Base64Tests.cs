using Digbyswift.Core.Extensions;
using NUnit.Framework;

namespace Digbyswift.Core.Tests.Extensions.StringExtensions;

[TestFixture]
public class Base64Tests
{
    private const string TestingContainingText = "Testing a string that contains text";

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
}