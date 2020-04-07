using System;

namespace LopHinhChuNhat
{
    class Rectangle
    {
        private double width;
        private double height;

        public Rectangle()
        {

        }
        public Rectangle(double w, double h)
        {
            this.width = w;
            this.height = h;
        }

        public double GetArea()
        {
            return this.width * this.height;
        }

        public double GetPerimeter()
        {
            return 2 * (this.width + this.height);
        }
        public void Display()
        {
            Console.WriteLine("Rectangle {" + "width = " + this.width + ", height = " + this.height + "}");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the width: ");
            Double.TryParse(Console.ReadLine(), out double width);
            Console.Write("Enter the height: ");
            Double.TryParse(Console.ReadLine(), out double height);
            Rectangle rectangle = new Rectangle(width, height);
            Console.WriteLine("Area: " + rectangle.GetArea());
            Console.WriteLine("Perimeter: " + rectangle.GetPerimeter());
            rectangle.Display();
        }
    }
}
