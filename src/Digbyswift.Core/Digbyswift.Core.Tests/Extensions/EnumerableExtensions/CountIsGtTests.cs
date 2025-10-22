using System;
using System.Collections.Generic;
using System.Linq;
using Digbyswift.Core.Extensions;
using NUnit.Framework;

namespace Digbyswift.Core.Tests.Extensions.EnumerableExtensions;

[TestFixture]
public class CountIsGtTests
{
#if NET48
    [Test]
    public void CountIsGt_ThrowsArgumentNullException_WhenSourceIsNull()
    {
        // Arrange
        IEnumerable<int> source = null;

        // Assert
        Assert.Throws<ArgumentNullException>(() =>
        {
            var result = source.CountIsGt(1);
        });
    }
#endif

    [Test]
    public void CountIsGt_ReturnsTrue_WhenQueriedCountIsLessThanZero()
    {
        // Act
        var source = Enumerable.Empty<int>();

        // Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => source.CountIsGt(-1));
    }

    [Test]
    public void CountIsGt_ReturnsFalse_WhenSourceIsEmptyAndQueriedCountIsZero()
    {
        // Arrange
        var source = Enumerable.Empty<int>();

        // Act
        var result = source.CountIsGt(0);

        // Assert
        Assert.That(result, Is.False);
    }

    [TestCase(0)]
    [TestCase(1)]
    [TestCase(10)]
    public void CountIsGt_ReturnsFalse_WhenSourceIsEmptyAndQueriedCountIsGreaterThanZero(int queriedCount)
    {
        // Arrange
        var source = Enumerable.Empty<int>();

        // Act
        var result = source.CountIsGt(queriedCount);

        // Assert
        Assert.That(result, Is.False);
    }

    [TestCase(1)]
    [TestCase(2)]
    [TestCase(10)]
    public void CountIsGt_ReturnsTrue_WhenSourceSizeIsGreaterThanQueriedCount(int queriedCount)
    {
        // Arrange
        var source = Enumerable.Range(0, queriedCount + 1);

        // Act
        var result = source.CountIsGt(queriedCount);

        // Assert
        Assert.That(source.Count(), Is.GreaterThan(queriedCount));
        Assert.That(result, Is.True, () => $"Source count: {source.Count()}, Queried count: {queriedCount}");
    }

    [TestCase(1)]
    [TestCase(2)]
    [TestCase(10)]
    public void CountIsGt_ReturnsFalse_WhenSourceSizeIsLessThanQueriedCount(int sourceSize)
    {
        // Arrange
        var source = Enumerable.Repeat(Char.MinValue, sourceSize - 1);

        // Act
        var result = source.CountIsGt(sourceSize);

        // Assert
        Assert.That(result, Is.False, () => $"Expected: {sourceSize}, Actual: {source.Count()}");
    }

    [TestCase(1)]
    [TestCase(2)]
    [TestCase(10)]
    public void CountIsGt_ReturnsFalse_WhenSourceSizeIsEqualToQueriedCount(int sourceSize)
    {
        // Arrange
        var source = Enumerable.Range(1, sourceSize);

        // Act
        var result = source.CountIsGt(sourceSize);

        // Assert
        Assert.That(result, Is.False);
    }

    [Test]
    public void CountIsGt_ReturnsTrue_WhenPredicateCountMatchesExpectedCount()
    {
        // Arrange
        var source = Enumerable.Range(1, 5);

        // Act
        var result = source.CountIsGt(3, x => x > 1);

        // Assert
        Assert.That(result, Is.True);
    }
}
