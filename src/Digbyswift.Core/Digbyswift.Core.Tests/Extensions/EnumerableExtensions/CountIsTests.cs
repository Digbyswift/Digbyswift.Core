using System;
using System.Collections.Generic;
using System.Linq;
using Digbyswift.Core.Extensions;
using NUnit.Framework;

namespace Digbyswift.Core.Tests.Extensions.EnumerableExtensions;

[TestFixture]
public class CountIsTests
{
#if NET48
    [Test]
    public void CountIs_ThrowsArgumentNullException_WhenSourceIsNull()
    {
        // Arrange
        IEnumerable<int> source = null;

        // Assert
        Assert.Throws<ArgumentNullException>(() =>
        {
            source.CountIs(1);
        });
    }
#endif

    [Test]
    public void CountIs_ReturnsTrue_WhenQueriedCountIsLessThanZero()
    {
        // Act
        var source = Enumerable.Empty<int>();

        // Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => source.CountIs(-1));
    }

    [TestCase(0)]
    [TestCase(1)]
    [TestCase(10)]
    public void CountIs_ReturnsTrue_WhenSourceSizeEqualsQueriedCount(int sourceSize)
    {
        // Arrange
        var source = Enumerable.Repeat(Char.MinValue, sourceSize);

        // Act
        var result = source.CountIs(sourceSize);

        // Assert
        Assert.That(result, Is.True, () => $"Expected: {sourceSize}, Actual: {source.Count()}");
    }

    [TestCase(1)]
    [TestCase(2)]
    [TestCase(10)]
    public void CountIs_ReturnsFalse_WhenSourceSizeIsLessThanQueriedCount(int sourceSize)
    {
        // Arrange
        var source = Enumerable.Repeat(Char.MinValue, sourceSize - 1);

        // Act
        var result = source.CountIs(sourceSize);

        // Assert
        Assert.That(result, Is.False, () => $"Expected: {sourceSize}, Actual: {source.Count()}");
    }

    [TestCase(1)]
    [TestCase(2)]
    [TestCase(10)]
    public void CountIs_ReturnsFalse_WhenSourceSizeIsGreaterThanQueriedCount(int sourceSize)
    {
        // Arrange
        var source = Enumerable.Repeat(Char.MinValue, sourceSize + 1);

        // Act
        var result = source.CountIs(sourceSize);

        // Assert
        Assert.That(result, Is.False, () => $"Expected: {sourceSize}, Actual: {source.Count()}");
    }

    [Test]
    public void CountIs_ReturnsTrue_WhenPredicateCountMatchesExpectedCount()
    {
        // Arrange
        var source = Enumerable.Range(1, 5);

        // Act
        var result = source.CountIs(4, x => x > 1);

        // Assert
        Assert.That(result, Is.True);
    }
}
