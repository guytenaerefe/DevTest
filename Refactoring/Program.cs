using Domain.Interfaces;
using Domain.ValueObjects;
using Refactoring.code;
using Refactoring.code.Exceptions;
using Refactoring.code.ValueObjects;
using Refactoring.Code;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography;

namespace Refactoring
{
    class Program
    {
        private static Logger _logger = new Logger();


        static void Main(string[] args)
        {
            WriteLineToScreen(" -------------------------------------------------------------------------- ");
            WriteLineToScreen("| Greetings and salutations fellow developer :D                            |");
            WriteLineToScreen("|                                                                          |");
            WriteLineToScreen("| If you are reading this we probably want to know if you know your stuff. |");
            WriteLineToScreen("|                                                                          |");
            WriteLineToScreen("| How would you improve this code?                                         |");
            WriteLineToScreen("| We challenge you to refactor this and show us how awesome you are ;)     |");
            WriteLineToScreen("| We also really like trapezoids so could you also implement that for us?  |");
            WriteLineToScreen("|                                                                          |");
            WriteLineToScreen("|                                                               Good luck! |");
            WriteLineToScreen(" --------------------------------------------------------------------------");

            WriteLineToScreen("");
            WriteLineToScreen("Commands:");
            List<UserCommand> userCommands = UserCommandParser.GetAvailableCommands();
            userCommands.ForEach(x => WriteLineToScreen($"- {x.Description}"));

            WriteLineToScreen("- exit (exit the loop)");
            WriteLineToScreen("");
            SurfaceAreaCalculator surfaceAreaCalculator = new SurfaceAreaCalculator();

            string line = Console.ReadLine();
            while (line != "exit")
            {
                try
                {
                    UserCommand userCommand = UserCommandParser.ParseUserCommandString(line);
                    if (userCommand == null)
                    {
                        throw new InvalidCommandException($"Unknown command: {line}");
                    }
                    ProcessUserCommand(userCommand, surfaceAreaCalculator);
                }
                catch (Exception ex)
                {
                    _logger.Log($"Error: {ex.Message}");
                }

                line = Console.ReadLine();
            }
        }

        static void ProcessUserCommand(UserCommand userCommand, SurfaceAreaCalculator surfaceAreaCalculator)
        {
            WriteLineToScreen($"Command: {userCommand.Description}");

            switch (userCommand.Action)
            {
                case CommandAction.create:
                    IShape createdShape = CreateShapeUserCommandProcessor.CreateShapeFromUserCommand(userCommand);
                    surfaceAreaCalculator.AddShape(createdShape);
                    break;

                case CommandAction.print:
                    WriteSurfaceAreas(surfaceAreaCalculator);
                    break;

                case CommandAction.reset:
                    surfaceAreaCalculator.Reset();
                    break;

                case CommandAction.calculate:
                    surfaceAreaCalculator.CalculateSurfaceAreas();
                    break;
            }



        }


        static void WriteSurfaceAreas(SurfaceAreaCalculator surfaceAreaCalculator)
        {
            ReadOnlyCollection<IShape> shapes = surfaceAreaCalculator.Shapes;
            ReadOnlyCollection<SurfaceArea> calculatedSurfaceAreas = surfaceAreaCalculator.CalculatedSurfaceAreas;

            if (calculatedSurfaceAreas.Count != shapes.Count)
            {
                WriteLineToScreen("Please calulate the surface areas of the created shapes");
                return;
            }

            for (int i = 0; i < shapes.Count; i++)
            {
                IShape shape = shapes[i];
                SurfaceArea calculatedSurfaceArea = calculatedSurfaceAreas[i];

                WriteLineToScreen($"[{i}] {shape.GetType().Name} surface area is {calculatedSurfaceArea.Value:0.00}");
            }
        }


        static void WriteLineToScreen(string line)
        {
            Console.WriteLine(line);
        }
    }


}
