using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class Square:IShape
    {
        public double Side { get; set; }

        public double CalculateSurfaceArea()
        {
            return this.Side * this.Side;
        }
    }
}
