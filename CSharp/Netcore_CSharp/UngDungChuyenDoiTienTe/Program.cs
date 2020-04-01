using System;

namespace UngDungChuyenDoiTienTe
{
    class Program
    {
        static void Main(string[] args)
        {
            int option = 0;
            do
            {
                Console.WriteLine("_____________________________");
                Console.WriteLine("Ung dung chuyen doi tien te:");
                Console.WriteLine("1. USD -> VND");
                Console.WriteLine("2. VND -> USD");
                Console.WriteLine("3. Exit");
                Console.WriteLine("_____________________________");
                Console.Write("Your choice: ");
                if (int.TryParse(Console.ReadLine(), out int n))
                {
                    option = n;
                }
                Process(option);
            }
            while (option != 3);
        }
        static void Process(int option)
        {
            switch (option)
            {
                case 1:
                    double usd = 0;
                    Console.Write("Nhap vao so tien USD: ");
                    if (double.TryParse(Console.ReadLine(), out double m))
                    {
                        usd = m;
                    }
                    Console.WriteLine("Gia tri VND: " + usd * 23000 + " VND");
                    break;
                case 2:
                    double vnd = 0;
                    Console.Write("Nhap vao so tien VND: ");
                    if (double.TryParse(Console.ReadLine(), out double m1))
                    {
                        vnd = m1;
                    }
                    Console.WriteLine("Gia tri USD: " + Math.Round(vnd / 23000, 2) + " USD");
                    break;
            }    
        }
    }
}
