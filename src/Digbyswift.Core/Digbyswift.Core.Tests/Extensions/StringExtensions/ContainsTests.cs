using System;
using System.Collections.Generic;
using Digbyswift.Core.Extensions;
using NUnit.Framework;

namespace Digbyswift.Core.Tests.Extensions.StringExtensions;

[TestFixture]
public class ContainsTests
{
    private const string TestingLowercase = "testing";
    private const string TestingContainingText = "Testing a string that contains text";

    [Test]
    public void Contains_ReturnsTrue_WhenValueIsWithinSourceWord()
    {
        // Arrange
        const string match = "ring";

        // Act
        var result = TestingContainingText.Contains(match);

        // Assert
        Assert.IsTrue(result);
    }

    [Test]
    public void Contains_ReturnsFalse_WhenValueIsWithinSource_ButNotTheSameCase()
    {
        // Arrange
        string? source = TestingContainingText;

        // Act
        var result = source.Contains(TestingLowercase);

        // Assert
        Assert.IsFalse(result);
    }

    [Test]
    public void Contains_ReturnsTrue_WhenValueIsWithinSource_ButNotTheSameCase_AndOrdinalCaseSpecified()
    {
        // Arrange & Act
        var result = TestingContainingText.Contains(TestingLowercase, StringComparison.OrdinalIgnoreCase);

        // Assert
        Assert.IsTrue(result);
    }

    [Test]
    public void ContainsIgnoreCase_ReturnsTrue_WhenValueIsWithinSource()
    {
        // Arrange
        string? source = TestingContainingText;
        var match = "text";

        // Act
        var result = source.ContainsIgnoreCase(match);

        // Assert
        Assert.IsTrue(result);
    }

    [Test]
    public void ContainsIgnoreCase_ReturnsTrue_WhenValueIsWithinSourceWord()
    {
        // Arrange
        string? source = TestingContainingText;
        var match = "ring";

        // Act
        var result = source.ContainsIgnoreCase(match);

        // Assert
        Assert.IsTrue(result);
    }

    [Test]
    public void ContainsIgnoreCase_ReturnsTrue_WhenValueIsWithinList()
    {
        // Arrange
        var source = new List<string>
        {
            TestingContainingText,
            String.Empty,
            "Testing another"
        };

        var match = "another";

        // Act
        var result = source.ContainsIgnoreCase(match);

        // Assert
        Assert.IsTrue(result);
    }

    [Test]
    public void ContainsIgnoreCase_ReturnsTrue_WhenPhraseIsWithinList()
    {
        // Arrange
        var source = new List<string>
        {
            TestingContainingText,
            String.Empty,
            "Testing another"
        };

        var match = "Testing another";

        // Act
        var result = source.ContainsIgnoreCase(match);

        // Assert
        Assert.IsTrue(result);
    }

    [Test]
    public void ContainsIgnoreCase_ReturnsTrue_WhenValueIsWithinWord_WithinListOfWords()
    {
        // Arrange
        var source = new List<string>
        {
            TestingContainingText,
            String.Empty,
            "Testing another"
        };

        var match = "ring";

        // Act
        var result = source.ContainsIgnoreCase(match);

        // Assert
        Assert.IsTrue(result);
    }
}