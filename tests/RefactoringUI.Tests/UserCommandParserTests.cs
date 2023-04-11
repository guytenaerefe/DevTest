using Microsoft.VisualStudio.TestTools.UnitTesting;
using Refactoring.code;
using Refactoring.code.Exceptions;
using Refactoring.code.ValueObjects;
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
        public void When_LengthParametersAreInCorrect_ParseUserCommandString_Should_ThrowInvalidCommandException(string userCommandString)
        {
            // Arrange 

            // Act
            Assert.ThrowsException<InvalidCommandException>(() => UserCommandParser.ParseUserCommandString(userCommandString));

            // Assert
        }

        [TestMethod]
        [DataRow(CommandAction.create, ShapeType.triangle)]
        [DataRow(CommandAction.create, ShapeType.trapezoid)]
        [DataRow(CommandAction.print, null)]
        [DataRow(CommandAction.calculate, null)]
        [DataRow(CommandAction.reset, null)]
        public void GetCommandByAction_When_GivenValidParameters_Should_ReturnUserCommand(CommandAction commandAction, ShapeType? shapeType)
        {
            // Arrange 

            // Act
            var command = UserCommandParser.GetCommandByAction(commandAction, shapeType);

            // Assert
            Assert.IsNotNull(command);

            Assert.AreEqual(commandAction, command.Action);
            Assert.AreEqual(shapeType, command.ShapeType);
        }


        [TestMethod]
        [DataRow(CommandAction.create, null)]
        [DataRow(CommandAction.print, ShapeType.triangle)]
        [DataRow(CommandAction.calculate, ShapeType.trapezoid)]
        [DataRow(CommandAction.reset, ShapeType.trapezoid)]
        public void GetCommandByAction_When_GivenInValidParameters_Should_ReturnUserCommand(CommandAction commandAction, ShapeType? shapeType)
        {
            // Arrange 

            // Act
            var command = UserCommandParser.GetCommandByAction(commandAction, shapeType);

            // Assert
            Assert.IsNull(command);            
        }
    }
}
