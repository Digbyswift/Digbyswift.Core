using System;
using System.Collections.Generic;
using Digbyswift.Core.Extensions;
using NUnit.Framework;

namespace Digbyswift.Core.Tests.Extensions.EnumerableExtensions;

[TestFixture]
public class IsEmptyTests
{
    private const string Testing = "Testing";
    private const string TestingAgain = "Testing again";

    [Test]
    public void IsEmpty_ReturnsTrue_WhenListIsEmpty()
    {
        // Arrange
        IEnumerable<string> source = new List<string>();

        // Act
        var result = source.IsEmpty();

        // Assert
        Assert.IsTrue(result);
    }

    [Test]
    public void IsEmpty_ReturnsFalse_WhenListHasItems()
    {
        // Arrange
        IEnumerable<string> source = new List<string> { Testing, TestingAgain };

        // Act
        var result = source.IsEmpty();

        // Assert
        Assert.IsFalse(result);
    }

    [Test]
    public void IsEmpty_ReturnsFalse_WhenListContainsEmptyItems()
    {
        // Arrange
        IEnumerable<string> source = new List<string> { String.Empty, String.Empty, " " };

        // Act
        var result = source.IsEmpty();

        // Assert
        Assert.IsFalse(result);
    }

    [Test]
    public void IsEmpty_ReturnsFalse_WhenListContainsNullItems()
    {
        // Arrange
        IEnumerable<string> source = new List<string> { null, null };

        // Act
        var result = source.IsEmpty();

        // Assert
        Assert.IsFalse(result);
    }

    [Test]
    public void IsEmpty_ReturnsFalse_WhenListContainsSingleItem()
    {
        // Arrange
        IEnumerable<string> source = new List<string> { String.Empty };

        // Act
        var result = source.IsEmpty();

        // Assert
        Assert.IsFalse(result);
    }
}
