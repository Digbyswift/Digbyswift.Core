using System;
using System.Globalization;
using System.Threading;
using Digbyswift.Core.Extensions;
using NUnit.Framework;

namespace Digbyswift.Core.Tests.Extensions.DateExtensions;

[TestFixture]
public class ToInvariantStringTests
{
    [Test]
    public void ToInvariantString_Decimal_ReturnsExpectedOutput()
    {
        // Arrange
        Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("sv-SE");
        var date = new DateTime(2001, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        // Act
        var result = date.ToInvariantString();

        // Assert
        Assert.That(result, Is.EqualTo(date.ToString(CultureInfo.InvariantCulture)));
    }
}
