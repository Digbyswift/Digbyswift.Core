using Digbyswift.Core.Extensions;
using NUnit.Framework;

namespace Digbyswift.Core.Tests.Extensions.NumericExtensions;

[TestFixture]
public class AsPercentageOfTests
{
    [TestCase(25, 100, 25f)]
    [TestCase(1, 4, 25f)]
    [TestCase(1, 3, 33.3333333f)]
    [TestCase(0, 100, 0f)]
    [TestCase(100, 0, 0f)]
    [TestCase(-25, 100, -25f)]
    [TestCase(25, -100, -25f)]
    [TestCase(150, 100, 150f)]
    public void AsPercentageOf_Int32_ReturnsExpectedOutput(int proportion, int total, float expectedOutput)
    {
        // Act
        var result = proportion.AsPercentageOf(total);

        // Assert
        Assert.That(result, Is.EqualTo(expectedOutput).Within(0.00001f));
    }

    [TestCase(25, 100, 25)]
    [TestCase(1, 4, 25)]
    [TestCase(0, 100, 0)]
    [TestCase(100, 0, 0)]
    [TestCase(-25, 100, -25)]
    [TestCase(25, -100, -25)]
    [TestCase(150, 100, 150)]
    public void AsPercentageOf_Decimal_ReturnsExpectedOutput(decimal proportion, decimal total, decimal expectedOutput)
    {
        // Act
        var result = proportion.AsPercentageOf(total);

        // Assert
        Assert.That(result, Is.EqualTo(expectedOutput).Within(0.000000000000001m));
    }

    [Test]
    public void AsPercentageOf_Decimal_WithRepeatingDecimal_ReturnsExpectedOutput()
    {
        // Arrange
        var proportion = 1m;
        var total = 3m;
        var expectedOutput = 100m / 3m;

        // Act
        var result = proportion.AsPercentageOf(total);

        // Assert
        Assert.That(result, Is.EqualTo(expectedOutput).Within(0.00000000000000000000000001m));
    }

    [TestCase(25d, 100d, 25d)]
    [TestCase(1d, 4d, 25d)]
    [TestCase(1d, 3d, 33.33333333333333d)]
    [TestCase(0d, 100d, 0d)]
    [TestCase(100d, 0d, 0d)]
    [TestCase(0.1d + 0.2d - 0.3d, 100d, 0d)]
    [TestCase(100d, 0.1d + 0.2d - 0.3d, 0d)]
    [TestCase(-25d, 100d, -25d)]
    [TestCase(25d, -100d, -25d)]
    [TestCase(150d, 100d, 150d)]
    public void AsPercentageOf_Double_ReturnsExpectedOutput(double proportion, double total, double expectedOutput)
    {
        // Act
        var result = proportion.AsPercentageOf(total);

        // Assert
        Assert.That(result, Is.EqualTo(expectedOutput).Within(0.00000000000001d));
    }
}
