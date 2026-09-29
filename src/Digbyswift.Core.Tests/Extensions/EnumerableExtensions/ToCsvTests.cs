using System;
using System.Collections.Generic;
using System.Linq;
using Digbyswift.Core.Extensions;
using NUnit.Framework;

namespace Digbyswift.Core.Tests.Extensions.EnumerableExtensions;

[TestFixture]
public class ToCsvTests
{
    [Test]
    public void ToCsv_ThrowsArgumentNullException_WhenSourceIsNull()
    {
        // Arrange
#if NET48
        IEnumerable<string> source = null;
#else
        IEnumerable<string> source = null!;
#endif

        // Assert
        Assert.Throws<ArgumentNullException>(() =>
        {
            source.ToCsv();
        });
    }

    [Test]
    public void ToCsv_ReturnsNull_WhenSourceIsEmpty()
    {
        // Arrange
        var source = Enumerable.Empty<string>();

        // Act
        var result = source.ToCsv();

        // Assert
        Assert.That(result, Is.Null);
    }

    [Test]
    public void ToCsv_ReturnsValue_WhenSourceContainsOneValue()
    {
        // Arrange
        const string value = "First";
        var source = new[] { value };

        // Act
        var result = source.ToCsv();

        // Assert
        Assert.That(result, Is.EqualTo(value));
    }

    [Test]
    public void ToCsv_ReturnsCommaDelimitedValues_WhenSourceContainsMultipleValues()
    {
        // Arrange
        var source = new[] { "First", "Second", "Third" };

        // Act
        var result = source.ToCsv();

        // Assert
        Assert.That(result, Is.EqualTo("First,Second,Third"));
    }

    [Test]
    public void ToCsv_ReturnsCommaAndSpaceDelimitedValues_WhenIncludeSpaceAfterDelimiterIsTrue()
    {
        // Arrange
        var source = new[] { "First", "Second", "Third" };

        // Act
        var result = source.ToCsv(includeSpaceAfterDelimiter: true);

        // Assert
        Assert.That(result, Is.EqualTo("First, Second, Third"));
    }
}
