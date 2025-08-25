using System;
using Digbyswift.Core.Extensions;
using Digbyswift.Core.Tests.Mocks;
using NUnit.Framework;

namespace Digbyswift.Core.Tests.Extensions.StringExtensions;

[TestFixture]
public class ToEnumTests
{
    [TestCase]
    public void ToEnum_ReturnsEnum_WhenMatchingDescription()
    {
        // Arrange
        const string source = "Test";

        // Act
        var result = source.ToEnum<TestEnum>();

        // Assert
        Assert.That(TestEnum.Test, Is.EqualTo(result));
    }

    [TestCase]
    public void ToEnum_ReturnsDefaultEnum_WhenNoDescription()
    {
        // Arrange & Act
        var result = String.Empty.ToEnum<TestEnum>();

        // Assert
        Assert.That(TestEnum.Test, Is.EqualTo(result));
    }

    [TestCase]
    public void ToEnum_ThrowsArgumentException_WhenNotMatchingDescription()
    {
        // Arrange
        const string source = "Testing";

        // Act & Assert
        Assert.Throws<ArgumentException>(() => source.ToEnum<TestEnum>());
    }
}