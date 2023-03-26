using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refactoring.code.ValueObjects
{
    public enum CommandAction
    { 
        create,
        print,
        calculate,
        reset,
        exit    
    }

    public enum ShapeType
    {
        square,
        circle,
        triangle,
        rectangle,
        trapezoid
    }
}
