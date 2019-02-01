using System;
using System.Collections.Generic;

namespace BaseClassEvents
{
    /// <summary>
    /// Represents the surface where on which the shapes are drawn
    /// Subscribes to the shape events so that it knows when to redraw a shape
    /// </summary>
    internal class ShapeContainer
    {
        public List<Shape> ShapesList { get; }

        public ShapeContainer()
        {
            ShapesList = new List<Shape>();
        }

        public void AddShape(Shape s)
        {
            ShapesList.Add(s);
            // Subscribe the to the base class event
            s.ShapeChanged += HandleShapechanged;
        }

        private static void HandleShapechanged(object sender, ShapeEventArgs e)
        {
            Shape s = (Shape)sender;
            // Diagnostic message for demonstration methods
            Console.WriteLine($"Received an event at {e.Date}. {s.Draw}. Shape area now: {e.NewArea}");
        }
    }
}