using Digbyswift.Core.Extensions.ThirdParty;
using NUnit.Framework;

namespace Digbyswift.Core.Tests.Extensions.ThirdParty;

[TestFixture]
[TestOf(typeof(LoqateStringExtensions))]
public class LoqateStringExtensionsTest
{
    #region IsLoqateAddressId

    // Using example from https://docs.loqate.com/api-reference/address-capture/geolocation

    [TestCase("RG|131147105004049155081056163145037055217164007108")]
    public void IsLoqateAddressId(string source)
    {
        // Arrange & Act
        var result = source.IsLoqateAddressId();

        // Assert
        Assert.That(result, Is.True);
    }

    #endregion

    #region IsLoqateContainerId

    [TestCase("GB|RM|B|57882040|ENG")]
    public void IsLoqateContainerId_ReturnsTrue_WhenIdIsWithinQuerystring(string source)
    {
        // Arrange & Act
        var result = source.IsLoqateContainerId();

        // Assert
        Assert.That(result, Is.True);
    }

    [TestCase("US|RM|B|57882040|ENG")]
    public void IsLoqateContainerId_ReturnsFalse_WhenRegionCodeIsNotGB(string source)
    {
        // Arrange & Act
        var result = source.IsLoqateContainerId();

        // Assert
        Assert.That(result, Is.False);
    }

    [TestCase("GB|RM|B|ENG")]
    public void IsLoqateContainerId_ReturnsFalse_WhenQuerystringIsIncomplete(string source)
    {
        // Arrange & Act
        var result = source.IsLoqateContainerId();

        // Assert
        Assert.That(result, Is.False);
    }

    #endregion
}