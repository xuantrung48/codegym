using System;

namespace ClassCircle_Cylinder
{
    class Program
    {
        static void Main(string[] args)
        {
            Circle circle = new Circle();
            Console.WriteLine(circle.ToString());

            Circle circle2 = new Circle(2, "blue");
            Console.WriteLine(circle2.ToString());

            Cylinder cylinder = new Cylinder();
            Console.WriteLine(cylinder.ToString());

            Cylinder cylinder2 = new Cylinder(3, "yellow", 2);
            Console.WriteLine(cylinder2.ToString());
        }
    }
    class Circle
    {
        private double radius = 1;
        private string color = "red";
        public double Radius
        {
            get => radius;
            set => radius = value;
        }
        public string Color
        {
            get => color;
            set => color = value;
        }
        public Circle() { }
        public Circle(double radius, string color)
        {
            Radius = radius;
            Color = color;
        }
        public double GetPerimeter()
        {
            return Math.PI * 2 * Radius;
        }
        public double GetArea()
        {
            return Math.PI * Math.Pow(Radius, 2);
        }
        public override string ToString()
        {
            return "This is a circle with radius : " + Radius + ", color: " + Color + ", area: " + GetArea() + ", perimeter: " + GetPerimeter();
        }
    }
    class Cylinder : Circle
    {
        private double height = 1;
        public double Height
        {
            get => height;
            set => height = value;
        }
        public Cylinder() { }
        public Cylinder(double radius, string color, double height)
        {
            Radius = radius;
            Color = color;
            Height = height;
        }
        public double GetVolume()
        {
            return GetArea() * Height;
        }
        public override string ToString()
        {
            return "This is a Cylinder with radis : " + Radius + ", color: " + Color + ", area: " + GetArea() + ", perimeter: " + GetPerimeter();
        }
    }
}
