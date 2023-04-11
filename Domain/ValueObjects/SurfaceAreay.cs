using Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ValueObjects
{
    public class SurfaceArea
    {
        public double Value { get; private set; }

        public SurfaceArea()
        {
            
        }

        private SurfaceArea(double value)
        {
            Value = value;
        }

        public static implicit operator double(SurfaceArea surfaceArea) => surfaceArea.Value;

        public static SurfaceArea Create(double value)
        {
            if(value < 0)
            {
                throw new InvalidLengthException("SurfaceArea should be >= 0");
            }

            return new SurfaceArea(value);
        }
    }
}
