using System;
using System.Collections.Generic;
using System.Text;

namespace BubbleSort_SlectionSort_InsertionSort
{
    class Helper
    {
        public static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }
    }
}
