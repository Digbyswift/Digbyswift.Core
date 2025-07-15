using System;
using Digbyswift.Core.Extensions;
using NUnit.Framework;

namespace Digbyswift.Core.Tests.Extensions.StringExtensions;

[TestFixture]
public class StringCompressionExtensionsTest
{
    private const string TestingStringWithSpaces = "Testing a string with spaces";

    [Test]
    public void Compress_ReturnsCompressedString_WhenGivenSimpleString()
    {
        // Arrange
        var value = TestingStringWithSpaces;
        var expectedResult = "H4sIAAAAAAAECgtJLS7JzEtXSFQoLikCMcozSzIUigsSk1OLAQgrK2QcAAAA";

        // Act
        var result = value.Compress();

        // Assert
        Assert.That(result, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Compress_ReturnsEmptyString_WhenGivenAnEmptyString()
    {
        // Arrange & Act
        var result = String.Empty.Compress();

        // Assert
        Assert.That(result, Is.EqualTo(String.Empty));
    }

    [Test]
    public void Decompress_ReturnsUncompressedString_WhenGivenCompressedString()
    {
        // Arrange
        const string value = "H4sIAAAAAAAECgtJLS7JzEtXSFQoLikCMcozSzIUigsSk1OLAQgrK2QcAAAA";
        var expectedResult = TestingStringWithSpaces;

        // Act
        var result = value.Decompress();

        // Assert
        Assert.That(result, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Decompress_ReturnsEmptyString_WhenGivenAnEmptyString()
    {
        // Arrange & Act
        var result = String.Empty.Decompress();

        // Assert
        Assert.That(result, Is.EqualTo(String.Empty));
    }

    [Test]
    public void CompressProcess_ReturnsOriginalString_WhenGivenSimpleString()
    {
        // Arrange
        var value = TestingStringWithSpaces;
        var expectedResult = TestingStringWithSpaces;

        // Act
        var compressionResult = value.Compress();
        var decrompressedResult = compressionResult.Decompress();

        // Assert
        Assert.That(decrompressedResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void CompressProcess_ReturnsEmptyString_WhenGivenEmptyString()
    {
        // Arrange & Act
        var compressionResult = String.Empty.Compress();
        var decrompressedResult = compressionResult.Decompress();

        // Assert
        Assert.That(decrompressedResult, Is.EqualTo(String.Empty));
    }

    [Test]
    public void CompressProcess_ReturnsOriginalString_WhenGivenComplexString()
    {
        // Arrange
        const string value = "Morbi commodo sapien non convallis tempor. Mauris id volutpat elit, vel tristique est. Etiam efficitur nibh vitae ipsum euismod, sit amet semper eros euismod. Quisque id tristique nisl, et varius nulla. Nulla scelerisque tellus non purus facilisis, vitae placerat urna mollis. Integer et placerat enim, at feugiat tellus. Integer elementum tellus et tempus maximus. Donec ac sodales elit. Maecenas eu iaculis lectus. Etiam sit amet turpis ligula. Vivamus vehicula nisi nec ornare iaculis.\r\n\r\nPhasellus tincidunt rutrum turpis at ullamcorper. Pellentesque dapibus sodales eros, vel feugiat purus aliquam non. Quisque pharetra convallis maximus. Morbi dui neque, malesuada sed ipsum vitae, tincidunt placerat ligula. Mauris pretium ac felis posuere accumsan. Praesent molestie aliquet sem finibus porttitor. Aliquam convallis, ex in auctor efficitur, ante sapien dictum ante, a congue turpis orci non quam.";

        // Act
        var compressionResult = value.Compress();
        var decrompressedResult = compressionResult.Decompress();

        // Assert
        Assert.That(decrompressedResult, Is.EqualTo(value));
    }

    [Test]
    public void CompressProcess_ReturnsOriginalString_WhenGivenStringWithMarkup()
    {
        // Arrange
        const string value = "<p>Morbi commodo <span><strong>sapien non convallis</strong></span> tempor. Mauris id volutpat elit, vel tristique est. Etiam efficitur nibh vitae ipsum euismod, sit amet semper eros euismod. Quisque id tristique nisl, et varius nulla. Nulla scelerisque tellus non purus facilisis, vitae placerat urna mollis</p>";

        // Act
        var compressionResult = value.Compress();
        var decrompressedResult = compressionResult.Decompress();

        // Assert
        Assert.That(decrompressedResult, Is.EqualTo(value));
    }
}