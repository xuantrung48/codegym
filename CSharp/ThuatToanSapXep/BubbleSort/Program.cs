using System;
using System.Globalization;

namespace BubbleSort
{
    class Program
    {
        static int[] Numbers;
        static void Main(string[] args)
        {
            CreateRandomNumbers(10);
            Console.WriteLine("Before sort: ");
            PrintArray();

            BubbleSort();
            Console.WriteLine("After sort: ");
            PrintArray();

        }
        static void CreateRandomNumbers(int length)
        {
            Random rd = new Random();
            int[] numbers = new int[length];
            for (int i = 0; i < numbers.Length; i++)
                numbers[i] = rd.Next(1, 100);
            Numbers = numbers;
        }
        static void BubbleSort()
        {
            bool needNextSort = true;
            for (int i = 1; i < Numbers.Length && needNextSort; i++)
            {
                needNextSort = false;
                for (int j = 0; j < Numbers.Length - i; j++)
                {
                    if (Numbers[j] > Numbers[j + 1])
                    {
                        Swap(ref Numbers[j], ref Numbers[j + 1]);
                        needNextSort = true;
                    }

                }
            }
        }
        static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }
        static void PrintArray()
        {
            foreach (var number in Numbers)
                Console.Write(number + " ");
            Console.WriteLine();
        }
    }
}
