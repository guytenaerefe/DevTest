using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ValueObjects
{
    public class Trapezoid : IShape
    {
        public Length Height { get; set; }

        public Length TopWidth { get; set; }
        public Length BottomWidth { get; set; }

        public SurfaceArea CalculateSurfaceArea()
        {
            return SurfaceArea.Create(0.5 * (TopWidth + BottomWidth) * Height);
        }
    }
}
