using System;
using System.Collections.Generic;
using Digbyswift.Core.Extensions;
using NUnit.Framework;

namespace Digbyswift.Core.Tests.Extensions.EnumerableExtensions;

[TestFixture]
public class NoneTests
{
    [Test]
    public void None_ThrowsException_WhenSourceIsNull()
    {
        // Arrange
        IEnumerable<string>? source = null;

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => source.None(_ => false));
    }

    [Test]
    [Ignore("Test yet to be implemented")]
    public void None_ReturnsException_WhenFunctionIsNull()
    {
        // Test has yet to be implemented.
    }
}
