using Application.Collections;
using Domain.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UnitTest.Collections
{
    [TestClass]
    public class ShapeCollectionTests
    {
        [TestMethod]
        public void When_Creating_ShapeCollection_Should_HaveNoItems()
        {
            // Arrange
            ShapeCollection shapeCollection = new ShapeCollection();

            // Act
            
            // Assert
            Assert.AreEqual(0, shapeCollection.Count);
        }

        [TestMethod]
        public void When_AddingItemsToShapeCollection_Should_ContainAddedItems()
        {
            // Arrange
            ShapeCollection shapeCollection = new ShapeCollection();

            // Act
            shapeCollection.Add(new Square(Length.Create(1.0)));
            shapeCollection.Add(new Rectangle(Length.Create(1.0), Length.Create(1.0)));

            // Assert
            Assert.AreEqual(2, shapeCollection.Count);
        }


        [TestMethod]
        public void When_AddingItemsToShapeCollectionAndClear_Should_ContainNoItems()
        {
            // Arrange
            ShapeCollection shapeCollection = new ShapeCollection();

            // Act
            shapeCollection.Add(new Square(Length.Create(1.0)));
            shapeCollection.Add(new Rectangle(Length.Create(1.0), Length.Create(1.0)));

            shapeCollection.Clear();

            // Assert
            Assert.AreEqual(0, shapeCollection.Count);
        }
    }
}
