using System;
using System.Collections.Generic;
using Digbyswift.Core.Extensions;
using NUnit.Framework;

namespace Digbyswift.Core.Tests.Extensions.EnumerableExtensions;

[TestFixture]
public class SkipTests
{
    [Test]
    public void SkipLast_ThrowsException_WhenSourceIsNull()
    {
        // Arrange
        IEnumerable<string>? source = null;

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => source.SkipLast());
    }

    [Test]
    public void SkipLast_OutputsEnumerable_WithoutLastItem()
    {
        // Arrange
        IEnumerable<int> source = new List<int> { 1, 2, 3 };
        IEnumerable<int> expectedResult = new List<int> { 1, 2 };

        // Act
        var result = source.SkipLast();

        // Assert
        Assert.That(result, Is.EqualTo(expectedResult));
    }

    [Test]
    public void SkipLast_OutputsEmptyEnumerable_WhenSourceIsEmpty()
    {
        // Arrange
        IEnumerable<int> source = new List<int>();
        IEnumerable<int> expectedResult = new List<int>();

        // Act
        var result = source.SkipLast();

        // Assert
        Assert.That(result, Is.EqualTo(expectedResult));
    }

    [Test]
    public void SkipLast_OutputsEmptyEnumerable_WhenSourceHasSingleItem()
    {
        // Arrange
        IEnumerable<int> source = new List<int> { 1 };
        IEnumerable<int> expectedResult = new List<int>();

        // Act
        var result = source.SkipLast();

        // Assert
        Assert.That(result, Is.EqualTo(expectedResult));
    }
}
