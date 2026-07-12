using System;
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
}
