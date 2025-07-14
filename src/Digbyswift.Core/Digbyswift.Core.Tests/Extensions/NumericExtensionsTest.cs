using System;
using System.Collections.Generic;
using Digbyswift.Core.Extensions;
using NUnit.Framework;

namespace Digbyswift.Core.Tests.Extensions;

[TestFixture]
public class NumericExtensionsTest
{
    [TestCase(0)]
    [TestCase(0.0)]
    [TestCase(-0)]
    public void IsZero_ReturnsTrue_WhenValueIsZero(double source)
    {
        // Arrange & Act
        var result = source.IsZero();

        // Assert
        Assert.IsTrue(result);
    }

    [TestCase(0.1)]
    [TestCase(1)]
    [TestCase(-1)]
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

    [TestCase(100.00, 1000.00, 10)]
    [TestCase(0.00, 1000.00, 0)]
    [TestCase(1000.00, 1000.00, 100)]
    public void AsPercentageOf_ReturnsCorrectPercentage(double source, double total, int percentage)
    {
        // Arrange & Act
        var result = source.AsPercentageOf(total);

        // Assert
        Assert.That(result, Is.EqualTo(percentage));
    }

    [TestCase(123, 123.5, 0)]
    [TestCase(123.534, 123.578, 0)]
    [TestCase(123.534, 123.578, 1)]
    public void Equals_ReturnsTrue_WhenValuesAreEqualToDecimalPlace(double source, double compareTo,
        double decimalPlaces)
    {
        // Arrange & Act
        var result = source.Equals(compareTo, decimalPlaces);

        // Assert
        Assert.IsTrue(result);
    }

    [TestCase(123, 123.5)]
    public void Equals_ReturnsException_WhenWhenNoDecimalPlaceSpecified(double source, double compareTo)
    {
        // Arrange & Act
        var ex = Assert.Throws<ArgumentOutOfRangeException>(
            () =>
            {
                source.Equals(compareTo, -1);
            });

        // Assert
        Assert.That(ex.Message.ContainsIgnoreCase("Decimal places must be non-negative"));
    }

    [TestCase(123.889078, 1, 123.8)]
    [TestCase(123.889078, 2, 123.88)]
    [TestCase(123.889078, 3, 123.889)]
    public void Truncate_ReturnsDouble_WithoutDecimalPlaces(double source, int decimalPlaces, double expectedResult)
    {
        // Arrange & Act
        var result = source.Truncate(decimalPlaces);

        // Assert
        Assert.That(result, Is.EqualTo(expectedResult));
    }

    [TestCase(123.889078, -2)]
    public void Truncate_ReturnsException_WhenDecimalPlaceIsNegative(double source, int decimalPlaces)
    {
        // Arrange & Act
        var ex = Assert.Throws<ArgumentOutOfRangeException>(
            () =>
            {
                source.Truncate(decimalPlaces);
            });

        // Assert
        Assert.That(ex.Message.ContainsIgnoreCase("Decimal places must be non-negative"));
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