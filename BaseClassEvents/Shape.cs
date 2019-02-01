using System;

namespace BaseClassEvents
{
    /// <summary>
    /// Base class event publisher
    /// </summary>
    internal abstract class Shape
    {
        protected double Area { get; set; }

        /// <summary>
        /// The event
        /// </summary>
        public event EventHandler<ShapeEventArgs> ShapeChanged;

        public abstract string Draw { get; }

        /// <summary>
        /// The event-invonking method that derived classes can override
        /// </summary>
        /// <param name="e">Event object</param>
        protected virtual void OnShapeChanged(ShapeEventArgs e)
        {
            ShapeChanged?.Invoke(this, e);
        }
    }
}