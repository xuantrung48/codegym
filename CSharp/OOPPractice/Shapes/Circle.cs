using System;

namespace Shapes
{
    class Circle : Shape
    {
        private double Radius { get; set; }
        public Circle (double radius, double x, double y)
        {
            Radius = radius;
            location.x = x;
            location.y = y;
        }
        public override string ToString()
        {
            return $"This is a circle with radius = {Radius}; location: {location}";
        }
        public override double Area()
        {
            return Math.PI * Math.Pow(Radius, 2);
        }
        public override double Perimeter()
        {
            return Math.PI * 2 * Radius;
        }
    }
}
