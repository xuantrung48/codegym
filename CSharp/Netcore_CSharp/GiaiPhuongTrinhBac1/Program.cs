using System;

namespace GiaiPhuongTrinhBac1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Giai phuong trinh bac 1 ax + b = 0");
            Console.Write("Nhap vao a: ");
            float a = float.Parse(Console.ReadLine());
            Console.Write("Nhap vao b: ");
            float b = float.Parse(Console.ReadLine());
            if (a != 0)
                Console.WriteLine("Phuong trinh co 1 nghiem x = " + (-b / a) + ".");
            else
            {
                if (b == 0)
                    Console.WriteLine("Phuong trinh co vo so nghiem.");
                else
                    Console.WriteLine("Phuong trinh vo nghiem.");
            }
        }
    }
}
