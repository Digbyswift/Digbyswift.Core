using System;
using System.Collections.Generic;
using Digbyswift.Core.Extensions;
using NUnit.Framework;

namespace Digbyswift.Core.Tests.Extensions.EnumerableExtensions;

[TestFixture]
public class CountTests
{
    private readonly IEnumerable<int> _testNumericList = [11, 4, 6, 2, 9];

    [Test]
    public void CountIs_ReturnsTrue_WhenCountIsSameAsListCount()
    {
        // Arrange & Act
        var result = _testNumericList.CountIs(5);

        // Assert
        Assert.That(result, Is.True);
    }

    [Test]
    public void CountIs_ReturnsFalse_WhenCountIsNotSameAsListCount()
    {
        // Arrange
        IEnumerable<int> source = new List<int> { 11, 4, 6 };

        // Act
        var result = source.CountIs(5);

        // Assert
        Assert.That(result, Is.False);
    }

    [Test]
    public void CountIs_ThrowsException_WhenEnumerableIsNull()
    {
        // Arrange
        IEnumerable<int>? source = null;

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => source.CountIs(0));
    }

    [Test]
    public void CountIs_ThrowsException_WhenCountIsNegative()
    {
        // Arrange
        IEnumerable<int> source = new List<int> { 11, 4, 6 };

        // Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => source.CountIs(-10));
    }

    [Test]
    public void CountIsLowerThan_ReturnsTrue_WhenCountIsLowerThanListCount()
    {
        // Arrange & Act
        var result = _testNumericList.CountIsLt(10);

        // Assert
        Assert.That(result, Is.True);
    }

    [Test]
    public void CountIsLowerThan_ThrowsException_WhenEnumerableIsNull()
    {
        // Arrange
        IEnumerable<int>? source = null;

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => source.CountIsLt(0));
    }

    [Test]
    public void CountIsLowerThan_ThrowsException_WhenCountIsNegative()
    {
        // Arrange
        IEnumerable<int> source = new List<int> { 11, 4, 6 };

        // Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => source.CountIsLt(-10));
    }

    [Test]
    public void CountIsLowerThanOrEqual_ReturnsTrue_WhenCountIsLowerThanListCount()
    {
        // Arrange & Act
        var result = _testNumericList.CountIsLe(10);

        // Assert
        Assert.That(result, Is.True);
    }

    [Test]
    public void CountIsLowerThanOrEqual_ReturnsTrue_WhenCountIsEqualToListCount()
    {
        // Arrange & Act
        var result = _testNumericList.CountIsLe(5);

        // Assert
        Assert.That(result, Is.True);
    }

    [Test]
    public void CountIsLowerThanThanOrEqual_ThrowsException_WhenEnumerableIsNull()
    {
        // Arrange
        IEnumerable<int>? source = null;

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => source.CountIsLe(0));
    }

    [Test]
    public void CountIsLowerThanThanOrEqual_ThrowsException_WhenCountIsNegative()
    {
        // Arrange
        IEnumerable<int> source = new List<int> { 11, 4, 6 };

        // Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => source.CountIsLt(-10));
    }

    [Test]
    public void CountIsGreaterThan_ReturnsTrue_WhenCountIsHigherThanListCount()
    {
        // Arrange & Act
        var result = _testNumericList.CountIsGt(3);

        // Assert
        Assert.That(result, Is.True);
    }

    [Test]
    public void CountIsGreaterThan_ThrowsException_WhenEnumerableIsNull()
    {
        // Arrange
        IEnumerable<int>? source = null;

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => source.CountIsGt(0));
    }

    [Test]
    public void CountIsGreaterThan_ThrowsException_WhenCountIsNegative()
    {
        // Arrange
        IEnumerable<int> source = new List<int> { 11, 4, 6 };

        // Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => source.CountIsGt(-10));
    }

    [Test]
    public void CountIsGreaterThanOrEqual_ReturnsTrue_WhenCountIsHigherThanListCount()
    {
        // Arrange & Act
        var result = _testNumericList.CountIsGe(3);

        // Assert
        Assert.That(result, Is.True);
    }

    [Test]
    public void CountIsGreaterThanOrEqual_ReturnsTrue_WhenCountIsEqualToListCount()
    {
        // Arrange & Act
        var result = _testNumericList.CountIsGe(5);

        // Assert
        Assert.That(result, Is.True);
    }

    [Test]
    public void CountIsGreaterThanThanOrEqual_ThrowsException_WhenEnumerableIsNull()
    {
        // Arrange
        IEnumerable<int>? source = null;

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => source.CountIsGe(0));
    }
}
