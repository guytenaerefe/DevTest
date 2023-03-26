using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refactoring.code.Exceptions
{
    internal class InvalidCommandException : Exception
    {
        public InvalidCommandException(string explanation) : base(explanation)
        {
            
        }
    }
}
