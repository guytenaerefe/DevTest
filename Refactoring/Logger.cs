using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refactoring
{
    internal class Logger : ILogger
    {
        public void Log(string pLog)
        {
            Console.WriteLine(pLog);
        }
      
    }
}
