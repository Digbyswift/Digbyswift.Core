using System;
using System.Collections.Generic;
using System.Linq;
using Digbyswift.Core.Extensions;
using NUnit.Framework;

namespace Digbyswift.Core.Tests.Extensions.EnumerableExtensions;

[TestFixture]
public class SkipLastTests
{
#if NET48
    [Test]
    public void SkipLast_ThrowsArgumentNullException_WhenSourceIsNull()
    {
        // Arrange
        IEnumerable<int> source = null;

        // Assert
        Assert.Throws<ArgumentNullException>(() =>
        {
            var result = source.SkipLast().ToList();
        });
    }
#endif

    [Test]
    public void SkipLast_ReturnsEmptyCollection_WhenSourceIsEmpty()
    {
        // Arrange
        var source = Enumerable.Empty<int>();

        // Assert
        Assert.That(source.SkipLast(), Is.Empty);
    }

    [Test]
    public void SkipLast_ReturnsAllButLastItem_WhenSourceIsNotEmpty()
    {
        // Arrange
        const int firstItem = 1;
        const int lastItem = 5;
        var source = Enumerable.Range(firstItem, lastItem);

        // Act
        var result = source.SkipLast();

        // Assert
        Assert.That(result.Last(), Is.EqualTo(4));
        Assert.That(result.First(), Is.EqualTo(firstItem));
        Assert.That(result.Count(), Is.EqualTo(4));
    }
}
