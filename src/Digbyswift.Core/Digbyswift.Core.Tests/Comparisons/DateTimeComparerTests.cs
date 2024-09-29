using System;
using Digbyswift.Core.Comparisons;
using Digbyswift.Core.Extensions;
using Digbyswift.Core.Models;
using NUnit.Framework;

namespace Digbyswift.Core.Tests.Comparisons;

[TestFixture]
public class DateTimeComparerTests
{
    #region Ctor

    [TestCase(DateTimeComparePrecision.Millisecond)]
    [TestCase(DateTimeComparePrecision.Second)]
    [TestCase(DateTimeComparePrecision.Minute)]
    [TestCase(DateTimeComparePrecision.Hour)]
    [TestCase(DateTimeComparePrecision.Day)]
    public void Ctor_(DateTimeComparePrecision precision)
    {
        // Arrange
        var sut = new DateTimeComparer(precision);

        // Act
        var result = sut.Precision;

        // Assert
        Assert.That(result, Is.EqualTo(precision));
    }

    #endregion

    #region Compare

    [TestCase(DateTimeComparePrecision.Millisecond)]
    [TestCase(DateTimeComparePrecision.Second)]
    [TestCase(DateTimeComparePrecision.Minute)]
    [TestCase(DateTimeComparePrecision.Hour)]
    [TestCase(DateTimeComparePrecision.Day)]
    public void Compare_ConsidersNowToBeEqualToNow_Always(DateTimeComparePrecision precision)
    {
        // Arrange
        var sut = new DateTimeComparer(precision);
        var now = SystemTime.UtcNow;

        // Act
        var result = sut.Compare(now, now);

        // Assert
        Assert.That(result, Is.EqualTo(0));
    }

    [TestCase(DateTimeComparePrecision.Millisecond)]
    [TestCase(DateTimeComparePrecision.Second)]
    [TestCase(DateTimeComparePrecision.Minute)]
    [TestCase(DateTimeComparePrecision.Hour)]
    [TestCase(DateTimeComparePrecision.Day)]
    public void Compare_ConsidersHistoricalDateToBeLessThanNow_Always(DateTimeComparePrecision precision)
    {
        // Arrange
        var sut = new DateTimeComparer(precision);
        var now = new DateTime(2000, 01, 01);
        var historicalDate = now.Subtract(TimeSpan.FromTicks(1));

        // Act
        var result = sut.Compare(historicalDate, now);

        // Assert
        Assert.That(result, Is.EqualTo(-1));
    }

    [Test]
    public void Compare_ConsidersFutureDateToBeEqualToNow_WhenPrecisionIsMillisecondsAndFutureDateIsLessThanOneMillisecondAfterNow()
    {
        // Arrange
        var sut = new DateTimeComparer(DateTimeComparePrecision.Millisecond);
        var now = new DateTime(2000, 01, 01);
        var futureDate = now.AddTicks(999);

        // Act
        var result = sut.Compare(futureDate, now);

        // Assert
        Assert.That(result, Is.EqualTo(0));
    }

    [TestCase(0)]
    [TestCase(1)]
    public void Compare_ConsidersFutureDateToBeGreaterThanNow_WhenPrecisionIsMillisecondsAndFutureDateIsOneOrMoreMillisecondAfterNow(int ticks)
    {
        // Arrange
        var sut = new DateTimeComparer(DateTimeComparePrecision.Millisecond);
        var now = new DateTime(2000, 01, 01);
        var futureDate = now.AddMilliseconds(1).AddTicks(ticks);

        // Act
        var result = sut.Compare(futureDate, now);

        // Assert
        Assert.That(result, Is.EqualTo(1));
    }

    [Test]
    public void Compare_ConsidersFutureDateToBeEqualToNow_WhenPrecisionIsSecondsAndFutureDateIsLessThanOneSecondAfterNow()
    {
        // Arrange
        var sut = new DateTimeComparer(DateTimeComparePrecision.Second);
        var now = new DateTime(2000, 01, 01);
        var futureDate = now.AddSeconds(1).Subtract(TimeSpan.FromTicks(1));

        // Act
        var result = sut.Compare(futureDate, now);

        // Assert
        Assert.That(result, Is.EqualTo(0));
    }

    [TestCase(0)]
    [TestCase(1)]
    public void Compare_ConsidersFutureDateToBeGreaterThanNow_WhenPrecisionIsSecondsAndFutureDateIsOneOrMoreSecondAfterNow(int ticks)
    {
        // Arrange
        var sut = new DateTimeComparer(DateTimeComparePrecision.Second);
        var now = new DateTime(2000, 01, 01);
        var futureDate = now.AddSeconds(1).AddTicks(ticks);

        // Act
        var result = sut.Compare(futureDate, now);

        // Assert
        Assert.That(result, Is.EqualTo(1));
    }

    [Test]
    public void Compare_ConsidersFutureDateToBeEqualToNow_WhenPrecisionIsMinutesAndFutureDateIsLessThanOneMinuteAfterNow()
    {
        // Arrange
        var sut = new DateTimeComparer(DateTimeComparePrecision.Minute);
        var now = new DateTime(2000, 01, 01);
        var futureDate = now.AddMinutes(1).Subtract(TimeSpan.FromTicks(1));

        // Act
        var result = sut.Compare(futureDate, now);

        // Assert
        Assert.That(result, Is.EqualTo(0));
    }

    [TestCase(0)]
    [TestCase(1)]
    public void Compare_ConsidersFutureDateToBeGreaterThanNow_WhenPrecisionIsMinutesAndFutureDateIsOneOrMoreMinuteAfterNow(int ticks)
    {
        // Arrange
        var sut = new DateTimeComparer(DateTimeComparePrecision.Minute);
        var now = new DateTime(2000, 01, 01);
        var futureDate = now.AddMinutes(1).AddTicks(ticks);

        // Act
        var result = sut.Compare(futureDate, now);

        // Assert
        Assert.That(result, Is.EqualTo(1));
    }

    [Test]
    public void Compare_ConsidersFutureDateToBeEqualToNow_WhenPrecisionIsHoursAndFutureDateIsLessThanOneHourAfterNow()
    {
        // Arrange
        var sut = new DateTimeComparer(DateTimeComparePrecision.Hour);
        var now = new DateTime(2000, 01, 01);
        var futureDate = now.AddHours(1).Subtract(TimeSpan.FromTicks(1));

        // Act
        var result = sut.Compare(futureDate, now);

        // Assert
        Assert.That(result, Is.EqualTo(0));
    }

    [TestCase(0)]
    [TestCase(1)]
    public void Compare_ConsidersFutureDateToBeGreaterThanNow_WhenPrecisionIsHoursAndFutureDateIsOneOrMoreHourAfterNow(int ticks)
    {
        // Arrange
        var sut = new DateTimeComparer(DateTimeComparePrecision.Hour);
        var now = new DateTime(2000, 01, 01);
        var futureDate = now.AddHours(1).AddTicks(ticks);

        // Act
        var result = sut.Compare(futureDate, now);

        // Assert
        Assert.That(result, Is.EqualTo(1));
    }

    [Test]
    public void Compare_ConsidersFutureDateToBeEqualToNow_WhenPrecisionIsDaysAndFutureDateIsLessThanOneDayAfterNow()
    {
        // Arrange
        var sut = new DateTimeComparer(DateTimeComparePrecision.Day);
        var now = new DateTime(2000, 01, 01);
        var futureDate = now.AddDays(1).Subtract(TimeSpan.FromTicks(1));

        // Act
        var result = sut.Compare(futureDate, now);

        // Assert
        Assert.That(result, Is.EqualTo(0));
    }

    [TestCase(0)]
    [TestCase(1)]
    public void Compare_ConsidersFutureDateToBeGreaterThanNow_WhenPrecisionIsDaysAndFutureDateIsOneOrMoreDayAfterNow(int ticks)
    {
        // Arrange
        var sut = new DateTimeComparer(DateTimeComparePrecision.Day);
        var now = new DateTime(2000, 01, 01);
        var futureDate = now.AddDays(1).AddTicks(ticks);

        // Act
        var result = sut.Compare(futureDate, now);

        // Assert
        Assert.That(result, Is.EqualTo(1));
    }

    #endregion

    #region AreEqual

    [Test]
    public void AreEqual_ConsidersDatesToBeEqualWithDayPrecision_WhenDayIsTheSame()
    {
        // Arrange
        var sut = new DateTimeComparer(DateTimeComparePrecision.Day);

        var preciseDateTime = new DateTime(2000, 01, 01, 23, 59, 59);
        var impreciseDateTime = new DateTime(2000, 01, 01);

        // Act
        var result = sut.AreEqual(preciseDateTime, impreciseDateTime);

        // Assert
        Assert.That(result, Is.True);
    }

    [Test]
    public void AreEqual_ConsidersDatesToBeEqualWithHourPrecision_WhenDateAndHourIsTheSame()
    {
        // Arrange
        var sut = new DateTimeComparer(DateTimeComparePrecision.Hour);

        var preciseDateTime = new DateTime(2000, 01, 01, 23, 59, 59);
        var impreciseDateTime = new DateTime(2000, 01, 01, 23, 0, 0);

        // Act
        var result = sut.AreEqual(preciseDateTime, impreciseDateTime);

        // Assert
        Assert.That(result, Is.True);
    }

    [Test]
    public void AreEqual_ConsidersDatesToBeEqualWithMinutePrecision_WhenDateAndTimeToMinuteIsTheSame()
    {
        // Arrange
        var sut = new DateTimeComparer(DateTimeComparePrecision.Minute);

        var preciseDateTime = new DateTime(2000, 01, 01, 23, 59, 59);
        var impreciseDateTime = new DateTime(2000, 01, 01, 23, 59, 0);

        // Act
        var result = sut.AreEqual(preciseDateTime, impreciseDateTime);

        // Assert
        Assert.That(result, Is.True);
    }

    [Test]
    public void AreEqual_ConsidersDatesToBeEqualWithSecondPrecision_WhenDateAndTimeToSecondIsTheSame()
    {
        // Arrange
        var sut = new DateTimeComparer(DateTimeComparePrecision.Second);

        var preciseDateTime = new DateTime(2000, 01, 01, 23, 59, 59, 999);
        var impreciseDateTime = new DateTime(2000, 01, 01, 23, 59, 59);

        // Act
        var result = sut.AreEqual(preciseDateTime, impreciseDateTime);

        // Assert
        Assert.That(result, Is.True);
    }

    [Test]
    public void AreEqual_ConsidersDatesToBeEqualWithMillisecondPrecision_WhenDateAndTimeToMillisecondIsTheSame()
    {
        // Arrange
        var sut = new DateTimeComparer(DateTimeComparePrecision.Millisecond);

        var preciseDateTime = new DateTime(2000, 01, 01, 23, 59, 59, 999).AddTicks(999);
        var impreciseDateTime = new DateTime(2000, 01, 01, 23, 59, 59, 999);

        // Act
        var result = sut.AreEqual(preciseDateTime, impreciseDateTime);

        // Assert
        Assert.That(result, Is.True, $"{preciseDateTime:O} <> {impreciseDateTime:O}");
    }

    #endregion
}
