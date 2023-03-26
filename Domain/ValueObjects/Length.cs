using Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ValueObjects
{
    public class Length
    {
        public double Value { get; private set; }

        public Length()
        {
            
        }

        private Length(double value)
        {
            Value = value;
        }

        public static implicit operator double(Length length) => length.Value;

        public static Length Create(double value)
        {
            if(value < 0)
            {
                throw new InvalidLengthException("Length should be >= 0");
            }

            return new Length(value);
        }
    }
}
