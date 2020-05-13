using System;

namespace InsertionSort
{
    class Program
    {
        static int[] Numbers;
        static void Main(string[] args)
        {
            CreateNumbersArray(10);
            Console.WriteLine("Before sort: ");
            ShowNumbers();
            Console.WriteLine("After sort: ");
            InsertionSort();
            ShowNumbers();
        }
        static void CreateNumbersArray(int length)
        {
            Random rd = new Random();
            int[] numbers = new int[length];
            for (int i = 0; i < numbers.Length; i++)
                numbers[i] = rd.Next(1, 100);
            Numbers = numbers;
        }
        static void ShowNumbers()
        {
            foreach (var number in Numbers)
                Console.Write(number + " ");
            Console.WriteLine();
        }
        static void InsertionSort()
        {
            for (int i = 1; i < Numbers.Length; ++i)
            {
                int value = Numbers[i];
                int j = i - 1;
                while (j >= 0 && Numbers[j] > value)
                {
                    Numbers[j + 1] = Numbers[j];
                    j -= 1;
                }
                Numbers[j + 1] = value;
            }
        }
    }
}
