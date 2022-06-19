using Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refactoring
{
    public class SurfaceAreaCalculator
    {
        public Dictionary<IShape, Double> SurfaceAreas { get; set; }
        private ILogger _logger { get;  set; }

        public SurfaceAreaCalculator(ILogger logger)
        {
            _logger=logger;
        }

        public void ShowCommands()
        {
            SurfaceAreas = new Dictionary<IShape, double>();
            _logger.Log("commands:");
            _logger.Log("- create square {double} (create a new square)");
            _logger.Log("- create circle {double} (create a new circle)");
            _logger.Log("- create rectangle {height} {width} (create a new rectangle)");
            _logger.Log("- create triangle {height} {width} (create a new triangle)");
            _logger.Log("- create trapezoid {Base Length 1} { Base Length 2} {height} (create a new trapezoid)");
            _logger.Log("- print (print the calculated surface areas)");
            _logger.Log("- reset (reset)");
            _logger.Log("- exit (exit the loop)");
        }

        public void ReadString(string pCommand)
        {

            string[] arrCommands = pCommand.Split(' ');
            switch (arrCommands[0].ToLower())
            {
                case "create":
                    if (arrCommands.Length > 1)
                    {
                        switch (arrCommands[1].ToLower())
                        {
                            case "square":
                                var square = new Square();
                                square.Side = double.Parse(arrCommands[2]);

                                SurfaceAreas.Add(square, square.CalculateSurfaceArea());

                                Console.WriteLine("{0} created!", square.GetType().Name);
                                break;
                            case "circle":
                                var circle = new Circle();
                                circle.Radius = double.Parse(arrCommands[2]);
                                SurfaceAreas.Add(circle, circle.CalculateSurfaceArea());

                                Console.WriteLine("{0} created!", circle.GetType().Name);
                                break;
                            case "triangle":
                                var triangle = new Triangle();
                                triangle.Height = double.Parse(arrCommands[2]);
                                triangle.Width = double.Parse(arrCommands[3]);
                                SurfaceAreas.Add(triangle, triangle.CalculateSurfaceArea());

                                Console.WriteLine("{0} created!", triangle.GetType().Name);
                                break;
                            case "rectangle":
                                var rectangle = new Rectangle();
                                rectangle.Height = double.Parse(arrCommands[2]);
                                rectangle.Width = double.Parse(arrCommands[3]);
                                SurfaceAreas.Add(rectangle, rectangle.CalculateSurfaceArea());

                                Console.WriteLine("{0} created!", rectangle.GetType().Name);
                                break;
                            case "trapezoid":
                                var trapezoid = new Trapezoid();
                                trapezoid.BaseLengthA = double.Parse(arrCommands[2]);
                                trapezoid.BaseLengthB = double.Parse(arrCommands[3]);
                                trapezoid.Height = double.Parse(arrCommands[4]);                              
                                SurfaceAreas.Add(trapezoid, trapezoid.CalculateSurfaceArea());

                                Console.WriteLine("{0} created!", trapezoid.GetType().Name);
                                break;
                            default:
                                goto ShowCommands;
                        }
                    }
                    else
                    {
                        ShowCommands();
                    }
                    ReadString(Console.ReadLine());
                    break;

                case "print":
                    if (SurfaceAreas != null && SurfaceAreas.Count > 0)
                    {
                        foreach (var surfaceArea in SurfaceAreas)
                        {
                            Console.WriteLine("{0} surface area is {1}", surfaceArea.Key.GetType().Name, surfaceArea.Value);
                        }
                    }
                    else
                    {
                        Console.WriteLine("There are no surface areas to print");
                    }
                    this.ReadString(Console.ReadLine());
                    break;
                case "reset":
                    SurfaceAreas = new Dictionary<IShape, double>();
                    Console.WriteLine("Reset state!!");
                    this.ReadString(Console.ReadLine());
                    break;
                case "exit":
                    break;
                default:
                ShowCommands:
                    ShowCommands();
                    this.ReadString(Console.ReadLine());
                    break;
            }
        }


    }

}
