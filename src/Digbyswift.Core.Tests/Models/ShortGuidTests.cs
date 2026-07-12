using System;
using Digbyswift.Core.Models;
using NUnit.Framework;

namespace Digbyswift.Core.Tests.Models;

[TestFixture]
public class ShortGuidTests
{
    private const string ExpectedStringValue = "AAAAAAAAAAAAAAAAAAAAAA";

    #region Empty

    [Test]
    public void Empty_HasConstantValue()
    {
        // Arrange
        var sut = ShortGuid.Empty;

        // Assert
        Assert.That(sut.ToString(), Is.EqualTo(ExpectedStringValue));
    }

    [Test]
    public void Empty_HasEmptyGuid()
    {
        // Arrange
        var emptyGuid = ShortGuid.Empty.ToGuid();

        // Assert
        Assert.That(emptyGuid, Is.EqualTo(Guid.Empty));
    }

    #endregion

    #region Ctor (No param)

    [Test]
    public void Ctor_GeneratesNonEmptyValue_WhenNoParametersArePassed()
    {
        // Arrange
        var sut = new ShortGuid();

        // Assert
        Assert.That(sut.ToString(), Is.Not.EqualTo(ExpectedStringValue));
        Assert.That(sut.ToGuid(), Is.Not.EqualTo(Guid.Empty));
    }

    [Test]
    public void Ctor_GeneratesUniqueValue_WhenNoParametersArePassed()
    {
        // Arrange
        var sutA = new ShortGuid();
        var sutB = new ShortGuid();

        // Assert
        Assert.That(sutA.ToString(), Is.Not.EqualTo(sutB.ToString()));
        Assert.That(sutA.ToGuid(), Is.Not.EqualTo(sutB.ToGuid()));
        Assert.That(sutA, Is.Not.EqualTo(sutB));
    }

    #endregion

    #region Ctor (Guid param)

    [Test]
    public void Ctor_GeneratesNonEmptyValue_WhenGuidParameterIsPassed()
    {
        // Arrange
        var newGuid = Guid.NewGuid();

        // Act
        var sut = new ShortGuid(newGuid);

        // Assert
        Assert.That(sut.ToGuid(), Is.EqualTo(newGuid));
        Assert.That(sut.ToString(), Is.Not.EqualTo(ExpectedStringValue));
    }

    [Test]
    public void Ctor_GeneratesIdenticalValues_WhenSameGuidParameterIsPassed()
    {
        // Arrange
        var newGuid = Guid.NewGuid();

        // Act
        var sutA = new ShortGuid(newGuid);
        var sutB = new ShortGuid(newGuid);

        // Assert
        Assert.That(sutA.ToString(), Is.EqualTo(sutB.ToString()));
        Assert.That(sutA.ToGuid(), Is.EqualTo(sutB.ToGuid()));
        Assert.That(sutA, Is.EqualTo(sutB));
    }

    [Test]
    public void Ctor_GeneratesEmptyValue_WhenEmptyGuidParameterIsPassed()
    {
        // Arrange
        var emptyGuid = Guid.Empty;

        // Act
        var sut = new ShortGuid(emptyGuid);

        // Assert
        Assert.That(sut.ToString(), Is.EqualTo(ExpectedStringValue));
        Assert.That(sut.ToGuid(), Is.EqualTo(emptyGuid));
        Assert.That(sut, Is.EqualTo(ShortGuid.Empty));
    }

    #endregion

    #region Ctor (String param)

    [TestCase(ExpectedStringValue)]
    [TestCase("AAAAAAAAAAAAAAAAAAAAAA==")]
    public void Ctor_GeneratesEmptyValue_WhenEmptyStringShortGuidParameterIsPassed(string testValue)
    {
        // Act
        var sut = new ShortGuid(testValue);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(sut.ToString(), Is.EqualTo(testValue));
            Assert.That(sut.ToGuid(), Is.EqualTo(Guid.Empty));
        });
    }

    [TestCase("AAAAAAAAAAAAAAAAAAAABB")]
    [TestCase("AAAAAAAAAAAAAAAAAAAABB==")]
    [TestCase("aaaaaaaaaaaaaaaaaaaaaa")]
    [TestCase("jD8dj4ushTYGF4j9Us00ss")]
    [TestCase("jD8dj4ushTYGF4j9Us00ss==")]
    public void Ctor_GeneratesEmptyValues_WhenInvalidStringGuidParameterIsPassed(string testValue)
    {
        // Act
        var sut = new ShortGuid(testValue);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(sut.ToString(), Is.EqualTo(testValue));
            Assert.That(sut.ToGuid(), Is.Not.EqualTo(Guid.Empty));
        });
    }

    [TestCase("{0070409d-a6e8-450e-ab71-bf78a0487c3c}")]
    [TestCase("0070409d-a6e8-450e-ab71-bf78a0487c3c")]
    [TestCase("0070409da6e8450eab71bf78a0487c3c")]
    public void Ctor_Throws_WhenStringGuidParameterIsPassed(string testGuid)
    {
        // Assert
        Assert.Throws<FormatException>(() =>
        {
            new ShortGuid(testGuid);
        });
    }

    #endregion
}
