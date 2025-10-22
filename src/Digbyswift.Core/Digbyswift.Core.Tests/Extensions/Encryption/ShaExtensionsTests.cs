using System;
using Digbyswift.Core.Extensions.Encryption;
using NUnit.Framework;

namespace Digbyswift.Core.Tests.Extensions.Encryption;

[TestFixture]
public class ShaExtensionsTests
{
    [Test]
    public void ToSHA1Hash_ReturnsValueDifferentToOriginal_WhenEmpty()
    {
        // Act
        var result = String.Empty.ToSHA1Hash();

        // Assert
        Assert.That(result, Is.Not.EqualTo(String.Empty));
    }

    [Test]
    public void ToSHA1Hash_ReturnsValueDifferentToOriginal_WhenNotEmpty()
    {
        // Arrange
        const string text = "Some test text";

        // Act
        var result = text.ToSHA1Hash();

        // Assert
        Assert.That(result, Is.Not.EqualTo(text));
    }

    [Test]
    public void ToSHA1Hash_ReturnsEqualValue_WhenRepeated()
    {
        // Arrange
        const string text = "Some test text";

        // Act
        var hash1 = text.ToSHA1Hash();
        var hash2 = text.ToSHA1Hash();

        // Assert
        Assert.That(hash1, Is.EqualTo(hash2));
    }
}
