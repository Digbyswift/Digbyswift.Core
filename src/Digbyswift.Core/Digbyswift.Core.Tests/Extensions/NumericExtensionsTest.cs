using System;
using System.Collections.Generic;
using Digbyswift.Core.Extensions;
using NUnit.Framework;

namespace Digbyswift.Core.Tests.Extensions;

[TestFixture]
public class NumericExtensionsTest
{
    [TestCase(0d)]
    [TestCase(0.0d)]
    [TestCase(-0d)]
    public void IsZero_ReturnsTrue_WhenValueIsZero(double source)
    {
        // Arrange & Act
        var result = source.IsZero();

        // Assert
        Assert.IsTrue(result);
    }

    [TestCase(0.1d)]
    [TestCase(1d)]
    [TestCase(-1d)]
    public void IsZero_ReturnsFalse_WhenValueIsNotZero(double source)
    {
        // Arrange & Act
        var result = source.IsZero();

        // Assert
        Assert.IsFalse(result);
    }

    [TestCase(2)]
    [TestCase(-10)]
    public void IsEven_ReturnsTrue_WhenValueIsEven(int source)
    {
        // Arrange & Act
        var result = source.IsEven();

        // Assert
        Assert.IsTrue(result);
    }

    [TestCase(1)]
    [TestCase(-11)]
    public void IsEven_ReturnsFalse_WhenValueIsNotEven(int source)
    {
        // Arrange & Act
        var result = source.IsEven();

        // Assert
        Assert.IsFalse(result);
    }

    [TestCase(100, 1000, 10)]
    [TestCase(0, 1000, 0)]
    [TestCase(1000, 1000, 100)]
    public void AsPercentageOf_ReturnsCorrectPercentage(int source, int total, int percentage)
    {
        // Arrange & Act
        var result = source.AsPercentageOf(total);

        // Assert
        Assert.That(result.Equals(percentage));
    }

    [TestCase(100.0000, 1000.00000, 10)]
    [TestCase(0.0000, 1000.0000, 0)]
    [TestCase(1000.0000, 1000.0000, 100)]
    public void AsPercentageOf_ReturnsCorrectPercentage(decimal source, decimal total, int percentage)
    {
        // Arrange & Act
        var result = source.AsPercentageOf(total);

        // Assert
        Assert.That(result, Is.EqualTo(percentage));
    }

    [TestCase(100.00d, 1000.00d, 10)]
    [TestCase(0.00d, 1000.00d, 0)]
    [TestCase(1000.00d, 1000.00d, 100)]
    public void AsPercentageOf_ReturnsCorrectPercentage(double source, double total, int percentage)
    {
        // Arrange & Act
        var result = source.AsPercentageOf(total);

        // Assert
        Assert.That(result, Is.EqualTo(percentage));
    }

    [TestCase(123d, 123.5d, 0)]
    [TestCase(123.534d, 123.578d, 0)]
    [TestCase(123.534d, 123.578d, 1)]
    public void Equals_ReturnsTrue_WhenValuesAreEqualToDecimalPlace(double source, double compareTo, double decimalPlaces)
    {
        // Arrange & Act
        var result = source.Equals(compareTo, decimalPlaces);

        // Assert
        Assert.IsTrue(result);
    }

    [TestCase(123d, 123.5d)]
    public void Equals_ThrowsException_WhenWhenNoDecimalPlaceSpecified(double source, double compareTo)
    {
        // Arrange & Act
        var ex = Assert.Throws<ArgumentOutOfRangeException>(() => source.Equals(compareTo, -1));

        // Assert
        Assert.That(ex.Message, Contains.Substring("Decimal places must be non-negative"));
    }

    [TestCase(123.889078d, 1, 123.8d)]
    [TestCase(123.889078d, 2, 123.88d)]
    [TestCase(123.889078d, 3, 123.889d)]
    public void Truncate_ReturnsDouble_WithoutDecimalPlaces(double source, int decimalPlaces, double expectedResult)
    {
        // Arrange & Act
        var result = source.Truncate(decimalPlaces);

        // Assert
        Assert.That(result, Is.EqualTo(expectedResult));
    }

    [TestCase(123.889078d, -2)]
    public void Truncate_ThrowsException_WhenDecimalPlaceIsNegative(double source, int decimalPlaces)
    {
        // Arrange & Act
        var ex = Assert.Throws<ArgumentOutOfRangeException>(() => source.Truncate(decimalPlaces));

        // Assert
        Assert.That(ex.Message, Contains.Substring("Decimal places must be non-negative"));
    }

    [Test]
    public void ToInvariantString_ReturnsUShortValue_AsInvariantString()
    {
        // Arrange
        var values = new List<ushort> { 0, 1, 1000 };
        var expectedResults = new List<string> { "0", "1", "1000" };

        // Act & Assert
        for (var i = 0; i < values.Count; i++)
        {
            var result = values[i].ToInvariantString();

            Assert.That(result, Is.EqualTo(expectedResults[i]));
        }
    }

    [Test]
    public void ToInvariantString_ReturnsShortValue_AsInvariantString()
    {
        // Arrange
        var values = new List<short> { 0, 1, 1000 };
        var expectedResults = new List<string> { "0", "1", "1000" };

        // Act & Assert
        for (var i = 0; i < values.Count; i++)
        {
            var result = values[i].ToInvariantString();

            Assert.That(result, Is.EqualTo(expectedResults[i]));
        }
    }

    [Test]
    public void ToInvariantString_ReturnsUIntValue_AsInvariantString()
    {
        // Arrange
        var values = new List<uint> { 0, 1, 1000 };
        var expectedResults = new List<string> { "0", "1", "1000" };

        // Act & Assert
        for (var i = 0; i < values.Count; i++)
        {
            var result = values[i].ToInvariantString();

            Assert.That(result, Is.EqualTo(expectedResults[i]));
        }
    }

    [Test]
    public void ToInvariantString_ReturnsIntValue_AsInvariantString()
    {
        // Arrange
        var values = new List<int> { 0, 1, 1000, -1000 };
        var expectedResults = new List<string> { "0", "1", "1000", "-1000" };

        // Act & Assert
        for (var i = 0; i < values.Count; i++)
        {
            var result = values[i].ToInvariantString();

            Assert.That(result, Is.EqualTo(expectedResults[i]));
        }
    }

    [Test]
    public void ToInvariantString_ReturnsULongValue_AsInvariantString()
    {
        // Arrange
        var values = new List<ulong> { 0, 1, 1000 };
        var expectedResults = new List<string> { "0", "1", "1000" };

        // Act & Assert
        for (var i = 0; i < values.Count; i++)
        {
            var result = values[i].ToInvariantString();

            Assert.That(result, Is.EqualTo(expectedResults[i]));
        }
    }

    [Test]
    public void ToInvariantString_ReturnsLongValue_AsInvariantString()
    {
        // Arrange
        var values = new List<long> { 0, 1, 1000, -1000 };
        var expectedResults = new List<string> { "0", "1", "1000", "-1000" };

        // Act & Assert
        for (var i = 0; i < values.Count; i++)
        {
            var result = values[i].ToInvariantString();

            Assert.That(result, Is.EqualTo(expectedResults[i]));
        }
    }

    [Test]
    public void ToInvariantString_ReturnsDecimalValue_AsInvariantString()
    {
        // Arrange
        var values = new List<decimal> { 0m, 1m, 1.0m, 1.99m, 1000.99m, -1000.99m };
        var expectedResults = new List<string> { "0", "1", "1.0", "1.99", "1000.99", "-1000.99" };

        // Act & Assert
        for (var i = 0; i < values.Count; i++)
        {
            var result = values[i].ToInvariantString();

            Assert.That(result, Is.EqualTo(expectedResults[i]));
        }
    }

    [Test]
    public void ToInvariantString_ReturnsDoubleValue_AsInvariantString()
    {
        // Arrange
        var values = new List<double> { 0d, 1d, 1.0d, 1.99d, 1000.99d, -1000.99d };
        var expectedResults = new List<string> { "0", "1", "1", "1.99", "1000.99", "-1000.99" };

        // Act & Assert
        for (var i = 0; i < values.Count; i++)
        {
            var result = values[i].ToInvariantString();

            Assert.That(result, Is.EqualTo(expectedResults[i]));
        }
    }
}