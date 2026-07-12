using System;
using System.Collections.Generic;
using System.Linq;
using Digbyswift.Core.Extensions;
using NUnit.Framework;

namespace Digbyswift.Core.Tests.Extensions.EnumerableExtensions;

[TestFixture]
public class CountIsLtTests
{
#if NET48
    [Test]
    public void CountIsLt_ThrowsArgumentNullException_WhenSourceIsNull()
    {
        // Arrange
        IEnumerable<int> source = null;

        // Assert
        Assert.Throws<ArgumentNullException>(() =>
        {
            source.CountIsLt(1);
        });
    }
#endif

    [TestCase(-1)]
    [TestCase(0)]
    public void CountIsLt_ThrowsArgumentException_WhenCountIsLessThanOne(int count)
    {
        // Arrange
        var source = Enumerable.Empty<int>();

        // Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => source.CountIsLt(count));
    }

    [TestCase(1)]
    [TestCase(10)]
    public void CountIsLt_ReturnsTrue_WhenSourceIsEmptyAndQueriedCountIsGreaterThanOneOrMore(int queriedCount)
    {
        // Arrange
        var source = Enumerable.Empty<int>();

        // Act
        var result = source.CountIsLt(queriedCount);

        // Assert
        Assert.That(result, Is.True);
    }

    [TestCase(1)]
    [TestCase(2)]
    [TestCase(10)]
    public void CountIsLt_ReturnsFalse_WhenSourceSizeIsGreaterThanQueriedCount(int queriedCount)
    {
        // Arrange
        var source = Enumerable.Range(0, queriedCount + 1);

        // Act
        var result = source.CountIsLt(queriedCount);

        // Assert
        Assert.That(source.Count(), Is.GreaterThan(queriedCount));
        Assert.That(result, Is.False, () => $"Source count: {source.Count()}, Queried count: {queriedCount}");
    }

    [TestCase(1)]
    [TestCase(2)]
    [TestCase(10)]
    public void CountIsLt_ReturnsTrue_WhenSourceSizeIsLessThanQueriedCount(int sourceSize)
    {
        // Arrange
        var source = Enumerable.Repeat(Char.MinValue, sourceSize - 1);

        // Act
        var result = source.CountIsLt(sourceSize);

        // Assert
        Assert.That(result, Is.True, () => $"Expected: {sourceSize}, Actual: {source.Count()}");
    }

    [TestCase(1)]
    [TestCase(2)]
    [TestCase(10)]
    public void CountIsLt_ReturnsFalse_WhenSourceSizeIsEqualToQueriedCount(int sourceSize)
    {
        // Arrange
        var source = Enumerable.Range(1, sourceSize);

        // Act
        var result = source.CountIsLt(sourceSize);

        // Assert
        Assert.That(result, Is.False);
    }

    [Test]
    public void CountIsLt_ReturnsTrue_WhenPredicateCountMatchesExpectedCount()
    {
        // Arrange
        var source = Enumerable.Range(1, 5);

        // Act
        var result = source.CountIsLt(2, x => x == 1);

        // Assert
        Assert.That(result, Is.True);
    }
}
