namespace Shapes
{
    class Rectangle : Shape
    {
        private double side1;
        private double side2;
        public Rectangle(double side1, double side2, double x, double y)
        {
            this.side1 = side1;
            this.side2 = side2;
            location.x = x;
            location.y = y;
        }
        public override string ToString()
        {
            return $"this is a rectangle with side1 = {side1}, side2 = {side2}; location: {location}";
        }
        public override double Area()
        {
            return side1 * side2;
        }
        public override double Perimeter()
        {
            return (side1 + side2) * 2;
        }
    }
}
