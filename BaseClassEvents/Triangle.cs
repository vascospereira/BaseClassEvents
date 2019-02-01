using System;

namespace BaseClassEvents
{
    internal class Triangle : Shape
    {
        private const double Tolerance = 0.0003;
        public double Length { get; private set; }
        public double Width { get; private set; }

        public Triangle(double length, double width)
        {
            Length = length;
            Width = width;
            Area = (length * width) / 2;
        }

        public double GetArea() => Area;

        public override string Draw => $"Drawing a {GetType().Name}";

        public void Update(double length, double width)
        {
            double newArea = length * width;
            if (!(Math.Abs(Area - newArea) > Tolerance)) return;
            Length = length;
            Width = width;
            Area = newArea;
            OnShapeChanged(new ShapeEventArgs(Area));
        }

        protected override void OnShapeChanged(ShapeEventArgs e)
        {
            e.Date = DateTime.Now;
            base.OnShapeChanged(e);
        }

    }
}