using System;
using System.Collections.Generic;
using System.Linq;
using Digbyswift.Core.Extensions;
using NUnit.Framework;

namespace Digbyswift.Core.Tests.Extensions.EnumerableExtensions;

[TestFixture]
public class IsEmptyTests
{
#if NET48
    [Test]
    public void IsEmpty_ThrowsArgumentNullException_WhenSourceIsNull()
    {
        // Arrange
        IEnumerable<int> source = null;

        // Assert
        Assert.Throws<ArgumentNullException>(() =>
        {
            source.IsEmpty();
        });
    }
#endif

    [Test]
    public void IsEmpty_ReturnsTrue_WhenSourceIsEmpty()
    {
        // Act
        var source = Enumerable.Empty<int>();

        // Assert
        Assert.That(source.IsEmpty(), Is.True);
    }

    [Test]
    public void IsEmpty_ReturnsTrue_WhenSourceIsNotEmpty()
    {
        // Act
        var source = Enumerable.Range(1, 5);

        // Assert
        Assert.That(source.IsEmpty(), Is.False);
    }
}
