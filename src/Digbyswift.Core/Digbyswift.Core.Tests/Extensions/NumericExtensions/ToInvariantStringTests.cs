using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using Digbyswift.Core.Extensions;
using NUnit.Framework;

namespace Digbyswift.Core.Tests.Extensions.NumericExtensions;

[TestFixture]
public class ToInvariantStringTests
{
    #region ushort

    [TestCase(0, "0")]
    [TestCase(1, "1")]
    [TestCase(10, "10")]
    [TestCase(1000, "1000")]
    [TestCase(10000, "10000")]
    public void ToInvariantString_UInt16_ReturnsExpectedOutput(short value, string expectedOutput)
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("sv-SE");

        // Act
        var result = ((ushort)value).ToInvariantString();

        // Assert
        Assert.That(result, Is.EqualTo(expectedOutput));
    }

    [TestCase(0, "0")]
    [TestCase(1, "1")]
    [TestCase(10, "10")]
    [TestCase(1000, "1000")]
    [TestCase(10000, "10000")]
    public void ToInvariantString_Int16_ReturnsExpectedOutput(short value, string expectedOutput)
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("sv-SE");

        // Act
        var result = value.ToInvariantString();

        // Assert
        Assert.That(result, Is.EqualTo(expectedOutput));
    }

    [TestCase(0, "0")]
    [TestCase(1, "1")]
    [TestCase(10, "10")]
    [TestCase(1000, "1000")]
    [TestCase(10000, "10000")]
    public void ToInvariantString_UInt32_ReturnsExpectedOutput(int value, string expectedOutput)
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("sv-SE");

        // Act
        var result = ((uint)value).ToInvariantString();

        // Assert
        Assert.That(result, Is.EqualTo(expectedOutput));
    }

    [TestCase(0, "0")]
    [TestCase(1, "1")]
    [TestCase(10, "10")]
    [TestCase(1000, "1000")]
    [TestCase(10000, "10000")]
    public void ToInvariantString_Int32_ReturnsExpectedOutput(int value, string expectedOutput)
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("sv-SE");

        // Act
        var result = value.ToInvariantString();

        // Assert
        Assert.That(result, Is.EqualTo(expectedOutput));
    }

    [TestCase(0, "0")]
    [TestCase(1, "1")]
    [TestCase(10, "10")]
    [TestCase(1000, "1000")]
    [TestCase(10000, "10000")]
    public void ToInvariantString_UInt64_ReturnsExpectedOutput(int value, string expectedOutput)
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("sv-SE");

        // Act
        var result = ((ulong)value).ToInvariantString();

        // Assert
        Assert.That(result, Is.EqualTo(expectedOutput));
    }

    [TestCase(0, "0")]
    [TestCase(1, "1")]
    [TestCase(10, "10")]
    [TestCase(1000, "1000")]
    [TestCase(10000, "10000")]
    public void ToInvariantString_Int64_ReturnsExpectedOutput(long value, string expectedOutput)
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("sv-SE");

        // Act
        var result = value.ToInvariantString();

        // Assert
        Assert.That(result, Is.EqualTo(expectedOutput));
    }

    [TestCase(0d, "0")]
    [TestCase(0.0d, "0")]
    [TestCase(1d, "1")]
    [TestCase(1.0d, "1")]
    [TestCase(1.99d, "1.99")]
    [TestCase(1000.99d, "1000.99")]
    public void ToInvariantString_Double_ReturnsExpectedOutput(double value, string expectedOutput)
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("sv-SE");

        // Act
        var result = value.ToInvariantString();

        // Assert
        Assert.That(result, Is.EqualTo(expectedOutput));
    }

    [TestCase(0, "0")]
    [TestCase(0.0, "0")]
    [TestCase(1, "1")]
    [TestCase(1.0, "1")]
    [TestCase(1.99, "1.99")]
    [TestCase(1000.99, "1000.99")]
    public void ToInvariantString_Decimal_ReturnsExpectedOutput(decimal value, string expectedOutput)
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("sv-SE");

        // Act
        var result = value.ToInvariantString();

        // Assert
        Assert.That(result, Is.EqualTo(expectedOutput));
    }

    #endregion

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
