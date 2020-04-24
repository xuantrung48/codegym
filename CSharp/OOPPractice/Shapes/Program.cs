using System;

namespace Shapes
{
    class Program
    {
        static void Main(string[] args)
        {
            Shape rectangle = new Rectangle(2, 4, 2, 3);
            Console.WriteLine(rectangle);
            Console.WriteLine($"Area: {rectangle.Area()}");
            Console.WriteLine($"Perimeter: {rectangle.Perimeter()}");
            Shape circle = new Circle(3, 4, 5);
            Console.WriteLine(circle);
            Console.WriteLine($"Area: {circle.Area()}");
            Console.WriteLine($"Perimeter: {circle.Perimeter()}");
        }
    }
}
