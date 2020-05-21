using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ThreadDonGian
{
    class NumberGenerator
    {
        public void Run()
        {
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(500);
                Console.WriteLine($"{i + 1}");
            }
        }
    }
}
