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
        [DataRow(1, Math.PI * 1.0 * 1.0)]
        [DataRow(2, Math.PI * 2.0 * 2.0)]
        public void CalculateSurfaceArea(double radius, double expectedSurfaceArea)
        {
            // Arrange


            // Act
            Circle circle = new Circle() { 
                Radius = Length.Create(radius),
            };
            SurfaceArea surfaceArea = circle.CalculateSurfaceArea();

            // Assert
            Assert.AreEqual(expectedSurfaceArea, surfaceArea.Value);
        }
    }
}
