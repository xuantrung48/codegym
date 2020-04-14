using System;

namespace QuadraticEquation
{
    class Program
    {
        public static void Main()
        {
            double x1 = 0.0;
            double x2 = 0.0;
            Console.WriteLine("Giai phuong trinh bac hai trong C#: ");
            Console.WriteLine("---------------------------------------------------");

            Console.Write("Nhap gia tri cua a: ");
            double a = Convert.ToDouble(Console.ReadLine());
            Console.Write("Nhap gia tri cua b: ");
            double b = Convert.ToDouble(Console.ReadLine());
            Console.Write("Nhap gia tri cua c: ");
            double c = Convert.ToDouble(Console.ReadLine());

            QuadraticEquation qe = new QuadraticEquation(a, b, c);
            double delta = qe.GetDiscriminant(a, b, c);
            if (delta == 0)
            {
                x1 = -b / (2.0 * a);
                x2 = x1;
                Console.WriteLine("The equation has one root = {0}", x1);
            }
            else if (delta > 0)
            {
                x1 = qe.GetRoot1(a, b, delta);
                x2 = qe.GetRoot2(a, b, delta);

                Console.WriteLine("The equation has two roots {0} and {1}\n", x1, x2);
            }
            else
            {
                Console.WriteLine("The equation has no roots");
            }
            Console.ReadKey();
        }
    }
}