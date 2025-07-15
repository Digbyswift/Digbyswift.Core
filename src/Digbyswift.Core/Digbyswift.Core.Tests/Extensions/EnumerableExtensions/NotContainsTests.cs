using System;
using System.Collections.Generic;
using Digbyswift.Core.Extensions;
using NUnit.Framework;

namespace Digbyswift.Core.Tests.Extensions.EnumerableExtensions;

[TestFixture]
public class NotContainsTests
{
    private const string Test = "Test";
    private const string Testing = "Testing";
    private const string TestingAgain = "Testing again";

    [Test]
    public void NotContains_ReturnsFalse_WhenListContainsMatch()
    {
        // Arrange
        IEnumerable<string> source = new List<string> { Testing, TestingAgain };

        // Act
        var result = source.NotContains(Testing);

        // Assert
        Assert.IsFalse(result);
    }

    [Test]
    public void NotContains_ReturnsTrue_WhenListDoesNotContainMatch()
    {
        // Arrange
        IEnumerable<string> source = new List<string> { Testing, TestingAgain };

        // Act
        var result = source.NotContains(Test);

        // Assert
        Assert.IsTrue(result);
    }

    [Test]
    public void NotContains_ReturnsTrue_WhenListIsEmpty()
    {
        // Arrange
        IEnumerable<string> source = new List<string>();

        // Act
        var result = source.NotContains(Test);

        // Assert
        Assert.IsTrue(result);
    }

    [Test]
    public void NotContains_ReturnsTrue_WhenListContainsEmptyItems()
    {
        // Arrange
        IEnumerable<string> source = new List<string> { String.Empty, String.Empty, " " };

        // Act
        var result = source.NotContains(Test);

        // Assert
        Assert.IsTrue(result);
    }

    [Test]
    public void NotContains_ReturnsTrue_WhenListContainsNullItems()
    {
        // Arrange
        IEnumerable<string> source = new List<string> { null, null };

        // Act
        var result = source.NotContains(Test);

        // Assert
        Assert.IsTrue(result);
    }
}
