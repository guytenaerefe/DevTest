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
    public class SurfaceAreaCollectionTests
    {
        [TestMethod]
        public void When_Creating_SurfaceAreaCollection_Should_HaveNoItems()
        {
            // Arrange
            SurfaceAreaCollection shapeCollection = new SurfaceAreaCollection();

            // Act
            
            // Assert
            Assert.AreEqual(0, shapeCollection.Count);
        }

        [TestMethod]
        public void When_AddingItemsToSurfaceAreaCollection_Should_ContainAddedItems()
        {
            // Arrange
            SurfaceAreaCollection surfaceAreaCollection = new SurfaceAreaCollection();

            // Act
            surfaceAreaCollection.Add(new Square(Length.Create(1.0)).CalculateSurfaceArea());
            surfaceAreaCollection.Add(new Rectangle(Length.Create(1.0), Length.Create(1.0)).CalculateSurfaceArea());

            // Assert
            Assert.AreEqual(2, surfaceAreaCollection.Count);
        }


        [TestMethod]
        public void When_AddingItemsToSurfaceAreaCollectionAndClear_Should_ContainNoItems()
        {
            // Arrange
            SurfaceAreaCollection surfaceAreaCollection = new SurfaceAreaCollection();

            // Act
            surfaceAreaCollection.Add(new Square(Length.Create(1.0)).CalculateSurfaceArea());
            surfaceAreaCollection.Add(new Rectangle(Length.Create(1.0), Length.Create(1.0)).CalculateSurfaceArea());

            surfaceAreaCollection.Clear();

            // Assert
            Assert.AreEqual(0, surfaceAreaCollection.Count);
        }
    }
}
