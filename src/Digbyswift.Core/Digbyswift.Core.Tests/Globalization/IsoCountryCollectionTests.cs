using System.Collections.Generic;
using Digbyswift.Core.Globalization;
using NUnit.Framework;

namespace Digbyswift.Core.Tests.Globalization;

[TestFixture]
public class IsoCountryCollectionTests
{
        
    [Test]
    public void Items_HasConstantCountValue()
    {
        // Arrange
        const int expectedCountryCount = 249;
            
        // Act
        var countryCount = IsoCountryCollection.Items.Count;
            
        // Assert
        Assert.That(countryCount, Is.EqualTo(expectedCountryCount));
    }
        
    [Test]
    public void Items_IsReadonly()
    {
        // Assert
        Assert.That(IsoCountryCollection.Items is IReadOnlyCollection<IsoCountry>, Is.True);
    }
        
}