using System;
using Digbyswift.Core.Extensions;
using NUnit.Framework;

namespace Digbyswift.Core.Tests.Extensions.DateExtensions;

[TestFixture]
public class AgeNextBirthdayTests
{
    [Test]
    public void GetAgeNextBirthday_ReturnsEighteenFromSameDate()
    {
        var dob = DateTime.Now.AddYears(-17);
        var dobDateOnly = dob.Date;
        var ageNextBirthday = dobDateOnly.GetAgeNextBirthday();

        Assert.That(ageNextBirthday, Is.EqualTo(18));
    }

    [Test]
    public void GetAgeNextBirthday_ReturnsSeventeenEighteenFromNextDate()
    {
        var dob = DateTime.Now.AddYears(-17).AddDays(1);
        var dobDateOnly = dob.Date;
        var ageNextBirthday = dobDateOnly.GetAgeNextBirthday();

        Assert.That(ageNextBirthday, Is.EqualTo(17));
    }

    [Test]
    public void GetAgeNextBirthday_ReturnsSeventeenEighteenFromPreviousDate()
    {
        var dob = DateTime.Now.AddYears(-17).AddDays(-1);
        var dobDateOnly = dob.Date;
        var ageNextBirthday = dobDateOnly.GetAgeNextBirthday();

        Assert.That(ageNextBirthday, Is.EqualTo(18));
    }
}
