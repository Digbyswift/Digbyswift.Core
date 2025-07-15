using System;
using System.Collections.Generic;
using Digbyswift.Core.Extensions;
using NUnit.Framework;

namespace Digbyswift.Core.Tests.Extensions.EnumerableExtensions;

[TestFixture]
public class MinOrMaxTests
{
    private readonly IEnumerable<int> _testNumericList = [11, 4, 6, 2, 9];

    [Test]
    public void MinOrDefault_ReturnsLowestItemInSequence()
    {
        // Arrange & Act
        var result = _testNumericList.MinOrDefault();

        // Assert
        Assert.AreEqual(result, 2);
    }

    [Test]
    public void MinOrDefault_ThrowsException_WhenEnumerableIsNull()
    {
        // Arrange
        IEnumerable<int>? source = null;

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => source.MinOrDefault());
    }

    [Test]
    public void MaxOrDefault_ReturnsHighestItemInSequence()
    {
        // Arrange & Act
        var result = _testNumericList.MaxOrDefault();

        // Assert
        Assert.AreEqual(result, 11);
    }

    [Test]
    public void MaxOrDefault_ThrowsException_WhenEnumerableIsNull()
    {
        // Arrange
        IEnumerable<int>? source = null;

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => source.MaxOrDefault());
    }
}
