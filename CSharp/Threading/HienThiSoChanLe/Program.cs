using System;
using System.Threading;

namespace HienThiSoChanLe
{
    class Program
    {
        static void Main(string[] args)
        {
            OddThread oddNumbers = new OddThread();
            EvenThread evenNumbers = new EvenThread();
            Thread printOddNumbers = new Thread(oddNumbers.Run);
            Thread printEventNumbers = new Thread(evenNumbers.Run);
            printOddNumbers.Start();
            printOddNumbers.Join();
            printEventNumbers.Start();
        }
    }
}
