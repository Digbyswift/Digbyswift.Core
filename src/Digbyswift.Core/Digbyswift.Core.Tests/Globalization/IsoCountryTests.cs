using System;
using Digbyswift.Core.Globalization;
using NUnit.Framework;

namespace Digbyswift.Core.Tests.Globalization
{
    [TestFixture]
    public class IsoCountryTests
    {
        
        [Test]
        public void Ctor_PropertiesAreSet_WhenMandatoryParametersAreProvided()
        {
            // Arrange
            const string name = "Test Name";
            const string alpha2 = "TN";
            const string alpha3 = "TNM";
            const int numericCode = 123;
            
            // Act
            var sut = new IsoCountry(name, alpha2, alpha3, numericCode);
            
            // Assert
            Assert.That(sut.Name, Is.EqualTo(name));
            Assert.That(sut.Alpha2, Is.EqualTo(alpha2));
            Assert.That(sut.Alpha3, Is.EqualTo(alpha3));
            Assert.That(sut.NumericCode, Is.EqualTo(numericCode));
        }

        [Test]
        public void Ctor_Throws_WhenNameIsNull()
        {
            // Arrange
            const string name = (string)null;
            const string alpha2 = "TN";
            const string alpha3 = "TNM";
            const int numericCode = 123;
            
            // Assert
            Assert.Throws<ArgumentException>(() => new IsoCountry(name, alpha2, alpha3, numericCode));
        }

        [Test]
        public void Ctor_Throws_WhenAlpha2IsNull()
        {
            // Arrange
            const string name = "Test Name";
            const string alpha2 = (string)null;
            const string alpha3 = "TNM";
            const int numericCode = 123;
            
            // Assert
            Assert.Throws<ArgumentException>(() => new IsoCountry(name, alpha2, alpha3, numericCode));
        }

        [Test]
        public void Ctor_Throws_WhenAlpha3IsNull()
        {
            // Arrange
            const string name = "Test Name";
            const string alpha2 = "TN";
            const string alpha3 = (string)null;
            const int numericCode = 123;
            
            // Assert
            Assert.Throws<ArgumentException>(() => new IsoCountry(name, alpha2, alpha3, numericCode));
        }

        [TestCase("")]
        [TestCase("X")]
        [TestCase("XXX")]
        [TestCase("XXXX")]
        public void Ctor_Throws_WhenAlpha2IsInvalidLength(string alpha2)
        {
            // Arrange
            const string name = "Test Name";
            const string alpha3 = "TNM";
            const int numericCode = 123;
            
            // Assert
            Assert.Throws<ArgumentException>(() => new IsoCountry(name, alpha2, alpha3, numericCode));
        }


        [TestCase("")]
        [TestCase("X")]
        [TestCase("XX")]
        [TestCase("XXXX")]
        public void Ctor_Throws_WhenAlpha3IsInvalidLength(string alpha3)
        {
            // Arrange
            const string name = "Test Name";
            const string alpha2 = "TN";
            const int numericCode = 123;
            
            // Assert
            Assert.Throws<ArgumentException>(() => new IsoCountry(name, alpha2, alpha3, numericCode));
        }

        [TestCase(0)]
        [TestCase(-1)]
        public void Ctor_Throws_WhenNumericCodeIsZeroOrLess(int numericCode)
        {
            // Arrange
            const string name = "Test Name";
            const string alpha2 = "TN";
            const string alpha3 = "TNM";
            
            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new IsoCountry(name, alpha2, alpha3, numericCode));
        }
        
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("  ")]
        public void Ctor_Throws_WhenShortNameIsEmptyOrWhiteSpace(string shortName)
        {
            // Arrange
            const string name = "Test Name";
            const string alpha2 = "TN";
            const string alpha3 = "TNM";
            const int numericCode = 123;
            
            // Assert
            Assert.Throws<ArgumentException>(() => new IsoCountry(name, alpha2, alpha3, numericCode, shortName: shortName));
        }
        
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("  ")]
        public void Ctor_Throws_WhenAbbreviationIsEmptyOrWhiteSpace(string abbreviation)
        {
            // Arrange
            const string name = "Test Name";
            const string alpha2 = "TN";
            const string alpha3 = "TNM";
            const int numericCode = 123;
            
            // Assert
            Assert.Throws<ArgumentException>(() => new IsoCountry(name, alpha2, alpha3, numericCode, abbreviation: abbreviation));
        }
        
        [Test]
        public void ShortName_FallsBackToName_WhenNotProvided()
        {
            // Arrange
            const string name = "Test Name";
            const string alpha2 = "TN";
            const string alpha3 = "TNM";
            const int numericCode = 123;
            
            // Act
            var sut = new IsoCountry(name, alpha2, alpha3, numericCode);
            
            // Assert
            Assert.That(sut.ShortName, Is.EqualTo(name));
        }
        
        [Test]
        public void ShortName_IsExpectedValue_WhenProvided()
        {
            // Arrange
            const string name = "Test Name";
            const string shortName = "Test Short Name";
            const string alpha2 = "TN";
            const string alpha3 = "TNM";
            const int numericCode = 123;
            
            // Act
            var sut = new IsoCountry(name, alpha2, alpha3, numericCode, shortName: shortName);
            
            // Assert
            Assert.That(sut.ShortName, Is.EqualTo(shortName));
        }
        
        [Test]
        public void Abbreviation_IsNull_WhenNotProvided()
        {
            // Arrange
            const string name = "Test Name";
            const string alpha2 = "TN";
            const string alpha3 = "TNM";
            const int numericCode = 123;
            
            // Act
            var sut = new IsoCountry(name, alpha2, alpha3, numericCode);
            
            // Assert
            Assert.That(sut.Abbreviation, Is.Null);
        }
        
        [Test]
        public void Abbreviation_IsExpectedValue_WhenProvided()
        {
            // Arrange
            const string name = "Test Name";
            const string abbreviation = "TNA";
            const string alpha2 = "TN";
            const string alpha3 = "TNM";
            const int numericCode = 123;
            
            // Act
            var sut = new IsoCountry(name, alpha2, alpha3, numericCode, abbreviation: abbreviation);
            
            // Assert
            Assert.That(sut.Abbreviation, Is.EqualTo(abbreviation));
        }
        
   }
}