using System;

namespace TinhDienTichHinhChuNhat
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter rectangle's width: ");
            float width = float.Parse(Console.ReadLine());
            Console.Write("Enter rectangle's height: ");
            float height = float.Parse(Console.ReadLine());
            Console.WriteLine("The area of the rectangle is " + areaRectangle(width, height));
            Console.Read();
        }
        static double areaRectangle(float w, float h)
        {
            return w * h;
        }
    }
}
