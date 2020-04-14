using System;

namespace AccessModifier2
{
    class Circle
    {
        private double radius = 1;
        private string color = "red";
        public Circle() { }
        public Circle(double radius)
        {
            this.radius = radius;
        }
        public double GetRadius()
        {
            return this.radius;
        }
        public double GetArea()
        {
            return Math.PI * this.radius * this.radius;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Circle TestCircle = new Circle(2);
            Console.WriteLine(TestCircle.GetRadius());
            Console.WriteLine(TestCircle.GetArea());
        }
    }
}
