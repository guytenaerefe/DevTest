using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ValueObjects
{
    public  class Rectangle : IShape
    {
        public Length Width { get; set; }
        public Length Height { get; set; }

        public Rectangle(Length width, Length height)
        {
            Width = width;
            Height = height;
        }

        public SurfaceArea CalculateSurfaceArea()
        {
            return SurfaceArea.Create(Height * Width);
        }
    }
}
