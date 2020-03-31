using System;

namespace TinhSoNgayTrongThang
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Nhap vao thang: ");
            int month = Convert.ToInt32(Console.ReadLine());

            switch (month)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    Console.WriteLine("Thang " + month + " co 31 ngay.");
                    break;
                case 2:
                    Console.WriteLine("Thang 2 co 28 hoac 29 ngay.");
                    break;
                default:
                    Console.WriteLine("Thang " + month + " co 30 ngay.");
                    break;
            }
            Console.Read();
        }
    }
}
