using Digbyswift.Core.Extensions;
using NUnit.Framework;

namespace Digbyswift.Core.Tests.Extensions.NumericExtensions;

[TestFixture]
public class IsEvenTests
{
    [TestCase(2)]
    [TestCase(-10)]
    public void IsEven_ReturnsTrue_WhenValueIsEven(int source)
    {
        // Arrange & Act
        var result = source.IsEven();

        // Assert
        Assert.IsTrue(result);
    }

    [TestCase(1)]
    [TestCase(-11)]
    public void IsEven_ReturnsFalse_WhenValueIsNotEven(int source)
    {
        // Arrange & Act
        var result = source.IsEven();

        // Assert
        Assert.IsFalse(result);
    }
}