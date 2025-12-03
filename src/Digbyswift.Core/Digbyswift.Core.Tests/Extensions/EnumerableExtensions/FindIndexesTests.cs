using System;
using System.Collections.Generic;
using System.Linq;
using Digbyswift.Core.Extensions;
using NUnit.Framework;

namespace Digbyswift.Core.Tests.Extensions.EnumerableExtensions;

[TestFixture]
public class FindIndexesTests
{
#if NET48
    [Test]
    public void FindIndexes_ThrowsArgumentNullException_WhenSourceIsNull()
    {
        // Arrange
        IEnumerable<int> source = null;

        // Assert
        Assert.Throws<ArgumentNullException>(() =>
        {
            var result = source.FindIndexes(x => x > 0);
            result.ToList();
        });
    }

    [Test]
    public void FindIndexes_ThrowsArgumentNullException_WhenPredicateIsNull()
    {
        // Arrange
        var source = Enumerable.Empty<int>();

        // Assert
        Assert.Throws<ArgumentNullException>(() =>
        {
            var result = source.FindIndexes(null);
            result.ToList();
        });
    }
#endif

    [Test]
    public void FindIndexes_ReturnsEmptyCollection_WhenPredicateMatchesNoItems()
    {
        // Arrange
        var source = new[] { 1, 2, 3 };

        // Act
        var result = source.FindIndexes(x => x > 4);

        // Assert
        Assert.That(result, Is.Empty);
    }

    [Test]
    public void FindIndexes_ReturnsPopulatedCollection_WhenPredicateMatchesItems()
    {
        // Arrange
        var source = new[] { "test", "collection", "array", "list", "set", "dict" };
        var expectedResult = new[] { 1, 2 };

        // Act
        var result = source.FindIndexes(x => x.Length > 4);

        // Assert
        Assert.That(result, Is.EquivalentTo(expectedResult));
    }
}
