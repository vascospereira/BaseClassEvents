using System;

namespace BaseClassEvents
{
    /// <summary>
    /// Special EventArgs class to holds info about Shapes
    /// </summary>
    internal class ShapeEventArgs : EventArgs
    {
        public double NewArea { get; }
        public DateTime Date { get; set; }

        public ShapeEventArgs(double area)
        {
            NewArea = area;
        }
    }
}