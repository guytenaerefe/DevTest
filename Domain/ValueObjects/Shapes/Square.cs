using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ValueObjects
{
    public class Square : IShape
    {
        public Length Side { get; set; }

        public SurfaceArea CalculateSurfaceArea()
        {
            return SurfaceArea.Create(Side * Side);
        }
    }
}
