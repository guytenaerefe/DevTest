namespace Shapes
{
    public class Trapezoid : IShape
    {
        public double Height { get; set; }

        public double BaseLengthA { get; set; }
        public double BaseLengthB { get; set; }

        public double CalculateSurfaceArea()
        {
            return (BaseLengthA + BaseLengthB) * Height * 0.5;
        }
    }
}