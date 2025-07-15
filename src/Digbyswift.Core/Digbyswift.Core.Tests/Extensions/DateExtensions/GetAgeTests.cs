using System;
using Digbyswift.Core.Extensions;
using NUnit.Framework;

namespace Digbyswift.Core.Tests.Extensions.DateExtensions;

[TestFixture]
public class GetAgeTests
{
    [Test]
    public void GetAge_ReturnsZero_WhenBornToday()
    {
        // Arrange
        var dob = DateTime.Today;

        // Act
        var age = dob.GetAge();

        // Assert
        Assert.That(age, Is.EqualTo(0));
    }

    [Test]
    public void GetAge_ReturnsZero_WhenBornTodayExact()
    {
        // Arrange
        var dob = DateTime.Now;

        // Act
        var age = dob.GetAge();

        // Assert
        Assert.That(age, Is.EqualTo(0));
    }

    [Test]
    public void GetAge_ReturnsZero_WhenBornYesterday()
    {
        // Arrange
        var dob = DateTime.Today.SubtractDays(1);

        // Act
        var age = dob.GetAge();

        // Assert
        Assert.That(age, Is.EqualTo(0));
    }

    [Test]
    public void GetAge_ReturnsZero_WhenBornYesterdayExact()
    {
        // Arrange
        var dob = DateTime.Now.SubtractDays(1);

        // Act
        var age = dob.GetAge();

        // Assert
        Assert.That(age, Is.EqualTo(0));
    }

    [Test]
    public void GetAge_ReturnsZero_WhenBornTomorrow()
    {
        // Arrange
        var dob = DateTime.Today.AddDays(1);

        // Act
        var age = dob.GetAge();

        // Assert
        Assert.That(age, Is.EqualTo(0));
    }

    [Test]
    public void GetAge_ReturnsZero_WhenBornTomorrowExact()
    {
        // Arrange
        var dob = DateTime.Now.AddDays(1);

        // Act
        var age = dob.GetAge();

        // Assert
        Assert.That(age, Is.EqualTo(0));
    }

    [Test]
    public void GetAge_ReturnsEighteen_WhenEighteenthBirthdayIsToday()
    {
        // Arrange
        var dob = DateTime.Today.SubtractYears(18);

        // Act
        var age = dob.GetAge();

        // Assert
        Assert.That(age, Is.EqualTo(18));
    }

    [Test]
    public void GetAge_ReturnsEighteen_WhenEighteenthBirthdayIsTodayExact()
    {
        // Arrange
        var dob = DateTime.Now.SubtractYears(18);

        // Act
        var age = dob.GetAge();

        // Assert
        Assert.That(age, Is.EqualTo(18));
    }

    [Test]
    public void GetAge_ReturnsSeventeen_WhenEighteenthBirthdayIsTomorrow()
    {
        // Arrange
        var dob = DateTime.Today.AddDays(1).SubtractYears(18);

        // Act
        var age = dob.GetAge();

        // Assert
        Assert.That(age, Is.EqualTo(17));
    }

    [Test]
    public void GetAge_ReturnsSeventeen_WhenEighteenthBirthdayIsTomorrowExact()
    {
        // Arrange
        var dob = DateTime.Now.AddDays(1).SubtractYears(18);

        // Act
        var age = dob.GetAge();

        // Assert
        Assert.That(age, Is.EqualTo(17));
    }

    [Test]
    public void GetAge_ReturnsSeventeen_WhenEighteenthBirthdayWasYesterday()
    {
        // Arrange
        var dob = DateTime.Today.SubtractYears(18).SubtractDays(1);

        // Act
        var age = dob.GetAge();

        // Assert
        Assert.That(age, Is.EqualTo(18));
    }

    [Test]
    public void GetAge_ReturnsSeventeen_WhenEighteenthBirthdayWasYesterdayExact()
    {
        // Arrange
        var dob = DateTime.Now.SubtractDays(1).SubtractYears(18);

        // Act
        var age = dob.GetAge();

        // Assert
        Assert.That(age, Is.EqualTo(18));
    }
}
