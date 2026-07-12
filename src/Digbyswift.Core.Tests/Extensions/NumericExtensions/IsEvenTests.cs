using Digbyswift.Core.Extensions;
using NUnit.Framework;

namespace Digbyswift.Core.Tests.Extensions.NumericExtensions;

[TestFixture]
public class IsEvenTests
{
    [TestCase(0)]
    [TestCase(2)]
    [TestCase(-2)]
    [TestCase(100)]
    [TestCase(int.MinValue)]
    public void IsEven_WithEvenValues_ReturnsTrue(int value)
    {
        // Act
        var result = value.IsEven();

        // Assert
        Assert.That(result, Is.True);
    }

    [TestCase(1)]
    [TestCase(-1)]
    [TestCase(99)]
    [TestCase(int.MaxValue)]
    public void IsEven_WithOddValues_ReturnsFalse(int value)
    {
        // Act
        var result = value.IsEven();

        // Assert
        Assert.That(result, Is.False);
    }
}
