using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ValueObjects
{
    public class Circle : IShape
    {
        public Length Radius { get; set; }

        public Circle(Length radius)
        {
            Radius = radius;
        }

        public SurfaceArea CalculateSurfaceArea()
        {
            return SurfaceArea.Create(Math.PI * Radius * Radius);
        }
    }
}
