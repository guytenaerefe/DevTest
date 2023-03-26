using Microsoft.VisualStudio.TestTools.UnitTesting;
using Refactoring.code;
using Refactoring.code.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactoringUI.Tests
{
    [TestClass]
    public class UserCommandParserTests
    {
        [TestMethod]
        [DataRow("create square 100")]
        [DataRow("create circle 100")]
        [DataRow("create rectangle 100 100")]
        [DataRow("create triangle 100 100")]
        [DataRow("create trapezoid 100 50 100")]
        public void When_CommandIsCorrect_ParseUserCommandString_Should_ReturnValidUserCommand(string userCommandString)
        {
            // Arrange 

            // Act
            Refactoring.code.ValueObjects.UserCommand userCommand = UserCommandParser.ParseUserCommandString(userCommandString);

            // Assert
            Assert.IsNotNull(userCommand);
        }


        [TestMethod]
        [DataRow("create square2 100 100")]
        [DataRow("create square2")]
        [DataRow("create2 circle 100")]
        [DataRow("create2 circle")]
        [DataRow("create2 circle2")]
        public void When_CommandSyntaxIsInCorrect_ParseUserCommandString_Should_ReturnNull(string userCommandString)
        {
            // Arrange 

            // Act
            Refactoring.code.ValueObjects.UserCommand userCommand = UserCommandParser.ParseUserCommandString(userCommandString);

            // Assert
            Assert.IsNull(userCommand);
        }


        [TestMethod]
        [DataRow("create square 100 100 100")]
        [DataRow("create square")]
        [DataRow("create circle 100 100")]
        [DataRow("create rectangle ")]
        [DataRow("create triangle 100 100 100")]
        [DataRow("create trapezoid 100 50 100 100")]
        public void When_LengthParametersAreInCorrect_ParseUserCommandString_Should_InvalidCommandException(string userCommandString)
        {
            // Arrange 

            // Act
            Assert.ThrowsException<InvalidCommandException>(() => UserCommandParser.ParseUserCommandString(userCommandString));

            // Assert
        }



    }
}
