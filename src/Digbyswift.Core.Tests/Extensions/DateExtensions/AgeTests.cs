using System;
using Digbyswift.Core.Extensions;
using NUnit.Framework;

namespace Digbyswift.Core.Tests.Extensions.DateExtensions;

[TestFixture]
public class AgeTests
{
    [Test]
    public void Age_ReturnsZero_WhenBornToday()
    {
        // Arrange
        var dob = DateTime.Today;

        // Act
        var age = dob.Age();

        // Assert
        Assert.That(age, Is.Zero);
    }

    [Test]
    public void Age_ReturnsZero_WhenBornTodayExact()
    {
        // Arrange
        var dob = DateTime.Now;

        // Act
        var age = dob.Age();

        // Assert
        Assert.That(age, Is.Zero);
    }

    [Test]
    public void Age_ReturnsZero_WhenBornYesterday()
    {
        // Arrange
        var dob = DateTime.Today.SubtractDays(1);

        // Act
        var age = dob.Age();

        // Assert
        Assert.That(age, Is.Zero);
    }

    [Test]
    public void Age_ReturnsZero_WhenBornYesterdayExact()
    {
        // Arrange
        var dob = DateTime.Now.SubtractDays(1);

        // Act
        var age = dob.Age();

        // Assert
        Assert.That(age, Is.Zero);
    }

    [Test]
    public void Age_ReturnsZero_WhenBornTomorrow()
    {
        // Arrange
        var dob = DateTime.Today.AddDays(1);

        // Act
        var age = dob.Age();

        // Assert
        Assert.That(age, Is.Zero);
    }

    [Test]
    public void Age_ReturnsZero_WhenBornTomorrowExact()
    {
        // Arrange
        var dob = DateTime.Now.AddDays(1);

        // Act
        var age = dob.Age();

        // Assert
        Assert.That(age, Is.Zero);
    }

    [Test]
    public void Age_ReturnsEighteen_WhenEighteenthBirthdayIsToday()
    {
        // Arrange
        var dob = DateTime.Today.SubtractYears(18);

        // Act
        var age = dob.Age();

        // Assert
        Assert.That(age, Is.EqualTo(18));
    }

    [Test]
    public void Age_ReturnsEighteen_WhenEighteenthBirthdayIsTodayExact()
    {
        // Arrange
        var dob = DateTime.Now.SubtractYears(18);

        // Act
        var age = dob.Age();

        // Assert
        Assert.That(age, Is.EqualTo(18));
    }

    [Test]
    public void Age_ReturnsSeventeen_WhenEighteenthBirthdayIsTomorrow()
    {
        // Arrange
        var dob = DateTime.Today.AddDays(1).SubtractYears(18);

        // Act
        var age = dob.Age();

        // Assert
        Assert.That(age, Is.EqualTo(17));
    }

    [Test]
    public void Age_ReturnsSeventeen_WhenEighteenthBirthdayIsTomorrowExact()
    {
        // Arrange
        var dob = DateTime.Now.AddDays(1).SubtractYears(18);

        // Act
        var age = dob.Age();

        // Assert
        Assert.That(age, Is.EqualTo(17));
    }

    [Test]
    public void Age_ReturnsSeventeen_WhenEighteenthBirthdayWasYesterday()
    {
        // Arrange
        var dob = DateTime.Today.SubtractYears(18).SubtractDays(1);

        // Act
        var age = dob.Age();

        // Assert
        Assert.That(age, Is.EqualTo(18));
    }

    [Test]
    public void Age_ReturnsSeventeen_WhenEighteenthBirthdayWasYesterdayExact()
    {
        // Arrange
        var dob = DateTime.Now.SubtractDays(1).SubtractYears(18);

        // Act
        var age = dob.Age();

        // Assert
        Assert.That(age, Is.EqualTo(18));
    }
}
