namespace Refactoring.UnitTest
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Refactoring;
    using Shapes;

    [TestClass]
    public class UnitTest
    {
        private const double TriangleHeight = 13d;
        private const double TriangleWidth = 34d;
        private const double TriangleSurfaceArea = 221d;
        private const double CircleRadius = 23d;
        private const double CircleSurfaceArea = 1661.9d;
        private const double SquareSide = 17d;
        private const double SquareSurfaceArea = 289d;
        private const double RectangleHeight = 23d;
        private const double RectangleWidth = 67d;
        private const double RectangleSurfaceArea = 1541d;

        [TestMethod]
        public void TriangleCalculateSurfaceArea()
        {
            // Arrange
            Triangle triangle = new Triangle();
            triangle.Height = TriangleHeight;
            triangle.Width = TriangleWidth;

            // Act
            double surfaceArea = triangle.CalculateSurfaceArea();

            // Assert
            Assert.AreEqual(TriangleSurfaceArea, surfaceArea);
        }

        [TestMethod]
        public void CircleCalculateSurfaceArea()
        {
            // Arrange
            Circle circle = new Circle();
            circle.Radius = CircleRadius;

            // Act
            double surfaceArea = circle.CalculateSurfaceArea();

            // Assert
            Assert.AreEqual(CircleSurfaceArea, surfaceArea);
        }

        [TestMethod]
        public void SquareCalculateSurfaceArea()
        {
            // Arrange
            Square square = new Square();
            square.Side = SquareSide;

            // Act
            double surfaceArea = square.CalculateSurfaceArea();

            // Assert
            Assert.AreEqual(SquareSurfaceArea, surfaceArea);
        }

        [TestMethod]
        public void RectangleCalculateSurfaceArea()
        {
            // Arrange
            Rectangle rectangle = new Rectangle();
            rectangle.Height = RectangleHeight;
            rectangle.Width = RectangleWidth;

            // Act
            double surfaceArea = rectangle.CalculateSurfaceArea();

            // Assert
            Assert.AreEqual(RectangleSurfaceArea, surfaceArea);
        }

        
    }
}
