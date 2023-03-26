using Domain.Interfaces;
using Domain.ValueObjects;
using Refactoring.code.Exceptions;
using Refactoring.code.ValueObjects;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Refactoring.code
{
    internal static class CreateShapeUserCommandProcessor
    {

        public static IShape CreateShapeFromUserCommand(UserCommand userCommand)
        {
            if (userCommand.Action != CommandAction.create)
            {
                return null;
            }

            switch (userCommand.ShapeType)
            {
                case ShapeType.square:
                    Square square = new Square()
                    {
                        Side = Length.Create(userCommand.ParameterValues[0].Value)
                    };
                    return square;

                case ShapeType.circle:
                    Circle circle = new Circle()
                    {
                        Radius= Length.Create(userCommand.ParameterValues[0].Value)
                    };
                    return circle;

                case ShapeType.triangle:
                    Triangle triangle = new Triangle()
                    {
                        Height = Length.Create(userCommand.ParameterValues[0].Value),
                        Width = Length.Create(userCommand.ParameterValues[1].Value)
                    };
                    return triangle;

                case ShapeType.rectangle:
                    Rectangle  rectangle = new Rectangle()
                    {
                        Height = Length.Create(userCommand.ParameterValues[0].Value),
                        Width = Length.Create(userCommand.ParameterValues[1].Value)
                    };
                    return rectangle;

                case ShapeType.trapezoid:
                    Trapezoid trapezoid = new Trapezoid()
                    {
                        Height = Length.Create(userCommand.ParameterValues[0].Value),
                        BottomWidth = Length.Create(userCommand.ParameterValues[1].Value),
                        TopWidth = Length.Create(userCommand.ParameterValues[2].Value)
                    };
                    return trapezoid;
            }


            throw new InvalidCommandException($"Invalid ShapeType: {userCommand.ShapeType}");
        }
    }
}
