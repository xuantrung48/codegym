namespace Shapes
{
    class Location
    {
        public double x = 0, y = 0;
        public Location() { }
        public Location(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
        public override string ToString()
        {
            return $"x = {x}, y = {y}";
        }
    }
}
