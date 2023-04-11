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
        public Length BottomWidth { get; set; }
        public Length TopWidth { get; set; }
        public Length Height { get; set; }

        public Trapezoid(Length bottomWidth, Length topWidth, Length height)
        {
            BottomWidth = bottomWidth;
            TopWidth = topWidth;
            Height = height;
        }

        public SurfaceArea CalculateSurfaceArea()
        {
            return SurfaceArea.Create(0.5 * (TopWidth + BottomWidth) * Height);
        }
    }
}
