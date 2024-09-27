using System;
using System.Collections.Generic;
using System.Linq;
using Digbyswift.Core.Extensions;
using NUnit.Framework;

namespace Digbyswift.Core.Tests.Extensions;

[TestFixture]
public class GuidExtensionsTests
{
    [Test]
    public void Segments_ReturnsArrayOfZeroOnlySegments_WhenGuidIsEmpty()
    {
        // Act
        var array = Guid.Empty.Segments();

        // Assert
        Assert.That(array.Length, Is.EqualTo(5));
        Assert.That(Array.TrueForAll(array, segment => segment.All(x => x == '0')), Is.True);
    }

    [Test]
    public void Segments_ReturnsArrayOfValidSegments()
    {
        // Arrange
        var guid = Guid.NewGuid();

        // Act
        var segments = guid.Segments();
        var reformedGuid = Guid.ParseExact(String.Concat(segments), "N");

        // Assert
        Assert.That(segments.Length, Is.EqualTo(5));
        Assert.That(reformedGuid, Is.EqualTo(guid));
    }

    [Test]
    public void FirstSegments_ReturnsStringMatchingGuidFirstEightCharacters()
    {
        // Arrange
        var guid = Guid.NewGuid();
        var firstEightCharacters = guid.ToString("N").Substring(0, 8);

        // Act
        var segment = guid.FirstSegment();

        // Assert
        Assert.That(segment, Is.EqualTo(firstEightCharacters));
    }
}