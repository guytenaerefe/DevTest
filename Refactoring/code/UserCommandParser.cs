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
    public static class UserCommandParser
    {
        public static List<UserCommand> GetAvailableCommands()
        {
            List<UserCommand> userCommands = new List<UserCommand>
            {
                new UserCommand(CommandAction.create,  ShapeType.square, "side", "create a new square"),
                new UserCommand(CommandAction.create,  ShapeType.circle, "radius", "create a new circle"),
                new UserCommand(CommandAction.create,  ShapeType.rectangle, "width height", "create a new rectangle"),
                new UserCommand(CommandAction.create,  ShapeType.triangle, "width height", "create a new triangle"),
                new UserCommand(CommandAction.create,  ShapeType.trapezoid, "bottomwidth topwidth height", "create a new trapezoid"),
                new UserCommand(CommandAction.print,  null, "", "print the calculated surface areas"),
                new UserCommand(CommandAction.calculate,  null, "", "calulate the surface areas of the created shapes"),
                new UserCommand(CommandAction.reset,  null, "", "reset")
            };

            return userCommands;
        }

        public static UserCommand GetCommandByAction(CommandAction action, ShapeType? shapeType)
        {            
            return GetAvailableCommands().FirstOrDefault(x => x.Action == action && x.ShapeType == shapeType);
        }

        public static UserCommand ParseUserCommandString(string userCommandString)
        {
            string actionInput = "";
            string shapeSpecfierInput = "";

            string[] sections = userCommandString.Split(' ');
            if (sections.Length > 0)
            {
                actionInput = sections[0];
            }
            if (sections.Length > 1)
            {
                shapeSpecfierInput = sections[1];
            }

            actionInput = CleanUserCommandSection(actionInput);
            shapeSpecfierInput = CleanUserCommandSection(shapeSpecfierInput);

            if (!Enum.TryParse(actionInput, out CommandAction action))
            {
                return null;
            }

            ShapeType? shapeType = null;
            if (Enum.TryParse(shapeSpecfierInput, out ShapeType parsedShapeType))
            {
                shapeType = parsedShapeType;
            }
            
            UserCommand userCommand = GetCommandByAction(action, shapeType);
            if (userCommand is null)
            {
                return null;
            }

            for(int i = 2; i < sections.Length; i++)
            {
                string section= sections[i];
                if (double.TryParse(section, out double sectionValue))
                {
                    userCommand.ParameterValues.Add(new UserCommandParameterValue(sectionValue));
                }
            }

            userCommand.ValidateParameterValuesOrThrowException();

            return userCommand;
        }

        private static string CleanUserCommandSection(string section)
        {
            section = "" + section;
            section = section.Trim();
            section = section.ToLower();
            return section;
        }

    }
}
