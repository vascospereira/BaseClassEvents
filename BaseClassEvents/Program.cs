using System;
using System.Collections.Generic;
using System.Linq;

namespace BaseClassEvents
{
    internal static class Program
    {
        private static void Main()
        {
            IEnumerable<Shape> allShapes = CreateShapes();
            ShapeContainer sc = new ShapeContainer();
            var shapes = allShapes.ToList();
            SaveShapes(sc, shapes);
            
            IEnumerable<Shape> shapesSaved = sc.ShapesList;
            Console.WriteLine("Before Update");
            ShowSizes(shapesSaved);

            Update(shapes);
            
            Console.WriteLine("After Update");
            ShowSizes(shapesSaved);
            
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        private static void SaveShapes(ShapeContainer sc, IEnumerable<Shape> shapes)
        {
            foreach (var shape in shapes)
            {
                sc.AddShape(shape);
            }
        }

        private static void Update(IEnumerable<Shape> allShapes)
        {
            foreach (var shape in allShapes)
            {
                switch (shape)
                {
                    case Circle c:
                        c.Update(23);
                        break;
                    case Rectangle r:
                        r.Update(11, 13);
                        break;
                    case Triangle t:
                        t.Update(6, 14);
                        break;
                }
            }
        }

        private static IEnumerable<Shape> CreateShapes()
        {
            Shape[] shapes = { new Circle(47), new Rectangle(9, 21), new Triangle(15, 27)};

            foreach (var shape in shapes)
            {
                yield return shape;
            }
        }

        private static void ShowSizes(IEnumerable<Shape> shapes)
        {
            foreach (Shape shape in shapes)
            {
                switch (shape)
                {
                    case Rectangle rec:
                        Console.WriteLine($"{rec.Draw} => Area: {rec.GetArea()}; Length: {rec.Length}; Width: {rec.Width}");
                        break;
                    case Circle cir:
                        Console.WriteLine($"{cir.Draw} => Area: {cir.GetArea()}; Radious: {cir.Radious};");
                        break;
                    case Triangle tri:
                        Console.WriteLine($"{tri.Draw} => Area: {tri.GetArea()}; Length: {tri.Length}; Width: {tri.Width}");
                        break;
                }
            }
        }
    }
}
