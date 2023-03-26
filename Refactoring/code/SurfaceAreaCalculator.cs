using Application.Collections;
using Domain.Interfaces;
using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Refactoring.Code
{
    public class SurfaceAreaCalculator
    {
        object[] arrObjects { get; set; }
        public double[] arrSurfaceAreas { get; set; }
        internal Logger Logger { get; private set; }

        private ShapeCollection _shapes = new ShapeCollection();
        private SurfaceAreaCollection _surfaceAreas = new SurfaceAreaCollection();



        public SurfaceAreaCalculator()
        {
            this.Logger = new Logger();
        }

        //public void ShowCommands()
        //{
        //    this.Logger.Log("commands:");
        //    this.Logger.Log("- create square {double} (create a new square)");
        //    this.Logger.Log("- create circle {double} (create a new circle)");
        //    this.Logger.Log("- create rectangle {height} {width} (create a new rectangle)");
        //    this.Logger.Log("- create triangle {height} {width} (create a new triangle)");
        //    this.Logger.Log("- print (print the calculated surface areas)");
        //    this.Logger.Log("- calculate (calulate the surface areas of the created shapes)");
        //    this.Logger.Log("- reset (reset)");
        //    this.Logger.Log("- exit (exit the loop)");
        //}

        public void AddShape(IShape shape)
        {
            if (shape == null)
            {
                throw new ArgumentNullException("shape");
            }

            _shapes.Add(shape);
        }

        public void Reset()
        {
            _shapes.Clear();
            _surfaceAreas.Clear();
        }

        public ReadOnlyCollection<IShape> Shapes => _shapes.AsReadOnly();
        public ReadOnlyCollection <SurfaceArea> CalculatedSurfaceAreas => _surfaceAreas.AsReadOnly();




        //public void Add(object pObject)
        //{
        //    object[] arrObjects2;
        //    if (this.arrObjects == null)
        //    {
        //        this.arrObjects = new object[1];
        //        if (this.arrObjects != null)
        //        {
        //            this.arrObjects[0] = pObject;
        //        }
        //    }
        //    else
        //    {
        //        if (this.arrObjects != null)
        //        {
        //            arrObjects2 = new object[this.arrObjects.Length + 1];
        //            int i;
        //            for (i = 0; i < arrObjects2.Length; i++)
        //            {
        //                if (i == arrObjects2.Length - 1)
        //                {
        //                    arrObjects2[i] = pObject;
        //                }
        //                else
        //                {
        //                    arrObjects2[i] = this.arrObjects[i];
        //                }
        //            }
        //            this.arrObjects = arrObjects2;
        //        }
        //    }
        //}

        public void ReadString(string pCommand)
        {
            string[] arrCommands = pCommand.Split(' ');
            //switch (arrCommands[0].ToLower())
            //{
            //    case "create":
            //        if (arrCommands.Length > 1)
            //        {
            //            switch (arrCommands[1].ToLower())
            //            {
            //                case "square":
            //                    Square square = new Square();
            //                    square.Side = Length.Create(double.Parse(arrCommands[2]));
            //                    this.Add(square);
            //                    this.CalculateSurfaceAreas();
            //                    Console.WriteLine("{0} created!", square.GetType().Name);
            //                    break;
            //                case "circle":
            //                    Circle circle = new Circle();
            //                    circle.Radius = double.Parse(arrCommands[2]);
            //                    this.Add(circle);
            //                    this.CalculateSurfaceAreas();
            //                    Console.WriteLine("{0} created!", circle.GetType().Name);
            //                    break;
            //                case "triangle":
            //                    Triangle triangle = new Triangle();
            //                    triangle.Height = double.Parse(arrCommands[2]);
            //                    triangle.Width = double.Parse(arrCommands[3]);
            //                    this.Add(triangle);
            //                    this.CalculateSurfaceAreas();
            //                    Console.WriteLine("{0} created!", triangle.GetType().Name);
            //                    break;
            //                case "rectangle":
            //                    Rectangle rectangle = new Rectangle();
            //                    rectangle.Height = double.Parse(arrCommands[2]);
            //                    rectangle.Width = double.Parse(arrCommands[3]);
            //                    this.Add(rectangle);
            //                    this.CalculateSurfaceAreas();
            //                    Console.WriteLine("{0} created!", rectangle.GetType().Name);
            //                    break;
            //                default:
            //                    goto ShowCommands;
            //            }
            //        }
            //        else
            //        {
            //            ShowCommands();
            //        }
            //        this.ReadString(Console.ReadLine());
            //        break;
            //    case "calculate":
            //        this.CalculateSurfaceAreas();
            //        this.ReadString(Console.ReadLine());
            //        break;
            //    case "print":
            //        if (arrSurfaceAreas != null)
            //        {
            //            for (int i = 0; i < arrSurfaceAreas.Length; i++)
            //            {
            //                Console.WriteLine("[{0}] {1} surface area is {2}", i, arrObjects[i].GetType().Name, arrSurfaceAreas[i]);
            //            }
            //        }
            //        else
            //        {
            //            Console.WriteLine("There are no surface areas to print");
            //        }
            //        this.ReadString(Console.ReadLine());
            //        break;
            //    case "reset":
            //        this.arrSurfaceAreas = null;
            //        this.arrObjects = null;
            //        Console.WriteLine("Reset state!!");
            //        this.ReadString(Console.ReadLine());
            //        break;
            //    case "exit":
            //        break;
            //    default:
            //        ShowCommands:
            //        this.Logger.Log("Unknown command!!!");
            //        this.Logger.Log("commands:");
            //        this.Logger.Log("- create square {double} (create a new square)");
            //        this.Logger.Log("- create circle {double} (create a new circle)");
            //        this.Logger.Log("- create rectangle {height} {width} (create a new rectangle)");
            //        this.Logger.Log("- create triangle {height} {width} (create a new triangle)");
            //        this.Logger.Log("- print (print the calculated surface areas)");
            //        this.Logger.Log("- calculate (calulate the surface areas of the created shapes)");
            //        this.Logger.Log("- reset (reset)");
            //        this.Logger.Log("- exit (exit the loop)");
            //        this.ReadString(Console.ReadLine());
            //        break;
            //}
        }

        public void CalculateSurfaceAreas()
        {
            _surfaceAreas.Clear();

            foreach(IShape shape in _shapes)
            {
                _surfaceAreas.Add(shape.CalculateSurfaceArea());
            }
            //try
            //{
            //    if (this.arrObjects != null)
            //    {
            //        this.arrSurfaceAreas = new double[this.arrObjects.Length];
            //        for (int i = 0; i < this.arrObjects.Length; i++)
            //        {
            //            if (this.arrObjects[i].GetType().Name == "Circle")
            //            {
            //                this.arrSurfaceAreas[i] = ((Circle)this.arrObjects[i]).CalculateSurfaceArea();
            //            }
            //            else
            //            {
            //                if (this.arrObjects[i].GetType().Name == "Rectangle")
            //                {
            //                    this.arrSurfaceAreas[i] = ((Rectangle)this.arrObjects[i]).CalculateSurfaceArea();
            //                }
            //                else
            //                {
            //                    if (this.arrObjects[i].GetType().Name == "Square")
            //                    {
            //                        this.arrSurfaceAreas[i] = ((Square)this.arrObjects[i]).CalculateSurfaceArea();
            //                    }
            //                    else
            //                    {
            //                        if (this.arrObjects[i].GetType().Name == "Triangle")
            //                        {
            //                            this.arrSurfaceAreas[i] = ((Triangle)this.arrObjects[i]).CalculateSurfaceArea();
            //                        }
            //                        else
            //                        {
            //                            throw new Exception("Cannot calculate surface area of unkown object!!!");
            //                        }
            //                    }
            //                }
            //            }
            //        }
            //    }
            //    else if (this.arrObjects == null)
            //    {
            //        throw new Exception("arrItems is null!!");
            //    }

            //}
            //catch (Exception ex)
            //{
            //    this.Logger.Log(ex.ToString());
            //    this.arrObjects = new object[0];
            //}
        }
    }

}
