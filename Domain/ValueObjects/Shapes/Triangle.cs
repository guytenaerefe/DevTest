using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ValueObjects
{
    public class Triangle : IShape
    {
        public Length Width { get; set; }
        public Length Height { get; set; }


        public Triangle(Length width, Length height)
        {
            Width = width; 
            Height = height;
        }

        public SurfaceArea CalculateSurfaceArea()
        {
            return SurfaceArea.Create(0.5 * (Height * Width));
        }
    }
}
