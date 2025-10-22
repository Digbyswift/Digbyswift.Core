using System;
using Digbyswift.Core.Globalization;
using NUnit.Framework;

namespace Digbyswift.Core.Tests.Globalization;

[TestFixture]
public class IsoCountryTests
{
    private const string Name = "Test Name";
    private const string ShortName = "Test Short Name";
    private const string Alpha2 = "TN";
    private const string Alpha3 = "TNM";
    private const int NumericCode = 123;

    [Test]
    public void Ctor_PropertiesAreSet_WhenMandatoryParametersAreProvided()
    {
        // Arrange & Act
        var sut = new IsoCountry(Name, Alpha2, Alpha3, NumericCode);

        // Assert
        Assert.That(sut.Name, Is.EqualTo(Name));
        Assert.That(sut.Alpha2, Is.EqualTo(Alpha2));
        Assert.That(sut.Alpha3, Is.EqualTo(Alpha3));
        Assert.That(sut.NumericCode, Is.EqualTo(NumericCode));
    }

#if NET48
    [Test]
    public void Ctor_Throws_WhenNameIsNull()
    {
        // Arrange & Assert
        Assert.Throws<ArgumentException>(() => new IsoCountry(null, Alpha2, Alpha3, NumericCode));
    }

    [Test]
    public void Ctor_Throws_WhenAlpha2IsNull()
    {
        // Arrange & Assert
        Assert.Throws<ArgumentException>(() => new IsoCountry(Name, null, Alpha3, NumericCode));
    }

    [Test]
    public void Ctor_Throws_WhenAlpha3IsNull()
    {
        // Arrange & Assert
        Assert.Throws<ArgumentException>(() => new IsoCountry(Name, Alpha2, null, NumericCode));
    }
#endif

    [TestCase("")]
    [TestCase("X")]
    [TestCase("XXX")]
    [TestCase("XXXX")]
    public void Ctor_Throws_WhenAlpha2IsInvalidLength(string alpha2)
    {
        // Arrange & Assert
        Assert.Throws<ArgumentException>(() => new IsoCountry(Name, alpha2, Alpha3, NumericCode));
    }

    [TestCase("")]
    [TestCase("X")]
    [TestCase("XX")]
    [TestCase("XXXX")]
    public void Ctor_Throws_WhenAlpha3IsInvalidLength(string alpha3)
    {
        // Arrange & Assert
        Assert.Throws<ArgumentException>(() => new IsoCountry(Name, Alpha2, alpha3, NumericCode));
    }

    [TestCase(0)]
    [TestCase(-1)]
    public void Ctor_Throws_WhenNumericCodeIsZeroOrLess(int numericCode)
    {
        // Arrange & Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => new IsoCountry(Name, Alpha2, Alpha3, numericCode));
    }

    [TestCase("")]
    [TestCase(" ")]
    [TestCase("  ")]
    public void Ctor_Throws_WhenShortNameIsEmptyOrWhiteSpace(string shortName)
    {
        // Arrange & Assert
        Assert.Throws<ArgumentException>(() => new IsoCountry(Name, Alpha2, Alpha3, NumericCode, shortName: shortName));
    }

    [TestCase("")]
    [TestCase(" ")]
    [TestCase("  ")]
    public void Ctor_Throws_WhenAbbreviationIsEmptyOrWhiteSpace(string abbreviation)
    {
        // Arrange & Assert
        Assert.Throws<ArgumentException>(() => new IsoCountry(Name, Alpha2, Alpha3, NumericCode, abbreviation: abbreviation));
    }

    [Test]
    public void ShortName_FallsBackToName_WhenNotProvided()
    {
        // Arrange & Act
        var sut = new IsoCountry(Name, Alpha2, Alpha3, NumericCode);

        // Assert
        Assert.That(sut.ShortName, Is.EqualTo(Name));
    }

    [Test]
    public void ShortName_IsExpectedValue_WhenProvided()
    {
        // Arrange & Act
        var sut = new IsoCountry(Name, Alpha2, Alpha3, NumericCode, shortName: ShortName);

        // Assert
        Assert.That(sut.ShortName, Is.EqualTo(ShortName));
    }

    [Test]
    public void Abbreviation_IsNull_WhenNotProvided()
    {
        // Arrange & Act
        var sut = new IsoCountry(Name, Alpha2, Alpha3, NumericCode);

        // Assert
        Assert.That(sut.Abbreviation, Is.Null);
    }

    [Test]
    public void Abbreviation_IsExpectedValue_WhenProvided()
    {
        // Arrange
        const string abbreviation = "TNA";

        // Act
        var sut = new IsoCountry(Name, Alpha2, Alpha3, NumericCode, abbreviation: abbreviation);

        // Assert
        Assert.That(sut.Abbreviation, Is.EqualTo(abbreviation));
    }
}
