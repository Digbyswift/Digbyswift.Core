using Digbyswift.Core.Extensions;
using NUnit.Framework;

namespace Digbyswift.Core.Tests.Extensions.StringExtensions;

[TestFixture]
public class ToBoolTests
{
    private const string Testing = "Testing";

    [TestCase("True", true)]
    [TestCase("true", true)]
    public void ToBool_ReturnsTrue_WhenValueIsTrue(string source, bool expectedResult)
    {
        // Arrange & Act
        var result = source.ToBool(null);

        // Assert
        Assert.That(result, Is.True);
    }

    [TestCase("False", false)]
    [TestCase("false", false)]
    public void ToBool_ReturnsFalse_WhenValueIsFalse(string source, bool expectedResult)
    {
        // Arrange & Act
        var result = source.ToBool(null);

        // Assert
        Assert.That(result, Is.False);
    }

    [TestCase("", false)]
    [TestCase(Testing, false)]
    public void ToBool_ReturnsFalse_WhenValueIsEmptyOrInvalid(string source, bool expectedResult)
    {
        // Arrange & Act
        var result = source.ToBool(null);

        // Assert
        Assert.That(result, Is.EqualTo(expectedResult));
    }

    [TestCase("", false)]
    [TestCase(Testing, false)]
    public void ToBool_ReturnsDefault_WhenValueIsEmptyOrInvalid(string source, bool expectedResult)
    {
        // Arrange
        bool defaultValue = true;

        // Act
        var result = source.ToBool(defaultValue);

        // Assert
        Assert.That(result, Is.True);
    }

    [TestCase("", false)]
    [TestCase(Testing, false)]
    public void ToBool_ReturnsFalse_WhenValueIsEmptyOrInvalid_AndNoDefaultSupplied(string source, bool expectedResult)
    {
        // Arrange & Act
        var result = source.ToBool(null);

        // Assert
        Assert.That(result, Is.False);
    }
}