using Digbyswift.Core.Extensions;
using NUnit.Framework;

namespace Digbyswift.Core.Tests.Extensions.NumericExtensions;

[TestFixture]
public class IsZeroTests
{
    [TestCase(0d)]
    [TestCase(0.0d)]
    [TestCase(-0d)]
    public void IsZero_ReturnsTrue_WhenValueIsZero(double source)
    {
        // Arrange & Act
        var result = source.IsZero();

        // Assert
        Assert.That(result, Is.True);
    }

    [TestCase(0.1d)]
    [TestCase(1d)]
    [TestCase(-1d)]
    public void IsZero_ReturnsFalse_WhenValueIsNotZero(double source)
    {
        // Arrange & Act
        var result = source.IsZero();

        // Assert
        Assert.That(result, Is.False);
    }
}