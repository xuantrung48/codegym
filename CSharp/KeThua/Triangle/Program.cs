using System;

namespace Triangle
{
    class Shape
    {
        private string color = "green";
        public Shape() { }
        public Shape(string color)
        {
            this.color = color;
        }
        public string GetColor()
        {
            return this.color;
        }
        public void SetColor(string color)
        {
            this.color = color;
        }
        public override string ToString()
        {
            return "A Shape with color of " + this.color + ".";
        }
    }
    class Triangle : Shape
    {
        private double side1 = 1.0;
        private double side2 = 1.0;
        private double side3 = 1.0;
        public double Side1
        {
            get => side1;
            set => side1 = value;
        }
        public double Side2
        {
            get => side2;
            set => side2 = value;
        }
        public double Side3
        {
            get => side3;
            set => side3 = value;
        }
        public Triangle() { }
        public Triangle(double s1, double s2, double s3)
        {
            side1 = s1;
            side2 = s2;
            side3 = s3;
        }
        public Triangle(string color, double s1, double s2, double s3)
        {
            this.SetColor(color);
            side1 = s1;
            side2 = s2;
            side3 = s3;
        }
        public double GetPerimeter()
        {
            return side1 + side2 + side3;
        }
        public double GetArea()
        {
            double p = (side1 + side2 + side3) / 2;
            return Math.Sqrt(p * (p - side1) * (p - side2) * (p - side3));
        }
        public override string ToString()
        {
            return "This is a Triangle with color: " + GetColor() + ". The length of side1: " + side1 + ", side2: " + side2 + ", side3: " + side3 + ". Area: " + GetArea() + ", perimeter: " + GetPerimeter() + ".";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Triangle with: ");
            Console.Write("Color: ");
            string color = Console.ReadLine();
            Console.Write("The length of side1: ");
            Double.TryParse(Console.ReadLine(), out double side1);
            Console.Write("The length of side2: ");
            Double.TryParse(Console.ReadLine(), out double side2);
            Console.Write("The length of side3: ");
            Double.TryParse(Console.ReadLine(), out double side3);
            Triangle triangle = new Triangle(color, side1, side2, side3);
            Console.WriteLine(triangle.ToString());
        }
    }
}
