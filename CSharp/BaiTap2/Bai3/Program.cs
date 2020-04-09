using System;

namespace Bai3
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 0, m = 0;
            Console.Write("Nhap vao chieu cao cua ma tran: ");
            if (Int32.TryParse(Console.ReadLine(), out int num))
            {
                n = num;
            }
            Console.Write("Nhap vao chieu dai cua ma tran: ");
            if (Int32.TryParse(Console.ReadLine(), out num))
            {
                m = num;
            }

            int[,] intArr = taoMangngauNhien(n, m);

            int option = 0;
            do
            {
                Console.WriteLine("__________________________________________");
                Console.WriteLine("MENU:");
                Console.WriteLine("1. Hien thi ma tran");
                Console.WriteLine("2. Hien thi ma tran theo gia tri nhap vao");
                Console.WriteLine("3. Hien thi ma tran voi gia tri la boi so cua 5");
                Console.WriteLine("4. Tao ma tran dao chieu");
                Console.WriteLine("5. Exit");
                Console.WriteLine("__________________________________________");
                Console.Write("Lua chon cua ban: ");
                if (Int32.TryParse(Console.ReadLine(), out num))
                {
                    option = num;
                }
                Console.Clear();
                process(option, intArr);
            }
            while (option != 5);
        }
        static void process(int option, int[,] intArr)
        {
            switch (option)
            {
                case 1:
                    printArray(intArr);
                    break;
                case 2:
                    int v = 0;
                    int[,] newArr = new int[intArr.GetLength(0), intArr.GetLength(1)];
                    Console.Write("Nhap vao gia tri de hien thi ma tran: ");
                    if (Int32.TryParse(Console.ReadLine(), out int n))
                    {
                        v = n;
                    }
                    for (int i = 0; i < newArr.GetLength(0); i++)
                    {
                        for (int j = 0; j < newArr.GetLength(1); j++)
                        {
                            newArr[i, j] = v;
                        }
                    }
                    printArray(newArr);
                    break;
                case 3:
                    printArray5(intArr);
                    break;
                case 4:
                    int[,] newArr2 = reverseArray(intArr);
                    printArray(newArr2);
                    break;
            }
        }
        static int[,] taoMangngauNhien(int height, int width)
        {
            int[,] intArr = new int[height, width];
            Random rnd = new Random();
            for (int i = 0; i < intArr.GetLength(0); i++)
            {
                for (int j = 0; j < intArr.GetLength(1); j++)
                {
                    intArr[i, j] = rnd.Next(20, 60);
                }
            }
            return intArr;
        }
        static void printArray(int[,] arr)
        {
            Console.WriteLine("In ma tran: ");
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write(arr[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
        static void printArray5(int[,] arr)
        {
            Console.WriteLine("Ma tran so chia het cho 5: ");
            for (int i = 0; i < arr.GetLength(0); i++) 
            { 
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (arr[i, j] % 5 == 0)
                        Console.Write(arr[i, j] + " ");
                    else
                        Console.Write(" . ");
                }
                Console.WriteLine();
            }
        }
        static int[,] reverseArray(int[,] arr)
        {
            int[,] newArr = new int[arr.GetLength(1), arr.GetLength(0)];

            for (int j = 0; j < arr.GetLength(1); j++)
            {
                for (int i = 0; i < arr.GetLength(0); i++)
                {
                    newArr[j, i] = arr[i, j];
                }
            }
            return newArr;
        }
    }
}
