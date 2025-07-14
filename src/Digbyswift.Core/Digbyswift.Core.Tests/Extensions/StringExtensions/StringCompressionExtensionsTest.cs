using Digbyswift.Core.Extensions;
using NUnit.Framework;

namespace Digbyswift.Core.Tests.Extensions.StringExtensions;

[TestFixture]
public class StringCompressionExtensionsTest
{
    [Test]
    public void Compress_ReturnsCompressedString_WhenGivenAnUncompressedString()
    {
        // Arrange
        var value = "Testing a string with spaces";
        var expectedResult = "H4sIAAAAAAAECgtJLS7JzEtXSFQoLikCMcozSzIUigsSk1OLAQgrK2QcAAAA";

        // Act
        var result = value.Compress();

        // Assert
        Assert.That(result, Is.EqualTo(expectedResult));
    }

    [Test]
    public void DeCompress_ReturnsUncompressedString_WhenGivenCompressedString()
    {
        // Arrange
        var value = "H4sIAAAAAAAECgtJLS7JzEtXSFQoLikCMcozSzIUigsSk1OLAQgrK2QcAAAA";
        var expectedResult = "Testing a string with spaces";

        // Act
        var result = value.Decompress();

        // Assert
        Assert.That(result, Is.EqualTo(expectedResult));
    }
}