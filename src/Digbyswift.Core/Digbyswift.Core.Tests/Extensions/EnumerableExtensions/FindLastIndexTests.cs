using System;
using System.Collections.Generic;
using System.Linq;
using Digbyswift.Core.Extensions;
using NUnit.Framework;

namespace Digbyswift.Core.Tests.Extensions.EnumerableExtensions;

[TestFixture]
public class FindLastIndexTests
{
#if NET48
    [Test]
    public void FindLastIndex_ThrowsArgumentNullException_WhenSourceIsNull()
    {
        // Arrange
        IEnumerable<int> source = null;

        // Assert
        Assert.Throws<ArgumentNullException>(() => source.FindLastIndex(x => x > 0));
    }

    [Test]
    public void FindLastIndex_ThrowsArgumentNullException_WhenPredicateIsNull()
    {
        // Arrange
        var source = Enumerable.Empty<int>();

        // Assert
        Assert.Throws<ArgumentNullException>(() => source.FindLastIndex(null));
    }
#endif

    [Test]
    public void FindLastIndexTests_ReturnsMinusOne_WhenPredicateMatchesNoItems()
    {
        // Arrange
        var source = new[] { 1, 2, 3 };

        // Act
        var result = source.FindLastIndex(x => x > 4);

        // Assert
        Assert.That(result, Is.EqualTo(-1));
    }

    [Test]
    public void FindLastIndexTests_ReturnsIndex_WhenPredicateMatchesItems()
    {
        // Arrange
        var source = new[] { "test", "collection", "array", "list", "set", "dict" };

        // Act
        var result = source.FindLastIndex(x => x.Length > 4);

        // Assert
        Assert.That(result, Is.EqualTo(2));
    }
}
