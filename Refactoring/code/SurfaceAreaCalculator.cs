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
        internal Logger Logger { get; private set; }

        private readonly ShapeCollection _shapes = new ShapeCollection();
        private readonly SurfaceAreaCollection _surfaceAreas = new SurfaceAreaCollection();

        public SurfaceAreaCalculator()
        {
            Logger = new Logger();
        }

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

        public void CalculateSurfaceAreas()
        {
            _surfaceAreas.Clear();
            foreach(IShape shape in _shapes)
            {
                _surfaceAreas.Add(shape.CalculateSurfaceArea());
            }          
        }
    }

}
