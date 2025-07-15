using System;
using Digbyswift.Core.Extensions;
using NUnit.Framework;

namespace Digbyswift.Core.Tests.Extensions.DateExtensions;

[TestFixture]
public class GetAgeNextBirthdayTests
{
    [Test]
    public void GetAgeNextBirthday_ReturnsOne_WhenBornToday()
    {
        // Arrange
        var dob = DateTime.Today;

        // Act
        var ageNextBirthday = dob.GetAgeNextBirthday();

        // Assert
        Assert.That(ageNextBirthday, Is.EqualTo(1));
    }

    [Test]
    public void GetAgeNextBirthday_ReturnsOne_WhenBornYesterday()
    {
        // Arrange
        var dob = DateTime.Today.SubtractDays(1);

        // Act
        var ageNextBirthday = dob.GetAgeNextBirthday();

        // Assert
        Assert.That(ageNextBirthday, Is.EqualTo(1));
    }

    [Test]
    public void GetAgeNextBirthday_ReturnsZero_WhenBornTomorrow()
    {
        // Arrange
        var dob = DateTime.Today.AddDays(1);

        // Act
        var ageNextBirthday = dob.GetAgeNextBirthday();

        // Assert
        Assert.That(ageNextBirthday, Is.EqualTo(0));
    }

    [Test]
    public void GetAgeNextBirthday_ReturnsZero_WhenBornTomorrowExact()
    {
        // Arrange
        var dob = DateTime.Now.AddDays(1);

        // Act
        var ageNextBirthday = dob.GetAgeNextBirthday();

        // Assert
        Assert.That(ageNextBirthday, Is.EqualTo(0));
    }

    [Test]
    public void GetAgeNextBirthday_ReturnsEighteen_WhenSeventeenthBirthdayIsToday()
    {
        // Arrange
        var dob = DateTime.Today.SubtractYears(17);

        // Act
        var ageNextBirthday = dob.GetAgeNextBirthday();

        // Assert
        Assert.That(ageNextBirthday, Is.EqualTo(18));
    }

    [Test]
    public void GetAgeNextBirthday_ReturnsSeventeen_WhenSeventeenthBirthdayIsTomorrow()
    {
        // Arrange
        var dob = DateTime.Today.SubtractYears(17).AddDays(1);

        // Act
        var ageNextBirthday = dob.GetAgeNextBirthday();

        // Assert
        Assert.That(ageNextBirthday, Is.EqualTo(17));
    }

    [Test]
    public void GetAgeNextBirthday_ReturnsSeventeen_WhenSeventeenthBirthdayWasYesterday()
    {
        // Arrange
        var dob = DateTime.Today.SubtractYears(17).SubtractDays(1);

        // Act
        var ageNextBirthday = dob.GetAgeNextBirthday();

        // Assert
        Assert.That(ageNextBirthday, Is.EqualTo(18));
    }
}
