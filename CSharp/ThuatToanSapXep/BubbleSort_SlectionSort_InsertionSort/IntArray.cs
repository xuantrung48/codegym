using System;
using System.Collections.Generic;
using System.Text;

namespace BubbleSort_SlectionSort_InsertionSort
{
    class IntArray
    {
        public int[] Numbers;
        public IntArray(int length)
        {
            Random rd = new Random();
            int[] numbers = new int[length];
            for (int i = 0; i < numbers.Length; i++)
                numbers[i] = rd.Next(1, 100);
            Numbers = numbers;
        }
        public void Show()
        {
            for (int i = 0; i < Numbers.Length; i++)
                Console.Write(Numbers[i] + " ");
            Console.WriteLine();
        }
        public void BubbleSort()
        {
            bool needNextSort = true;
            for (int k = 1; k < Numbers.Length && needNextSort; k++)
            {
                needNextSort = false;
                for (int i = 0; i < Numbers.Length - k; i++)
                    if (Numbers[i] > Numbers[i + 1])
                    {
                        Helper.Swap(ref Numbers[i], ref Numbers[i + 1]);
                        needNextSort = true;
                    }
            }
        }
        public void SelectionSort()
        {
            for (int i = 0; i < Numbers.Length - 1; i++)
            {
                int currentMinIndex = i;

                for (int j = i + 1; j < Numbers.Length; j++)
                    if (Numbers[i] > Numbers[j])
                        currentMinIndex = j;

                Helper.Swap(ref Numbers[i], ref Numbers[currentMinIndex]);
            }
        }
        public void InsertionSort()
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
