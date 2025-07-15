using System;
using System.Collections.Generic;
using Digbyswift.Core.Extensions;
using NUnit.Framework;

namespace Digbyswift.Core.Tests.Extensions;

[TestFixture]
public class EnumerableExtensionsTest
{
    private readonly IEnumerable<int> _testNumericList = [11, 4, 6, 2, 9];

    [Test]
    public void NotContains_ReturnsFalse_WhenListContainsMatch()
    {
        // Arrange
        IEnumerable<string> source = new List<string> { "Testing", "Testing again" };

        // Act
        var result = source.NotContains("Testing");

        // Assert
        Assert.IsFalse(result);
    }

    [Test]
    public void NotContains_ReturnsTrue_WhenListDoesNotContainMatch()
    {
        // Arrange
        IEnumerable<string> source = new List<string> { "Testing", "Testing again" };

        // Act
        var result = source.NotContains("Test");

        // Assert
        Assert.IsTrue(result);
    }

    [Test]
    public void NotContains_ReturnsTrue_WhenListIsEmpty()
    {
        // Arrange
        IEnumerable<string> source = new List<string>();

        // Act
        var result = source.NotContains("Test");

        // Assert
        Assert.IsTrue(result);
    }

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
        IEnumerable<string> source = new List<string> { "Testing", "Testing again" };

        // Act
        var result = source.IsEmpty();

        // Assert
        Assert.IsFalse(result);
    }

    [Test]
    public void WhereNotNull_ReturnsListWithoutNulls_WhenListHasItems()
    {
        // Arrange
        IEnumerable<string> source = new List<string> { "Testing", null, "Testing again", null, "Third Test" };
        IEnumerable<string> expectedResult = new List<string> { "Testing", "Testing again", "Third Test" };

        // Act
        var result = source.WhereNotNull();

        // Assert
        Assert.AreEqual(result, expectedResult);
    }

    [Test]
    public void None_ReturnsException_WhenSourceIsNull()
    {
        // Arrange
        IEnumerable<string>? source = null;

        // Act & Assert
        Assert.Throws<ArgumentNullException>(
            () =>
            {
                source.None(_ => false);
            });
    }

    [Test]
    [Ignore("Test yet to be implemented")]
    public void None_ReturnsException_WhenFunctionIsNull()
    {
    }

    [Test]
    public void MinOrDefault_ReturnsLowestItemInSequence()
    {
        // Arrange & Act
        var result = _testNumericList.MinOrDefault();

        // Assert
        Assert.AreEqual(result, 2);
    }

    [Test]
    public void MinOrDefault_ReturnsException_WhenEnumerableIsNull()
    {
        // Arrange
        IEnumerable<int>? source = null;

        // Act & Assert
        Assert.Throws<ArgumentNullException>(
            () =>
            {
                source.MinOrDefault();
            });
    }

    [Test]
    public void MaxOrDefault_ReturnsHighestItemInSequence()
    {
        // Arrange & Act
        var result = _testNumericList.MaxOrDefault();

        // Assert
        Assert.AreEqual(result, 11);
    }

    [Test]
    public void MaxOrDefault_ReturnsException_WhenEnumerableIsNull()
    {
        // Arrange
        IEnumerable<int>? source = null;

        // Act & Assert
        Assert.Throws<ArgumentNullException>(
            () =>
            {
                source.MaxOrDefault();
            });
    }

    [Test]
    public void CountIs_ReturnsTrue_WhenCountIsSameAsListCount()
    {
        // Arrange & Act
        var result = _testNumericList.CountIs(5);

        // Assert
        Assert.IsTrue(result);
    }

    [Test]
    public void CountIs_ReturnsFalse_WhenCountIsNotSameAsListCount()
    {
        // Arrange
        IEnumerable<int> source = new List<int> { 11, 4, 6 };

        // Act
        var result = source.CountIs(5);

        // Assert
        Assert.IsFalse(result);
    }

    [Test]
    public void CountIs_ReturnsException_WhenEnumerableIsNull()
    {
        // Arrange
        IEnumerable<int>? source = null;

        // Act & Assert
        Assert.Throws<ArgumentNullException>(
            () =>
            {
                source.CountIs(0);
            });
    }

    [Test]
    public void CountIs_ReturnsException_WhenCountIsNegative()
    {
        // Arrange
        IEnumerable<int> source = new List<int> { 11, 4, 6 };

        // Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>(
            () =>
            {
                source.CountIs(-10);
            });
    }

    [Test]
    public void CountIsLowerThan_ReturnsTrue_WhenCountIsLowerThanListCount()
    {
        // Arrange & Act
        var result = _testNumericList.CountIsLt(10);

        // Assert
        Assert.IsTrue(result);
    }

    [Test]
    public void CountIsLowerThan_ReturnsException_WhenEnumerableIsNull()
    {
        // Arrange
        IEnumerable<int>? source = null;

        // Act & Assert
        Assert.Throws<ArgumentNullException>(
            () =>
            {
                source.CountIsLt(0);
            });
    }

    [Test]
    public void CountIsLowerThan_ReturnsException_WhenCountIsNegative()
    {
        // Arrange
        IEnumerable<int> source = new List<int> { 11, 4, 6 };

        // Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>(
            () =>
            {
                source.CountIsLt(-10);
            });
    }

    [Test]
    public void CountIsLowerThanOrEqual_ReturnsTrue_WhenCountIsLowerThanListCount()
    {
        // Arrange & Act
        var result = _testNumericList.CountIsLe(10);

        // Assert
        Assert.IsTrue(result);
    }

    [Test]
    public void CountIsLowerThanOrEqual_ReturnsTrue_WhenCountIsEqualToListCount()
    {
        // Arrange & Act
        var result = _testNumericList.CountIsLe(5);

        // Assert
        Assert.IsTrue(result);
    }

    [Test]
    public void CountIsLowerThanThanOrEqual_ReturnsException_WhenEnumerableIsNull()
    {
        // Arrange
        IEnumerable<int>? source = null;

        // Act & Assert
        Assert.Throws<ArgumentNullException>(
            () =>
            {
                source.CountIsLe(0);
            });
    }

    [Test]
    public void CountIsLowerThanThanOrEqual_ReturnsException_WhenCountIsNegative()
    {
        // Arrange
        IEnumerable<int> source = new List<int> { 11, 4, 6 };

        // Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>(
            () =>
            {
                source.CountIsLt(-10);
            });
    }

    [Test]
    public void CountIsGreaterThan_ReturnsTrue_WhenCountIsHigherThanListCount()
    {
        // Arrange & Act
        var result = _testNumericList.CountIsGt(3);

        // Assert
        Assert.IsTrue(result);
    }

    [Test]
    public void CountIsGreaterThan_ReturnsException_WhenEnumerableIsNull()
    {
        // Arrange
        IEnumerable<int>? source = null;

        // Act & Assert
        Assert.Throws<ArgumentNullException>(
            () =>
            {
                source.CountIsGt(0);
            });
    }

    [Test]
    public void CountIsGreaterThan_ReturnsException_WhenCountIsNegative()
    {
        // Arrange
        IEnumerable<int> source = new List<int> { 11, 4, 6 };

        // Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>(
            () =>
            {
                source.CountIsGt(-10);
            });
    }

    [Test]
    public void CountIsGreaterThanOrEqual_ReturnsTrue_WhenCountIsHigherThanListCount()
    {
        // Arrange & Act
        var result = _testNumericList.CountIsGe(3);

        // Assert
        Assert.IsTrue(result);
    }

    [Test]
    public void CountIsGreaterThanOrEqual_ReturnsTrue_WhenCountIsEqualToListCount()
    {
        // Arrange & Act
        var result = _testNumericList.CountIsGe(5);

        // Assert
        Assert.IsTrue(result);
    }

    [Test]
    public void CountIsGreaterThanThanOrEqual_ReturnsException_WhenEnumerableIsNull()
    {
        // Arrange
        IEnumerable<int>? source = null;

        // Act & Assert
        Assert.Throws<ArgumentNullException>(
            () =>
            {
                source.CountIsGe(0);
            });
    }

    [Test]
    [Ignore("Test yet to be implemented")]
    public void SkipLast_ReturnsException_WhenSourceIsNull()
    {
    }

    [Test]
    [Ignore("Test yet to be implemented")]
    public void SkipLast()
    {
    }
}
