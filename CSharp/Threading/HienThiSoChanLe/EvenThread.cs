using System;
using System.Collections.Generic;
using System.Text;

namespace HienThiSoChanLe
{
    class EvenThread
    {
        public void Run()
        {
            for (int i = 0; i < 11; i++)
                if (i % 2 == 0)
                    Console.WriteLine($"Even number: {i}");
        }
    }
}
