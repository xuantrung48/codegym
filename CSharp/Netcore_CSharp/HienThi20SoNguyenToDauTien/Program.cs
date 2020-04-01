using System;

namespace HienThi20SoNguyenToDauTien
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("20 so nguyen to dau tien: ");
            int counter = 0;
            int number = 1;
            while (counter < 20)
            {
                if (isPrime(number))
                {
                    Console.Write(number + ", ");
                    counter++;
                }
                number++;
            }
            Console.Read();
        }
        static bool isPrime(int number)
        {
            if (number < 2)
                return false;
            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0)
                    return false;
            }
            return true;
        }
    }
}
