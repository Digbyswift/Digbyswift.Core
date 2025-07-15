using System.Collections.Generic;
using Digbyswift.Core.Extensions;
using NUnit.Framework;

namespace Digbyswift.Core.Tests.Extensions.EnumerableExtensions;

[TestFixture]
public class WhereNotNullTests
{
    private const string Testing = "Testing";
    private const string TestingAgain = "Testing again";
    private const string TestingYetAgain = "Testing yet again";

    [Test]
    public void WhereNotNull_ReturnsIdenticalList_WhenListHasNoNulls()
    {
        // Arrange
        IEnumerable<string> source = new List<string> { Testing, TestingAgain, TestingYetAgain };
        IEnumerable<string> expectedResult = new List<string> { Testing, TestingAgain, TestingYetAgain };

        // Act
        var result = source.WhereNotNull();

        // Assert
        Assert.AreEqual(result, expectedResult);
    }

    [Test]
    public void WhereNotNull_ReturnsListWithoutNulls_WhenListHasItems()
    {
        // Arrange
        IEnumerable<string> source = new List<string> { Testing, null, TestingAgain, null, TestingYetAgain };
        IEnumerable<string> expectedResult = new List<string> { Testing, TestingAgain, TestingYetAgain };

        // Act
        var result = source.WhereNotNull();

        // Assert
        Assert.AreEqual(result, expectedResult);
    }

    [Test]
    public void WhereNotNull_ReturnsEmptyList_WhenListHasOnlyNulls()
    {
        // Arrange
        IEnumerable<string> source = new List<string> { null, null, null };
        IEnumerable<string> expectedResult = new List<string>();

        // Act
        var result = source.WhereNotNull();

        // Assert
        Assert.AreEqual(result, expectedResult);
    }
}
