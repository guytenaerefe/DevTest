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
    public class CircleTests
    {
        [TestMethod]
        [DataRow(0.0, 0.0)]
        [DataRow(1.0, Math.PI * 1.0 * 1.0)]
        [DataRow(100.123, Math.PI * 100.123 * 100.123)]
        public void CalculateSurfaceArea_Should_ReturnCorrectValue(double radius, double expectedSurfaceArea)
        {
            // Arrange


            // Act
            Circle circle = new Circle(Length.Create(radius));
            SurfaceArea surfaceArea = circle.CalculateSurfaceArea();

            // Assert
            Assert.AreEqual(expectedSurfaceArea, surfaceArea.Value);
        }
    }
}
