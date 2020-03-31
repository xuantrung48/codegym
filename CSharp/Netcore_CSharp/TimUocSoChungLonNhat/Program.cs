using System;

namespace TimUocSoChungLonNhat
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Nhap vao so dau tien:");
            int a = Convert.ToInt32(Console.ReadLine());
            Console.Write("Nhap vao so thu 2: ");
            int b = Convert.ToInt32(Console.ReadLine());
            if (a == 0 || b == 0)
                Console.WriteLine("Khong co uoc so chung lon nhat.");
            else
            {
                while (a != b)
                {
                    if (a > b)
                        a -= b;
                    else
                        b -= a;
                }
                Console.WriteLine("Uoc so chung lon nhat la: " + a);
            }
        }
    }
}
