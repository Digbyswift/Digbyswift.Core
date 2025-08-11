using Digbyswift.Core.Extensions.ThirdParty;
using NUnit.Framework;

namespace Digbyswift.Core.Tests.Extensions.ThirdParty;

[TestFixture]
[TestOf(typeof(LoqateStringExtensions))]
public class LoqateStringExtensionsTest
{
    #region IsLoqateAddressId

    // Is test case correct?
    [TestCase("https://example.test.com/api/loqate/search/?query=%20LS1%202HL&type=postcode")]
    [TestCase("https://example.test.com/api/loqate/get/?id=GB|RM|B|57882040|ENG")]
    public void IsLoqateAddressId(string source)
    {
        // Arrange & Act
        var result = source.IsLoqateAddressId();

        // Assert
        Assert.That(result, Is.True);
    }

    #endregion

    #region IsLoqateContainerId

    // Is test case correct?
    [TestCase("https://example.test.com/api/loqate/get/?id=GB|RM|B|57882040|ENG")]
    public void IsLoqateContainerId_ReturnsTrue_WhenIdIsWithinQuerystring(string source)
    {
        // Arrange & Act
        var result = source.IsLoqateContainerId();

        // Assert
        Assert.That(result, Is.True);
    }

    [TestCase("https://example.test.com/api/loqate/get/?id=GB|RM|B|57882040|ENG")]
    public void IsLoqateContainerId_ReturnsFalse_WhenRegionCodeIsNotGB(string source)
    {
        // Arrange & Act
        var result = source.IsLoqateContainerId();

        // Assert
        Assert.That(result, Is.False);
    }

    [TestCase("https://example.test.com/api/loqate/get/?id=GB|RM|B|ENG")]
    public void IsLoqateContainerId_ReturnsFalse_WhenQuerystringIsIncomplete(string source)
    {
        // Arrange & Act
        var result = source.IsLoqateContainerId();

        // Assert
        Assert.That(result, Is.False);
    }

    #endregion
}