using System;
using System.Threading;

namespace ThreadDonGian
{
    class Program
    {
        static void Main(string[] args)
        {
            NumberGenerator number1 = new NumberGenerator();
            Thread thread1 = new Thread(number1.Run);
            NumberGenerator number2 = new NumberGenerator();
            Thread thread2 = new Thread(number2.Run);
            thread2.Priority = ThreadPriority.Highest;
            thread1.Priority = ThreadPriority.Lowest;
            thread1.Start();
            thread2.Start();
        }
    }
}
