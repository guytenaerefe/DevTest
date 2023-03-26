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
        public void Create_WithPositiveValue_Should_ReturnLengthObject()
        {
            // Arrange
            double positiveValue = 100;

            // Act
            Length length = Length.Create(positiveValue);

            // Assert
            Assert.AreEqual(positiveValue, length.Value);
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
