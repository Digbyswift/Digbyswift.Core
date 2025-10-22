using System;
using System.Collections.Generic;
using System.Linq;
using Digbyswift.Core.Extensions;
using NUnit.Framework;

namespace Digbyswift.Core.Tests.Extensions.EnumerableExtensions;

[TestFixture]
public class FindFirstIndexTests
{
#if NET48
    [Test]
    public void FindFirstIndex_ThrowsArgumentNullException_WhenSourceIsNull()
    {
        // Arrange
        IEnumerable<int> source = null;

        // Assert
        Assert.Throws<ArgumentNullException>(() => source.FindFirstIndex(x => x > 0));
    }

    [Test]
    public void FindFirstIndex_ThrowsArgumentNullException_WhenPredicateIsNull()
    {
        // Arrange
        var source = Enumerable.Empty<int>();

        // Assert
        Assert.Throws<ArgumentNullException>(() => source.FindFirstIndex(null));
    }
#endif

    [Test]
    public void FindFirstIndexTests_ReturnsMinusOne_WhenPredicateMatchesNoItems()
    {
        // Arrange
        var source = new[] { 1, 2, 3 };

        // Act
        var result = source.FindFirstIndex(x => x > 4);

        // Assert
        Assert.That(result, Is.EqualTo(-1));
    }

    [Test]
    public void FindFirstIndexTests_ReturnsIndex_WhenPredicateMatchesItems()
    {
        // Arrange
        var source = new[] { "test", "collection", "array", "list", "set", "dict" };

        // Act
        var result = source.FindFirstIndex(x => x.Length > 4);

        // Assert
        Assert.That(result, Is.EqualTo(1));
    }
}
