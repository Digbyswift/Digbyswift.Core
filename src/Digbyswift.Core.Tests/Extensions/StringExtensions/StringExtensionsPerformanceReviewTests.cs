using System;
using System.Linq;
using Digbyswift.Core.Constants;
using Digbyswift.Core.Extensions;
using NUnit.Framework;

namespace Digbyswift.Core.Tests.Extensions.StringExtensions;

[TestFixture]
public class StringExtensionsPerformanceReviewTests
{
    [Test]
    public void TruncateAtWord_ReturnsInput_WhenLengthEqualsInputLength()
    {
        // Arrange
        const string input = "Hello world";

        // Act
        var result = input.TruncateAtWord(input.Length, "...");

        // Assert
        Assert.That(result, Is.SameAs(input));
    }

    [Test]
    public void TruncateAtWord_ReturnsSuffix_WhenLengthIsZero()
    {
        // Act
        var result = "Hello world".TruncateAtWord(0, "...");

        // Assert
        Assert.That(result, Is.EqualTo("..."));
    }

    [Test]
    public void TruncateAtWord_Throws_WhenLengthIsNegative()
    {
        // Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => "Hello world".TruncateAtWord(-1));
    }

    [Test]
    public void TruncateAtWord_DoesNotAppendSuffix_WhenResultAlreadyEndsWithAPeriod()
    {
        // Act
        var result = "Hello. World".TruncateAtWord(6, "...");

        // Assert
        Assert.That(result, Is.EqualTo("Hello."));
    }

    [TestCase("false", true, false)]
    [TestCase("true", false, true)]
    [TestCase("not a bool", true, true)]
    [TestCase("not a bool", false, false)]
    public void ToBool_ReturnsParsedBoolBeforeDefaultValue(string input, bool defaultValue, bool expectedResult)
    {
        // Act
        var result = input.ToBool(defaultValue);

        // Assert
        Assert.That(result, Is.EqualTo(expectedResult));
    }

    [Test]
    public void ReplaceExcess_ReturnsSameInstance_WhenNoReplacementIsNeeded()
    {
        // Arrange
        const string input = "a-b-c";

        // Act
        var result = input.ReplaceExcess(CharConstants.Hyphen, CharConstants.Hyphen);

        // Assert
        Assert.That(result, Is.SameAs(input));
    }

    [Test]
    public void ReplaceExcess_Throws_WhenMinimumOccurrencesIsLessThanOne()
    {
        // Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => "abc".ReplaceExcess('a', 'b', 0));
    }

    [Test]
    public void RemoveWhitespace_ReturnsSameInstance_WhenNoWhitespaceIsPresent()
    {
        // Arrange
        const string input = "abc";

        // Act
        var result = input.RemoveWhitespace();

        // Assert
        Assert.That(result, Is.SameAs(input));
    }

    [Test]
    public void RemoveWhitespace_RemovesAllWhitespace()
    {
        // Act
        var result = " a\tb\r\nc ".RemoveWhitespace();

        // Assert
        Assert.That(result, Is.EqualTo("abc"));
    }

    [Test]
    public void TrimWithin_ReturnsSameInstance_WhenNoTrimOrWhitespaceNormalizationIsNeeded()
    {
        // Arrange
        const string input = "abc def";

        // Act
        var result = input.TrimWithin();

        // Assert
        Assert.That(result, Is.SameAs(input));
    }

    [Test]
    public void TrimWithin_TrimsAndCollapsesWhitespace()
    {
        // Act
        var result = " \tabc\n\r  def\n  ".TrimWithin();

        // Assert
        Assert.That(result, Is.EqualTo("abc def"));
    }

    [Test]
    public void TrimWithin_NormalizesSingleNonSpaceWhitespace()
    {
        // Act
        var result = "abc\tdef".TrimWithin();

        // Assert
        Assert.That(result, Is.EqualTo("abc def"));
    }

    [Test]
    public void SplitAndTrim_RemovesEmptyEntriesAndTrimsEntries()
    {
        // Act
        var result = " one, two ,, three ".SplitAndTrim(CharConstants.Comma).ToArray();

        // Assert
        Assert.That(result, Is.EqualTo(["one", "two", "three"]));
    }

    [Test]
    public void ToUrlFriendly_UsesInvariantCasing()
    {
        // Act
        var result = "TITLE WITH SPACES".ToUrlFriendly();

        // Assert
        Assert.That(result, Is.EqualTo("title-with-spaces"));
    }

#if NET8_0_OR_GREATER
    [Test]
    public void FastPathStringMethods_DoNotAllocate_WhenNoChangeIsNeeded()
    {
        // Arrange
        const string input = "abc";
        _ = input.TrimWithin();
        _ = input.RemoveWhitespace();
        _ = input.ReplaceExcess(CharConstants.Hyphen, CharConstants.Hyphen);

        // Act
        var before = GC.GetAllocatedBytesForCurrentThread();
        _ = input.TrimWithin();
        _ = input.RemoveWhitespace();
        _ = input.ReplaceExcess(CharConstants.Hyphen, CharConstants.Hyphen);
        var allocatedBytes = GC.GetAllocatedBytesForCurrentThread() - before;

        // Assert
        Assert.That(allocatedBytes, Is.Zero);
    }
#endif
}
