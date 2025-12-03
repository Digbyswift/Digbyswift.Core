using System;
using Digbyswift.Core.Extensions;
using NUnit.Framework;

namespace Digbyswift.Core.Tests.Extensions.DateExtensions;

[TestFixture]
public class AgeNextBirthdayTests
{
    [Test]
    public void AgeNextBirthday_ReturnsOne_WhenBornToday()
    {
        // Arrange
        var dob = DateTime.Today;

        // Act
        var ageNextBirthday = dob.AgeNextBirthday();

        // Assert
        Assert.That(ageNextBirthday, Is.EqualTo(1));
    }

    [Test]
    public void AgeNextBirthday_ReturnsOne_WhenBornYesterday()
    {
        // Arrange
        var dob = DateTime.Today.SubtractDays(1);

        // Act
        var ageNextBirthday = dob.AgeNextBirthday();

        // Assert
        Assert.That(ageNextBirthday, Is.EqualTo(1));
    }

    [Test]
    public void AgeNextBirthday_ReturnsZero_WhenBornTomorrow()
    {
        // Arrange
        var dob = DateTime.Today.AddDays(1);

        // Act
        var ageNextBirthday = dob.AgeNextBirthday();

        // Assert
        Assert.That(ageNextBirthday, Is.Zero);
    }

    [Test]
    public void AgeNextBirthday_ReturnsZero_WhenBornTomorrowExact()
    {
        // Arrange
        var dob = DateTime.Now.AddDays(1);

        // Act
        var ageNextBirthday = dob.AgeNextBirthday();

        // Assert
        Assert.That(ageNextBirthday, Is.Zero);
    }

    [Test]
    public void AgeNextBirthday_ReturnsEighteen_WhenSeventeenthBirthdayIsToday()
    {
        // Arrange
        var dob = DateTime.Today.SubtractYears(17);

        // Act
        var ageNextBirthday = dob.AgeNextBirthday();

        // Assert
        Assert.That(ageNextBirthday, Is.EqualTo(18));
    }

    [Test]
    public void AgeNextBirthday_ReturnsSeventeen_WhenSeventeenthBirthdayIsTomorrow()
    {
        // Arrange
        var dob = DateTime.Today.SubtractYears(17).AddDays(1);

        // Act
        var ageNextBirthday = dob.AgeNextBirthday();

        // Assert
        Assert.That(ageNextBirthday, Is.EqualTo(17));
    }

    [Test]
    public void AgeNextBirthday_ReturnsSeventeen_WhenSeventeenthBirthdayWasYesterday()
    {
        // Arrange
        var dob = DateTime.Today.SubtractYears(17).SubtractDays(1);

        // Act
        var ageNextBirthday = dob.AgeNextBirthday();

        // Assert
        Assert.That(ageNextBirthday, Is.EqualTo(18));
    }
}
