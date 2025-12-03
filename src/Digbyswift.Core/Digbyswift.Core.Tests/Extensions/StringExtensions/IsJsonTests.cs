using System;
using Digbyswift.Core.Extensions.Validation;
using NUnit.Framework;

namespace Digbyswift.Core.Tests.Extensions.StringExtensions;

[TestFixture]
public class IsJsonTests
{
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
}
