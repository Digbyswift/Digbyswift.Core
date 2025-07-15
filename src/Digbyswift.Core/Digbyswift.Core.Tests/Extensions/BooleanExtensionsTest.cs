using Digbyswift.Core.Constants;
using Digbyswift.Core.Extensions;
using NUnit.Framework;

namespace Digbyswift.Core.Tests.Extensions;

[TestFixture]
public class BooleanExtensionsTest
{
    private const string Testing = "Testing";

    [Test]
    public void AsYesNo_ReturnsYes_WhenTrueIsPassed()
    {
        // Arrange & Act
        var result = true.AsYesNo();

        // Assert
        Assert.That(result, Is.EqualTo(StringConstants.Yes));
    }

    [Test]
    public void AsYesNo_ReturnsNo_WhenFalseIsPassed()
    {
        // Arrange & Act
        var result = false.AsYesNo();

        // Assert
        Assert.That(result, Is.EqualTo(StringConstants.No));
    }

    [Test]
    public void AsYesNo_ReturnsNullString_WhenNullIsPassed()
    {
        // Arrange
        bool? source = null;

        // Act
        var result = source.AsYesNo();

        // Assert
        Assert.IsNull(result);
    }

    [Test]
    public void AsYesNo_ReturnsFallbackParameterValue_WhenSourceIsNull()
    {
        // Arrange
        bool? source = null;

        // Act
        var result = source.AsYesNo(Testing);

        // Assert
        Assert.That(result, Is.EqualTo(Testing));
    }
}