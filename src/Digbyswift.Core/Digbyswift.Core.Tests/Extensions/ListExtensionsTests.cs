using System;
using System.Collections.Generic;
using Digbyswift.Core.Extensions;
using NUnit.Framework;

namespace Digbyswift.Core.Tests.Extensions
{
    [TestFixture]
    public class ListExtensionsTests
    {
    
        [Test]
        public void Crop_Throws_WhenInputIsNull()
        {
            const IList<object> list = null;
            
            // Assert
            Assert.Throws<ArgumentNullException>(() => list.Crop(1));
        }
    
        [Test]
        public void Crop_Throws_WhenSizeParameterIsLargerThanInputLength()
        {
            // Arrange
            var list = new List<int> { 1, 2, 3, 4 };
            
            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => list.Crop(list.Count + 1));
        }
    
        [Test]
        public void Crop_ReturnsUnaffectedList_WhenSizeParameterIsEqualToInputLength()
        {
            // Arrange
            var list = new List<int> { 1, 2, 3, 4 };
            var newLength = list.Count;
            
            // Act
            var newList = list.Crop(newLength);
            
            // Assert
            Assert.That(newList, Is.EquivalentTo(list));
        }
    
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void Crop_ReturnsListOfExpectedLength_WhenSizeParameterIsLessThanInputLength(int newLength)
        {
            // Arrange
            var list = new List<int> { 1, 2, 3, 4 };
            
            // Act
            var newList = list.Crop(newLength);
            
            // Assert
            Assert.That(newList.Count, Is.EqualTo(newLength));
        }
    
        [TestCase(1, new [] {1})]
        [TestCase(2, new [] {1, 2})]
        [TestCase(3, new [] {1, 2, 3})]
        public void Crop_ReturnsListCroppedFromTheEnd_WhenSizeParameterIsLessThanInputLength(int newLength, IList<int> expectedNewList)
        {
            // Arrange
            var list = new List<int> { 1, 2, 3, 4 };
            
            // Act
            var newList = list.Crop(newLength);
            
            // Assert
            Assert.That(newList, Is.EquivalentTo(expectedNewList));
        }
    
    }    
}

