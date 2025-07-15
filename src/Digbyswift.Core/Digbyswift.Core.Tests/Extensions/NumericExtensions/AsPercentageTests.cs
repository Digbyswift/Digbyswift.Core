using System.Collections.Generic;
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

    [TestCaseSource(nameof(PercentageTestTestDataWithDecimals))]
    public void AsPercentageOf_ReturnsCorrectPercentage(PercentageTestData testData)
    {
        // Arrange & Act
        var result = testData.Source.AsPercentageOf(testData.Total);

        // Assert
        Assert.That(result, Is.EqualTo(testData.Percentage));
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

    private static IEnumerable<PercentageTestData> PercentageTestTestDataWithDecimals()
    {
        yield return new PercentageTestData(100.0000m, 1000.00000m, 10);
        yield return new PercentageTestData(0.0000m, 1000.0000m, 0);
        yield return new PercentageTestData(1000.0000m, 1000.00000m, 100);
    }

    public class PercentageTestData(decimal source, decimal total, int percentage)
    {
        public decimal Source { get; } = source;
        public decimal Total { get; } = total;
        public int Percentage { get; } = percentage;
    }
}