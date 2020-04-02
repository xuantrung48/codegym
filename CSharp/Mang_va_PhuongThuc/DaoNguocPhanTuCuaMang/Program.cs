using System;

namespace DaoNguocPhanTuCuaMang
{
    class Program
    {
        static void Main(string[] args)
        {
            int size;
            int[] array;
            do
            {
                Console.Write("Enter a size: ");
                size = Int32.Parse(Console.ReadLine());
                if (size > 20)
                {
                    Console.WriteLine("Size does not exceed 20");
                }
            } while (size > 20);
            array = new int[size];
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write("Enter element " + (i + 1) + ": ");
                array[i] = Int32.Parse(Console.ReadLine());
            }
            Console.Write("Elements in array: ");
            for (int j = 0; j < array.Length; j++)
            {
                Console.Write(array[j] + " ");
            }
            Console.WriteLine();
            for (int j = 0; j < array.Length / 2; j++)
            {
                int temp = array[j];
                array[j] = array[size - 1 - j];
                array[size - 1 - j] = temp;
            }
            Console.Write("Reverse array: ");
            for (int j = 0; j < array.Length; j++)
            {
                Console.Write(array[j] + " ");
            }
        }
    }
}
