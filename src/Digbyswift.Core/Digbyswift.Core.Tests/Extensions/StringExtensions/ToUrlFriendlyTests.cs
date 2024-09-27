using System;
using Digbyswift.Core.Extensions;
using NUnit.Framework;

namespace Digbyswift.Core.Tests.Extensions.StringExtensions;

[TestFixture]
public class ToUrlFriendlyTests
{
    
#if NET48
        [Test]
        public void ToUrlFriendly_ReturnsNull_WhenTheInputIsNull()
        {
            // Act
            var result = ((string)null).ToUrlFriendly();
            
            // Assert
            Assert.That(result, Is.Null);
        }
#endif
        
    [Test]
    public void ToUrlFriendly_ReturnsEmptyString_WhenTheInputIsEmpty()
    {
        // Act
        var result = String.Empty.ToUrlFriendly();
            
        // Assert
        Assert.That(result, Is.EqualTo(String.Empty));
    }
}