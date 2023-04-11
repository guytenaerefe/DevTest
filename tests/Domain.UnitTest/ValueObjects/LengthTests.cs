using Domain.Exceptions;
using Domain.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UnitTest.ValueObjects
{
    [TestClass]
    public class LengthTests
    {
        [TestMethod]
        [DataRow(0.0)]
        [DataRow(10.0)]
        [DataRow(100.123)]
        public void Create_WithPositiveValue_Should_ReturnCorrectObject(double value)
        {
            // Arrange
                        

            // Act
            Length length = Length.Create(value);

            // Assert
            Assert.AreEqual(value, length.Value);
        }

        [TestMethod]
        public void Create_WithNegativeValue_Should_ThrowsInvalidLengthException()
        {
            // Arrange
            double negativeValue = -1.0;
            
            // Act
            
            // Assert
            Assert.ThrowsException<InvalidLengthException>(() => Length.Create(negativeValue));
        }
    }
}
