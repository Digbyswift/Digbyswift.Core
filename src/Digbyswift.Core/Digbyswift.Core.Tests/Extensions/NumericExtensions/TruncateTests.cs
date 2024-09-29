﻿using System;
using Digbyswift.Core.Extensions;
using NUnit.Framework;

namespace Digbyswift.Core.Tests.Extensions.NumericExtensions;

[TestFixture]
public class TruncateTests
{
    [Test]
    public void Truncate_PositiveDecimalPlaces_TruncatesCorrectly()
    {
        // Arrange
        var value = 123.456789;
        var decimalPlaces = 3;

        // Act
        var result = value.Truncate(decimalPlaces);

        // Assert
        Assert.That(result, Is.EqualTo(123.456));
    }

    [Test]
    public void Truncate_ZeroDecimalPlaces_TruncatesToInteger()
    {
        // Arrange
        var value = 123.456;
        var decimalPlaces = 0;

        // Act
        var result = value.Truncate(decimalPlaces);

        // Assert
        Assert.That(result, Is.EqualTo(123));
    }

    [Test]
    public void Truncate_MoreDecimalPlacesThanValue_PreservesOriginalValue()
    {
        // Arrange
        var value = 123.45d;
        var decimalPlaces = 10;

        // Act
        var result = value.Truncate(decimalPlaces);

        // Assert
        Assert.That(result, Is.EqualTo(value));
    }

    [Test]
    public void Truncate_NegativeDecimalPlaces_ThrowsArgumentOutOfRangeException()
    {
        // Arrange
        var value = 123.456;
        var decimalPlaces = -2;

        // Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => value.Truncate(decimalPlaces));
    }

    [Test]
    public void Truncate_NegativeNumber_TruncatesCorrectly()
    {
        // Arrange
        var value = -123.456789;
        var decimalPlaces = 2;

        // Act
        var result = value.Truncate(decimalPlaces);

        // Assert
        Assert.That(result, Is.EqualTo(-123.45));
    }

    [Test]
    public void Truncate_ValueIsZero_ReturnsZero()
    {
        // Arrange
        var value = 0.0;
        var decimalPlaces = 5;

        // Act
        var result = value.Truncate(decimalPlaces);

        // Assert
        Assert.That(result, Is.EqualTo(0.0));
    }

    [Test]
    public void Truncate_SmallDecimalValue_TruncatesCorrectly()
    {
        // Arrange
        var value = 0.000123456789;
        var decimalPlaces = 5;

        // Act
        var result = value.Truncate(decimalPlaces);

        // Assert
        Assert.That(result, Is.EqualTo(0.00012));
    }
}
