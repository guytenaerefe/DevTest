using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class Triangle :IShape
    {
        public double Height { get; set; }
        public double Width { get; set; }


        public double CalculateSurfaceArea()
        {
            return 0.5 * (Height * Width);
        }
    }
}
