using System;

namespace BaseClassEvents
{
    internal class Rectangle : Shape
    {
        private const double Tolerance = 0.001;
        public double Length { get; private set; }
        public double Width { get; private set; }

        public Rectangle(double length, double width)
        {
            Length = length;
            Width = width;
            Area = length * width;
        }

        public double GetArea() => Area;

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
            // Do any circle-specific processing here
            e.Date = DateTime.Now;
            // Call the base class event invocation mathod
            base.OnShapeChanged(e);
        }

        public override string Draw => $"Drawing a {GetType().Name}";
    }
}
