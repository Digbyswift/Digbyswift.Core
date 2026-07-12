using Digbyswift.Core.Extensions;
using NUnit.Framework;

namespace Digbyswift.Core.Tests.Extensions.NumericExtensions;

[TestFixture]
public class IsZeroTests
{
    [TestCase(0d)]
    [TestCase(-0d)]
    [TestCase(double.Epsilon)]
    [TestCase(-double.Epsilon)]
    [TestCase(0.1d + 0.2d - 0.3d)]
    public void IsZero_WithZeroOrFloatingPointResidue_ReturnsTrue(double value)
    {
        // Act
        var result = value.IsZero();

        // Assert
        Assert.That(result, Is.True);
    }

    [TestCase(1d)]
    [TestCase(-1d)]
    [TestCase(0.00000000001d)]
    [TestCase(-0.00000000001d)]
    [TestCase(double.NaN)]
    [TestCase(double.PositiveInfinity)]
    [TestCase(double.NegativeInfinity)]
    public void IsZero_WithNonZeroValues_ReturnsFalse(double value)
    {
        // Act
        var result = value.IsZero();

        // Assert
        Assert.That(result, Is.False);
    }
}
