using Digbyswift.Core.Extensions;
using NUnit.Framework;

namespace Digbyswift.Core.Tests.Extensions.NumericExtensions;

[TestFixture]
public class AsPercentageTests
{
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
}