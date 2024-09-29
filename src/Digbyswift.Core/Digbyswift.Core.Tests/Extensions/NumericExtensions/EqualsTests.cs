using System;
using Digbyswift.Core.Extensions;
using NUnit.Framework;

namespace Digbyswift.Core.Tests.Extensions.NumericExtensions;

[TestFixture]
public class EqualsTests
{
    [Test]
    public void Equals_NegativeDecimalPlaces_ThrowsArgumentOutOfRangeException()
    {
        // Arrange
        var value = 123.456789;
        var compareTo = 123.456789;
        var decimalPlaces = -2;

        // Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => value.Equals(compareTo, decimalPlaces));
    }

    [TestCase(0, 0)]
    [TestCase(0.0, 0.0)]
    [TestCase(123, 123)]
    [TestCase(-123, -123)]
    [TestCase(123.4, 123.4)]
    [TestCase(123.456789, 123.456789)]
    [TestCase(-123.456789, -123.456789)]
    public void Equals_WithIdenticalInputsAndNoDecimalPrecision_ReturnsTrue(double value, double compareTo)
    {
        // Act
        var result = value.Equals(compareTo, 0);

        // Assert
        Assert.That(result, Is.True);
    }

    [TestCase(0.0, 0.0, 1)]
    [TestCase(0.0, 0.0, 2)]
    [TestCase(0.00, 0.00, 1)]
    [TestCase(0.00, 0.00, 2)]
    [TestCase(0.00, 0.00, 5)]
    [TestCase(-123.0, -123.0, 1)]
    [TestCase(-123.0, -123.0, 2)]
    [TestCase(-123.01, -123.01, 1)]
    [TestCase(-123.01, -123.01, 2)]
    [TestCase(-123.01, -123.01, 5)]
    [TestCase(-123.456, -123.456, 1)]
    [TestCase(-123.456, -123.456, 5)]
    [TestCase(123.4, 123.4, 1)]
    [TestCase(123.4, 123.4, 5)]
    [TestCase(123.45, 123.45, 2)]
    [TestCase(123.45, 123.45, 5)]
    [TestCase(123.456789, 123.456789, 5)]
    [TestCase(123.456789, 123.456789, 6)]
    [TestCase(123.456789, 123.456789, 10)]
    public void Equals_WithIdenticalValues_ReturnsTrue(double value, double compareTo, int decimalPlaces)
    {
        // Act
        var result = value.Equals(compareTo, decimalPlaces);

        // Assert
        Assert.That(result, Is.True);
    }

    [TestCase(0.1, 0, 0, true)]
    [TestCase(0.1, 0, 1, true)]
    [TestCase(0.1, 0.0, 0, true)]
    [TestCase(0.1, 0.0, 1, true)]
    [TestCase(0.01, 0, 2, true)]
    [TestCase(0.01, 0.0, 2, true)]
    [TestCase(0.001, 0, 0, true)]
    [TestCase(0.001, 0, 1, true)]
    [TestCase(0.001, 0, 3, true)]
    [TestCase(0.001, 0.0, 3, true)]
    [TestCase(123.1, 123, 0, true)]
    [TestCase(123.12, 123.1, 1, true)]
    [TestCase(123.456, 123.4, 1, true)]
    [TestCase(123.456, 123.45, 2, true)]
    [TestCase(123.12, 123, 2, false)]
    [TestCase(123.456, 123.4, 3, false)]
    [TestCase(123.456, 123.45, 10, false)]
    public void Equals_WithNonIdenticalValuesAndPermittedDecimalPrecision_ReturnsCorrectly(double value, double compareTo, int decimalPlaces, bool expectedResult)
    {
        // Act
        var result = value.Equals(compareTo, decimalPlaces);

        // Assert
        Assert.That(result, Is.EqualTo(expectedResult));
    }
}
