using System;

namespace BaiTap
{
    class Program
    {
        static void Main(string[] args)
        {
            int option = 0;
            int[] numbers = { };
            do
            {
                Console.WriteLine();
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Tao mang so nguyen");
                Console.WriteLine("2. Hien thi mang so nguyen");
                Console.WriteLine("3. Hien thi tong gia tri trong mang");
                Console.WriteLine("4. Hien thi cac so chan trong mang");
                Console.WriteLine("5. Exit");
                Console.WriteLine("----------------------------------");
                Console.Write("Your option: ");
                if (int.TryParse(Console.ReadLine(), out int number))
                {
                    option = number;
                }
                Processor(option, ref numbers);
            }
            while (option != 5);
        }

        static void Processor(int option, ref int[] intArr)
        {
            Console.Clear();
            switch (option)
            {
                case 1:
                    intArr = creatIntArr();
                    break;
                case 2:
                    showIntArr(intArr);
                    break;
                case 3:
                    Console.WriteLine("Tong cac gia tri trong mang: " + sumArr(intArr));
                    break;
                case 4:
                    displayEven(intArr);
                    break;
            }
        }
        static int[] creatIntArr()
        {
            int[] intArr = new int[20];
            Random rnd = new Random();
            for (int i = 0; i <intArr.Length; i++)
            {
                intArr[i] = rnd.Next(10, 50);
            }
            return intArr;
        }
        static void showIntArr(int[] arr)
        {
            Console.WriteLine();
            string result = "";
            for (int i = 0; i < arr.Length; i++)
            {
                result += arr[i] + " ";
            }
            Console.Write("Mang so nguyen: " + result);
        }

        static int sumArr(int[] arr)
        {
            int sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
            }
            return sum;
        }

        static void displayEven(int[] arr)
        {
            Console.WriteLine();
            Console.Write("Cac so chan co trong mang: ");
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] % 2 == 0)
                Console.Write(arr[i] + " ");
            }
        }
    }
}
