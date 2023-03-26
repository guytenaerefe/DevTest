using Refactoring.code.Exceptions;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Refactoring.code.ValueObjects
{
    internal class UserCommand
    {
        public CommandAction Action { get; set; }

        public ShapeType? ShapeType { get; set; }

        public List<UserCommandParameter> Parameters { get; } = new List<UserCommandParameter>();

        public string HelpMessage { get; set; }

        public List<UserCommandParameterValue> ParameterValues { get; } = new List<UserCommandParameterValue>();


        public UserCommand()
        {

        }

        public UserCommand(CommandAction action, ShapeType? shapeType, string parameters, string helpMessage)
        {
            Action = action;
            ShapeType = shapeType;

            string[] splittedParameters = parameters.Split(' ');
            foreach (string splittedParameter in splittedParameters)
            {
                if (string.IsNullOrEmpty(splittedParameter))
                {
                    continue;
                }
                Parameters.Add(new UserCommandParameter(splittedParameter));
            }

            HelpMessage = helpMessage;
        }


        public string Description
        {
            get
            {
                List<string> descriptionItems = new List<string>
                {
                    Action.ToString()
                };

                if (ShapeType != null)
                {
                    descriptionItems.Add(ShapeType.ToString());
                }
                descriptionItems.AddRange(Parameters.Select(x => "{" + x.Token + "}"));
                if (!string.IsNullOrEmpty(HelpMessage))
                {
                    descriptionItems.Add($"({HelpMessage})");
                }

                return string.Join(" ", descriptionItems);
            }
        }

        public void ValidateParameterValuesOrThrowException()
        {
            if (ParameterValues.Count < Parameters.Count)
            {
                throw new InvalidCommandException("Not all parameters have a value");
            }
        
        }
    }

    internal class UserCommandParameter
    {
        public string Token { get; set; }

        public UserCommandParameter()
        {

        }
        public UserCommandParameter(string token)
        {
            Token = token;
        }
    }

    internal class UserCommandParameterValue
    {
        public double Value { get; private set; }

        public UserCommandParameterValue()
        {

        }

        public UserCommandParameterValue(double value)
        {
            Value = value;
        }
    }
}
