namespace Shapes.Lib
{
    public class Circle : IShape
    {
        public double Radius { get; set; }
        public double CalculateSurfaceArea()
        {
            return Math.Round(Math.PI * (Radius * Radius), 2);
        }
    }
}
