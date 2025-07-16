using System.Collections.Generic;
using Digbyswift.Core.Extensions;
using NUnit.Framework;

namespace Digbyswift.Core.Tests.Extensions.NumericExtensions;

[TestFixture]
public class AsPercentageTests
{
    [TestCase(0, 0, 0d)]
    [TestCase(0, 100, 0d)]
    [TestCase(10, -100, -10d)]
    [TestCase(10, 100, 10d)]
    [TestCase(17, 100, 17d)]
    [TestCase(100, 100, 100d)]
    [TestCase(120, 100, 120d)]
    [TestCase(-120, 100, -120d)]
    public void AsPercentageOf_ReturnsCorrectPercentage_WhenSourceIsAnInteger(int source, int total, double expectedPercentage)
    {
        // Arrange & Act
        var result = source.AsPercentageOf(total);

        // Assert
        Assert.That(result, Is.EqualTo(expectedPercentage));
    }

    [TestCase(0d, 0d, 0d)]
    [TestCase(0d, 100d, 0d)]
    [TestCase(10d, -100d, -10d)]
    [TestCase(10d, 100d, 10d)]
    [TestCase(100d, 100d, 100d)]
    [TestCase(120d, 100d, 120d)]
    [TestCase(-120d, 100d, -120d)]
    [TestCase(double.Epsilon, 100d, 0.00d)]
    public void AsPercentageOf_ReturnsCorrectPercentage_WhenSourceIsDouble(double source, double total, double expectedPercentage)
    {
        // Arrange & Act
        var result = source.AsPercentageOf(total);

        // Assert
        Assert.That(result, Is.EqualTo(expectedPercentage));
    }

    [Test]
    public void AsPercentageOf_ReturnsPositiveInfinityPercentage_WhenSourceIsDoubleAndPositiveInfinity()
    {
        // Arrange & Act
        var result = double.PositiveInfinity.AsPercentageOf(100d);

        // Assert
        Assert.That(result, Is.EqualTo(double.PositiveInfinity));
    }

    [Test]
    public void AsPercentageOf_ReturnsNegativeInfinityPercentage_WhenSourceIsDoubleAndNegativeInfinity()
    {
        // Arrange & Act
        var result = double.NegativeInfinity.AsPercentageOf(100d);

        // Assert
        Assert.That(result, Is.EqualTo(double.NegativeInfinity));
    }

    [TestCaseSource(nameof(PercentageTestTestDataWithDecimals))]
    public void AsPercentageOf_ReturnsCorrectPercentage_WhenSourceIsPercentage(PercentageTestData testData)
    {
        // Arrange & Act
        var result = testData.Source.AsPercentageOf(testData.Total);

        // Assert
        Assert.That(result, Is.EqualTo(testData.ExpectedPercentage));
    }

    private static IEnumerable<PercentageTestData> PercentageTestTestDataWithDecimals()
    {
        yield return new PercentageTestData(0.0000m, 100.0000m, 0);
        yield return new PercentageTestData(10.0000m, 100.00000m, 10);
        yield return new PercentageTestData(10.0000m, -100.00000m, -10);
        yield return new PercentageTestData(100.0000m, 100.00000m, 100);
        yield return new PercentageTestData(120.0000m, 100.00000m, 120);
        yield return new PercentageTestData(-120.0000m, 100.00000m, -120);
    }

    public class PercentageTestData(decimal source, decimal total, int percentage)
    {
        public decimal Source { get; } = source;
        public decimal Total { get; } = total;
        public int ExpectedPercentage { get; } = percentage;
    }
}