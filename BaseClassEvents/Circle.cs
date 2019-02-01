using System;

namespace BaseClassEvents
{
    internal class Circle : Shape
    {
        private const double Tolerance = 0.002;
        public double Radious { get; private set; }

        public Circle(double radious)
        {
            Radious = radious;
            Area = 3.14 * radious * radious;
        }

        public void Update(double radious)
        {
            var newArea = radious * radious * 3.14;
            if (!(Math.Abs(Area - newArea) > Tolerance)) return;
            Area = newArea;
            Radious = radious;
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

        public double GetArea() => Area;
    }
}