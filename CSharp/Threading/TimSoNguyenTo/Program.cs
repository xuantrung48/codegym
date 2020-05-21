using System;
using System.Threading;

namespace TimSoNguyenTo
{
    class Program
    {
        static void Main(string[] args)
        {
            OptimizedPrimeFactorization primeNumbers1 = new OptimizedPrimeFactorization();
            LazyPrimeFactorization primeNumbers2 = new LazyPrimeFactorization();
            Thread printPrimeNumbers1 = new Thread(primeNumbers1.Run);
            Thread printPrimeNumbers2 = new Thread(primeNumbers2.Run);
            printPrimeNumbers1.Start();
            printPrimeNumbers2.Start();
        }
    }
}
