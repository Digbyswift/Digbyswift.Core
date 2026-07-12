using System;
using System.Collections.Generic;
using System.Linq;
using Digbyswift.Core.Extensions;
using NUnit.Framework;

namespace Digbyswift.Core.Tests.Extensions.EnumerableExtensions;

[TestFixture]
public class NoneTests
{
#if NET48
    [Test]
    public void None_ThrowsArgumentNullException_WhenSourceIsNull()
    {
        // Arrange
        IEnumerable<int> source = null;

        // Assert
        Assert.Throws<ArgumentNullException>(() =>
        {
            source.None(x => true);
        });
    }

    [Test]
    public void None_ThrowsArgumentNullException_WhenPredicateIsNull()
    {
        // Arrange
        var source = Enumerable.Empty<int>();

        // Assert
        Assert.Throws<ArgumentNullException>(() =>
        {
            source.None(null);
        });
    }
#endif

    [Test]
    public void None_ReturnsTrue_WhenSourceIsEmpty()
    {
        // Arrange
        var source = Enumerable.Empty<int>();

        // Assert
        Assert.That(source.None(_ => true), Is.True);
    }

    [Test]
    public void None_ReturnsTrue_WhenSourceIsNotEmptyAndPredicateFindsNoMatches()
    {
        // Arrange
        var source = Enumerable.Range(1, 5);

        // Act
        var result = source.None(x => x > 10);

        // Assert
        Assert.That(result, Is.True);
    }

    [Test]
    public void None_ReturnsFalse_WhenSourceIsNotEmptyAndPredicateFindsMatches()
    {
        // Arrange
        var source = Enumerable.Range(1, 5);

        // Act
        var result = source.None(x => x == 2);

        // Assert
        Assert.That(result, Is.False);
    }
}
