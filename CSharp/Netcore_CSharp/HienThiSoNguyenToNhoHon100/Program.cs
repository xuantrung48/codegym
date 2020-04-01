using System;

namespace HienThiSoNguyenToNhoHon100
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("So nguyen to nho hon 100: ");
            for(int i = 1; i < 100; i++)
            {
                if (isPrime(i))
                    Console.Write(i + " ");
            }
            Console.Read();
        }
        static bool isPrime(int n)
        {
            if (n < 2)
                return false;
            for (int i = 2; i <= Math.Sqrt(n); i++)
            {
                if (n % i == 0)
                    return false;
            }
            return true;
        }
    }
}
