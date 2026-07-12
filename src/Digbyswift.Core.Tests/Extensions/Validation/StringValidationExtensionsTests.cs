using Digbyswift.Core.Extensions.Validation;
using NUnit.Framework;

namespace Digbyswift.Core.Tests.Extensions.Validation;

[TestFixture]
[TestOf(typeof(StringValidationExtensions))]
public class StringValidationExtensionsTests
{
    #region HasFileExtension

    [TestCase("file.txt")]
    [TestCase("document.pdf")]
    [TestCase("image.jpg")]
    [TestCase("archive.tar.gz")]
    [TestCase("script.min.js")]
    [TestCase("file.ABC")]
    [TestCase("file.a1b2")]
    [TestCase("file.a-b")]
    [TestCase("file.a_b")]
    public void HasFileExtension_WithValidExtension_ReturnsTrue(string value)
    {
        // Act
        var result = value.HasFileExtension();

        // Assert
        Assert.That(result, Is.True);
    }

    [TestCase("filename")]
    [TestCase("no-extension")]
    [TestCase("file.")]
    [TestCase(".")]
    [TestCase("...")]
    [TestCase("file ")]
    [TestCase(" ")]
    public void HasFileExtension_WithoutExtension_ReturnsFalse(string value)
    {
        // Act
        var result = value.HasFileExtension();

        // Assert
        Assert.That(result, Is.False);
    }

#if !NET8_0_OR_GREATER
    [Test]
    public void HasFileExtension_WithNull_ReturnsFalse()
    {
        // Arrange
        string value = null;

        // Act
        var result = value.HasFileExtension();

        // Assert
        Assert.That(result, Is.False);
    }
#endif

    [Test]
    public void HasFileExtension_WithEmptyString_ReturnsFalse()
    {
        // Arrange
        var value = String.Empty;

        // Act
        var result = value.HasFileExtension();

        // Assert
        Assert.That(result, Is.False);
    }

    #endregion

    #region IsEmail

    [TestCase("test@example.com")]
    [TestCase("user.name@example.com")]
    [TestCase("user+tag@example.co.uk")]
    [TestCase("firstname.lastname@example.com")]
    [TestCase("email@subdomain.example.com")]
    [TestCase("user_name@example.com")]
    [TestCase("1234567890@example.com")]
    [TestCase("email@example-one.com")]
    public void IsEmail_WithValidEmail_ReturnsTrue(string value)
    {
        // Act
        var result = value.IsEmail();

        // Assert
        Assert.That(result, Is.True);
    }

    [TestCase("plaintext")]
    [TestCase("@example.com")]
    [TestCase("user@")]
    [TestCase("user @example.com")]
    [TestCase("user@.com")]
    [TestCase("user..name@example.com")]
    [TestCase("user@example,com")]
    [TestCase("user@example")]
    [TestCase("user name@example.com")]
    public void IsEmail_WithInvalidEmail_ReturnsFalse(string value)
    {
        // Act
        var result = value.IsEmail();

        // Assert
        Assert.That(result, Is.False);
    }

#if !NET8_0_OR_GREATER
    [Test]
    public void IsEmail_WithNull_ReturnsFalse()
    {
        // Arrange
        string value = null;

        // Act
        var result = value.IsEmail();

        // Assert
        Assert.That(result, Is.False);
    }
#endif

    [Test]
    public void IsEmail_WithEmptyString_ReturnsFalse()
    {
        // Arrange
        var value = String.Empty;

        // Act
        var result = value.IsEmail();

        // Assert
        Assert.That(result, Is.False);
    }

    #endregion

    #region IsNumeric

    [TestCase("123")]
    [TestCase("0")]
    [TestCase("-123")]
    [TestCase("123.456")]
    [TestCase("-123.456")]
    [TestCase("0.5")]
    [TestCase("-0.5")]
    [TestCase("999999999")]
    [TestCase("-999999999")]
    public void IsNumeric_WithValidNumericString_ReturnsTrue(string value)
    {
        // Act
        var result = value.IsNumeric();

        // Assert
        Assert.That(result, Is.True);
    }

    [TestCase("abc")]
    [TestCase("12.34.56")]
    [TestCase("123abc")]
    [TestCase("abc123")]
    [TestCase("12 34")]
    [TestCase("12-34")]
    [TestCase("")]
    [TestCase("   ")]
    [TestCase(".")]
    [TestCase("-")]
    public void IsNumeric_WithInvalidNumericString_ReturnsFalse(string value)
    {
        // Act
        var result = value.IsNumeric();

        // Assert
        Assert.That(result, Is.False);
    }

#if !NET8_0_OR_GREATER
    [Test]
    public void IsNumeric_WithNull_ReturnsFalse()
    {
        // Arrange
        string value = null;

        // Act
        var result = value.IsNumeric();

        // Assert
        Assert.That(result, Is.False);
    }
#endif

    [Test]
    public void IsNumeric_WithEmptyString_ReturnsFalse()
    {
        // Arrange
        var value = String.Empty;

        // Act
        var result = value.IsNumeric();

        // Assert
        Assert.That(result, Is.False);
    }

    [TestCase("123")]
    [TestCase("0")]
    [TestCase("-123")]
    [TestCase("999999999")]
    [TestCase("-999999999")]
    public void IsNumeric_WithValidInteger_AndIntegerMatchType_ReturnsTrue(string value)
    {
        // Act
        var result = value.IsNumeric(NumericMatchType.Integer);

        // Assert
        Assert.That(result, Is.True);
    }

    [TestCase("123.456")]
    [TestCase("-123.456")]
    [TestCase("0.5")]
    [TestCase("-0.5")]
    [TestCase("abc")]
    [TestCase("12.34.56")]
    [TestCase("123abc")]
    [TestCase("abc123")]
    [TestCase("12 34")]
    [TestCase("12-34")]
    [TestCase("")]
    [TestCase("   ")]
    [TestCase(".")]
    [TestCase("-")]
    public void IsNumeric_WithInvalidInteger_AndIntegerMatchType_ReturnsFalse(string value)
    {
        // Act
        var result = value.IsNumeric(NumericMatchType.Integer);

        // Assert
        Assert.That(result, Is.False);
    }

    [TestCase("123.456")]
    [TestCase("-123.456")]
    [TestCase("0.5")]
    [TestCase("-0.5")]
    public void IsNumeric_WithValidDecimal_AndDecimalMatchType_ReturnsTrue(string value)
    {
        // Act
        var result = value.IsNumeric(NumericMatchType.Decimal);

        // Assert
        Assert.That(result, Is.True);
    }

    [TestCase("123")]
    [TestCase("0")]
    [TestCase("-123")]
    [TestCase("999999999")]
    [TestCase("-999999999")]
    [TestCase("abc")]
    [TestCase("12.34.56")]
    [TestCase("123abc")]
    [TestCase("abc123")]
    [TestCase("12 34")]
    [TestCase("12-34")]
    [TestCase("")]
    [TestCase("   ")]
    [TestCase(".")]
    [TestCase("-")]
    public void IsNumeric_WithInvalidDecimal_AndDecimalMatchType_ReturnsFalse(string value)
    {
        // Act
        var result = value.IsNumeric(NumericMatchType.Decimal);

        // Assert
        Assert.That(result, Is.False);
    }

    #endregion

    #region IsMarkup

    [TestCase("<div>")]
    [TestCase("<div class=test>text</div> ")]
    [TestCase("  <p>Hello</p>")]
    [TestCase("<html><body></body></html>")]
    [TestCase("<a href='test'>link</a>")]
    [TestCase("<img src='image.jpg' />")]
    [TestCase("<br/>")]
    [TestCase("<span class='test'>text</span>")]
    public void IsMarkup_WithValidMarkup_ReturnsTrue(string value)
    {
        // Act
        var result = value.IsMarkup();

        // Assert
        Assert.That(result, Is.True);
    }

    [TestCase("")]
    [TestCase("     ")]
    [TestCase("plain text")]
    [TestCase("no markup here")]
    [TestCase("less than < symbol")]
    [TestCase("greater than > symbol")]
    [TestCase("< not a tag")]
    [TestCase("> not a tag")]
    [TestCase("text with <incomplete")]
    public void IsMarkup_WithInvalidMarkup_ReturnsFalse(string value)
    {
        // Act
        var result = value.IsMarkup();

        // Assert
        Assert.That(result, Is.False);
    }

#if !NET8_0_OR_GREATER
    [Test]
    public void IsMarkup_WithNull_ReturnsFalse()
    {
        // Arrange
        string value = null;

        // Act
        var result = value.IsMarkup();

        // Assert
        Assert.That(result, Is.False);
    }
#endif

    #endregion

    #region ContainsMarkup

    [TestCase("Some text with <div> markup")]
    [TestCase("Text before <p>paragraph</p> after")]
    [TestCase("<html>Full markup</html> with text")]
    [TestCase("Link: <a href='test'>click here</a> text")]
    [TestCase("Multiple <span>tags</span> in <b>text</b>")]
    public void ContainsMarkup_WithMarkup_ReturnsTrue(string value)
    {
        // Act
        var result = value.ContainsMarkup();

        // Assert
        Assert.That(result, Is.True);
    }

    [TestCase("")]
    [TestCase("     ")]
    [TestCase("plain text without markup")]
    [TestCase("no tags here")]
    [TestCase("less than < symbol only")]
    [TestCase("greater than > symbol only")]
    [TestCase("< incomplete tag")]
    [TestCase("just text")]
    public void ContainsMarkup_WithoutMarkup_ReturnsFalse(string value)
    {
        // Act
        var result = value.ContainsMarkup();

        // Assert
        Assert.That(result, Is.False);
    }

#if !NET8_0_OR_GREATER
    [Test]
    public void ContainsMarkup_WithNull_ReturnsFalse()
    {
        // Arrange
        string value = null;

        // Act
        var result = value.ContainsMarkup();

        // Assert
        Assert.That(result, Is.False);
    }
#endif

    #endregion

    #region IsIsoRegionalLanguage

    [TestCase("en-us")]
    [TestCase("en-US")]
    [TestCase("EN-us")]
    [TestCase("EN-US")]
    [TestCase("fr-fr")]
    [TestCase("de-de")]
    [TestCase("es-es")]
    [TestCase("it-it")]
    [TestCase("pt-br")]
    [TestCase("ja-jp")]
    [TestCase("zh-cn")]
    public void IsIsoRegionalLanguage_WithValidLanguageCode_ReturnsTrue(string value)
    {
        // Act
        var result = value.IsIsoRegionalLanguage();

        // Assert
        Assert.That(result, Is.True);
    }

    [TestCase("en")]
    [TestCase("en_us")]
    [TestCase("en-USA")]
    [TestCase("eng-us")]
    [TestCase("e-us")]
    [TestCase("en-u")]
    [TestCase("en us")]
    [TestCase("en-")]
    [TestCase("-us")]
    [TestCase("123-45")]
    public void IsIsoRegionalLanguage_WithInvalidLanguageCode_ReturnsFalse(string value)
    {
        // Act
        var result = value.IsIsoRegionalLanguage();

        // Assert
        Assert.That(result, Is.False);
    }

#if !NET8_0_OR_GREATER
    [Test]
    public void IsIsoRegionalLanguage_WithNull_ReturnsFalse()
    {
        // Arrange
        string value = null;

        // Act
        var result = value.IsIsoRegionalLanguage();

        // Assert
        Assert.That(result, Is.False);
    }
#endif

    [Test]
    public void IsIsoRegionalLanguage_WithEmptyString_ReturnsFalse()
    {
        // Arrange
        var value = String.Empty;

        // Act
        var result = value.IsIsoRegionalLanguage();

        // Assert
        Assert.That(result, Is.False);
    }

    #endregion

    #region IsHexColor

    [TestCase("#FFF")]
    [TestCase("#fff")]
    [TestCase("#FFFFFF")]
    [TestCase("#ffffff")]
    [TestCase("#000")]
    [TestCase("#123")]
    [TestCase("#abc")]
    [TestCase("#ABC")]
    [TestCase("#123456")]
    [TestCase("#aAbBcC")]
    public void IsHexColor_WithValidHexColor_ReturnsTrue(string value)
    {
        // Act
        var result = value.IsHexColor();

        // Assert
        Assert.That(result, Is.True);
    }

    [TestCase("FFF")]
    [TestCase("FFFFFF")]
    [TestCase("#FF")]
    [TestCase("#FFFF")]
    [TestCase("#FFFFF")]
    [TestCase("#FFFFFFF")]
    [TestCase("#GGG")]
    [TestCase("#GGGGGG")]
    [TestCase("# FFF")]
    [TestCase("#FFF ")]
    [TestCase(" #FFF")]
    [TestCase("#FF F")]
    [TestCase("rgb(255,255,255)")]
    public void IsHexColor_WithInvalidHexColor_ReturnsFalse(string value)
    {
        // Act
        var result = value.IsHexColor();

        // Assert
        Assert.That(result, Is.False);
    }

#if !NET8_0_OR_GREATER
    [Test]
    public void IsHexColor_WithNull_ReturnsFalse()
    {
        // Arrange
        string value = null;

        // Act
        var result = value.IsHexColor();

        // Assert
        Assert.That(result, Is.False);
    }
#endif

    [Test]
    public void IsHexColor_WithEmptyString_ReturnsFalse()
    {
        // Arrange
        var value = String.Empty;

        // Act
        var result = value.IsHexColor();

        // Assert
        Assert.That(result, Is.False);
    }

    #endregion

    #region IsUkTelephone

    [TestCase("07123456789")]
    [TestCase("07123 456789")]
    [TestCase("07123-456-789")]
    [TestCase("0111 222 3333")]
    [TestCase("0111 2223333")]
    [TestCase("+447123456789")]
    [TestCase("+44 7123 456789")]
    [TestCase("+44 111 2223333")]
    [TestCase("00447123456789")]
    [TestCase("0044 7123 456789")]
    [TestCase("02012345678")]
    [TestCase("020 1234 5678")]
    [TestCase("01234567890")]
    [TestCase("(020) 1234 5678")]
    public void IsUkTelephone_WithValidUkPhoneNumber_ReturnsTrue(string value)
    {
        // Act
        var result = value.IsUkTelephone();

        // Assert
        Assert.That(result, Is.True);
    }

    [TestCase("123")]
    [TestCase("12345")]
    [TestCase("+1234567890")]
    [TestCase("0113 265 222")]
    [TestCase("071234567890")]
    [TestCase("+44712345678")]
    [TestCase("phone number")]
    [TestCase("07123-456-78")]
    [TestCase("7123456789")]
    public void IsUkTelephone_WithInvalidPhoneNumber_ReturnsFalse(string value)
    {
        // Act
        var result = value.IsUkTelephone();

        // Assert
        Assert.That(result, Is.False);
    }

#if !NET8_0_OR_GREATER
    [Test]
    public void IsUkTelephone_WithNull_ReturnsFalse()
    {
        // Arrange
        string value = null;

        // Act
        var result = value.IsUkTelephone();

        // Assert
        Assert.That(result, Is.False);
    }
#endif

    [Test]
    public void IsUkTelephone_WithEmptyString_ReturnsFalse()
    {
        // Arrange
        var value = String.Empty;

        // Act
        var result = value.IsUkTelephone();

        // Assert
        Assert.That(result, Is.False);
    }

    #endregion

    #region ContainsUkTelephone

    [TestCase("Call me on 07123456789")]
    [TestCase("My number is 020 1234 5678")]
    [TestCase("Contact: +447123456789")]
    [TestCase("Phone: 0044 7123 456789 for more info")]
    [TestCase("Ring 01234567890 today")]
    [TestCase("Multiple numbers: 07123456789 or 02012345678")]
    public void ContainsUkTelephone_WithPhoneNumber_ReturnsTrue(string value)
    {
        // Act
        var result = value.ContainsUkTelephone();

        // Assert
        Assert.That(result, Is.True);
    }

    [TestCase("")]
    [TestCase("     ")]
    [TestCase("No phone number here")]
    [TestCase("Call 123")]
    [TestCase("Random numbers 1234567890")]
    [TestCase("Just text without phones")]
    public void ContainsUkTelephone_WithoutPhoneNumber_ReturnsFalse(string value)
    {
        // Act
        var result = value.ContainsUkTelephone();

        // Assert
        Assert.That(result, Is.False);
    }

#if !NET8_0_OR_GREATER
    [Test]
    public void ContainsUkTelephone_WithNull_ReturnsFalse()
    {
        // Arrange
        string value = null;

        // Act
        var result = value.ContainsUkTelephone();

        // Assert
        Assert.That(result, Is.False);
    }
#endif

    #endregion

    #region IsJson

#if NET48
    [TestCase(null)]
    [TestCase("")]
    [TestCase(" ")]
    [TestCase(@"
        ")]
    public void IsJson_ReturnsFalse_WhenValueIsNullOrEmpty(string input)
    {
        // Act
        var result = input.IsJson();

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(String.IsNullOrWhiteSpace(input), Is.True);
            Assert.That(result, Is.False);
        });
    }
#endif

    [TestCase("x")]
    [TestCase("asd")]
    [TestCase("x{}x")]
    [TestCase("{}x")]
    [TestCase("x{}")]
    [TestCase("x[]x")]
    [TestCase("x[]")]
    [TestCase("[]x")]
    [TestCase("[}")]
    [TestCase("{]")]
    [TestCase("[")]
    [TestCase("]")]
    [TestCase("{")]
    [TestCase("}")]
    [TestCase("{a}")]
    [TestCase("[a]")]
    [TestCase(" {a} ")]
    [TestCase(" [a] ")]
    public void IsJson_ReturnsFalse_WhenValueCannotBeParsed(string input)
    {
        // Act
        var result = input.IsJson();

        // Assert
        Assert.That(result, Is.False);
    }

    [TestCase("{}")]
    [TestCase("[]")]
    [TestCase(" {} ")]
    [TestCase(" [] ")]
    [TestCase("[[]]")]
    [TestCase("[[],[]]")]
    [TestCase("[{}]")]
    [TestCase("[{},{}]")]
    [TestCase("""{"key":{}}""")]
    [TestCase("""{"key":[]}""")]
    public void IsJson_ReturnsTrue_WhenValueIsValidJson(string input)
    {
        // Act
        var result = input.IsJson();

        // Assert
        Assert.That(result, Is.True);
    }

    #endregion
}
