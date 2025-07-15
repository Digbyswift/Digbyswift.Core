using System;
using Digbyswift.Core.Extensions;
using NUnit.Framework;

namespace Digbyswift.Core.Tests.Extensions.StringExtensions;

[TestFixture]
public class CoalesceTests
{
    private const string Testing = "Testing";
    private const string TestingFallback = "Testing Fallback";

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
}