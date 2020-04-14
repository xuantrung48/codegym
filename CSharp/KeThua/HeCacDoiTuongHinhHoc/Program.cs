using System;

namespace HeCacDoiTuongHinhHoc
{
    class Program
    {
        static void Main(string[] args)
        {
            Shape shape = new Shape();
            Console.WriteLine(shape);
            shape = new Shape("red", false);
            Console.WriteLine(shape);

            Circle circle = new Circle();
            Console.WriteLine(circle);
            circle = new Circle(3.5);
            Console.WriteLine(circle);
            circle = new Circle("indigo", false, 3.5);
            Console.WriteLine(circle);

            Rectangle rectangle = new Rectangle();
            Console.WriteLine(rectangle);
            rectangle = new Rectangle(2.3, 5.8);
            Console.WriteLine(rectangle);
            rectangle = new Rectangle(2.5, 3.8, "orange", true);
            Console.WriteLine(rectangle);

            Square square = new Square();
            Console.WriteLine(square);
            square = new Square(2.3);
            Console.WriteLine(square);
            square = new Square(5.8, "yellow", true);
            Console.WriteLine(square);
        }
    }
}
