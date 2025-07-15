using System;
using System.Collections.Generic;
using System.Linq;
using Digbyswift.Core.Extensions;
using Digbyswift.Core.Tests.Mocks;
using NUnit.Framework;

namespace Digbyswift.Core.Tests.Extensions.StringExtensions;

[TestFixture]
public class TruncateTests
{
    private const string TestingContainingText = "Testing a string that contains text";

    [Test]
    public void Truncate_ReturnsString_OfSpecifiedLength()
    {
        // Arrange
        const string expectedResult = "Testing a string";

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
        Assert.Throws<ArgumentOutOfRangeException>(() => TestingContainingText.Truncate(-20));
    }

    [Test]
    public void Truncate_ReturnsString_OfSpecifiedLength_WithSuffix()
    {
        // Arrange
        const string expectedResult = "Testing a string...";

        // Act
        var result = TestingContainingText.Truncate(16, "...");

        // Assert
        Assert.IsTrue(result == expectedResult);
    }

    [Test]
    public void Truncate_ReturnsString_EndingAtSpecifiedWord()
    {
        // Arrange
        const string expectedResult = "Testing a";

        // Act
        var result = TestingContainingText.TruncateAtWord(12);

        // Assert
        Assert.IsTrue(result == expectedResult);
    }

    [Test]
    public void TruncateAtWord_ReturnsString_EndingAtSpecifiedWord_WithSuffix()
    {
        // Arrange
        const string expectedResult = "Testing a...";

        // Act
        var result = TestingContainingText.TruncateAtWord(12, "...");

        // Assert
        Assert.IsTrue(result == expectedResult);
    }
}