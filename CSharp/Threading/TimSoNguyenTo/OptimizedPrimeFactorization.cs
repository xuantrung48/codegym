using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace TimSoNguyenTo
{
    class OptimizedPrimeFactorization
    {
        public bool IsPrime(int number)
        {
            for (int i = 2; i <= Math.Sqrt(number); i++)
                if (number % i == 0)
                    return false;
            return (number >= 2 && true);
        }
        public void Run()
        {
            DateTime startTime = DateTime.Now;
            var checkPrime = IsPrime(1111000039);
            DateTime endTime = DateTime.Now;
            Console.WriteLine($"Thread 1: {checkPrime}, Processing time: {(endTime - startTime).TotalMilliseconds}");
        }
    }
}
