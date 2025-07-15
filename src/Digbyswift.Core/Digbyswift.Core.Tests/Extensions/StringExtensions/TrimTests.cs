using System;
using System.Collections.Generic;
using System.Linq;
using Digbyswift.Core.Extensions;
using NUnit.Framework;

namespace Digbyswift.Core.Tests.Extensions.StringExtensions;

[TestFixture]
public class TrimTests
{
    private const string TestingContainingText = "Testing a string that contains text";

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
        var result = source.SplitAndTrim().ToList();

        // Assert
        for (int i = 0; i < result.Count; i++)
        {
            Assert.That(result[i], Is.EqualTo(expectedResult[i]));
        }
    }
}