using Domain.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UnitTest.ValueObjects.Shapes
{
    [TestClass]
    public class RectangleTests
    {
        [TestMethod]
        [DataRow(0.0, 0.0, 0.0)]
        [DataRow(1.0, 3.0, 1.0 * 3.0)]
        [DataRow(100.123, 99.99, 100.123 * 99.99)]
        public void CalculateSurfaceArea_Should_ReturnCorrectValue(double width, double height, double expectedSurfaceArea)
        {
            // Arrange


            // Act
            Rectangle rectangle = new Rectangle(Length.Create(width), Length.Create(height));
            SurfaceArea surfaceArea = rectangle.CalculateSurfaceArea();

            // Assert
            Assert.AreEqual(expectedSurfaceArea, surfaceArea.Value);
        }
    }
}
