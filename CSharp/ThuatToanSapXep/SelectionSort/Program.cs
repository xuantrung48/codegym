using System;

namespace SelectionSort
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
            SelectionSort();
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
        static void SelectionSort()
        {
            int n = Numbers.Length;

            for (int i = 0; i < n - 1; i++)
            {
                int min_idx = i;
                for (int j = i + 1; j < n; j++)
                    if (Numbers[j] < Numbers[min_idx])
                        min_idx = j;
                Swap(ref Numbers[min_idx], ref Numbers[i]);
            }
        }
        static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }
    }
}
