using System;

namespace Bai2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Nhap vao kich thuoc ma tran: ");
            int length = 0;
            if (Int32.TryParse(Console.ReadLine(), out int n))
            {
                length = n;
            }

            int[,] intArr1 = taoMangNgaunhien(length);
            int[,] intArr2 = taoMangNgaunhien(length);

            int option = 0;
            do
            {
                Console.WriteLine("__________________________________________");
                Console.WriteLine("MENU:");
                Console.WriteLine("1. In 2 mang");
                Console.WriteLine("2. In ma tran tong cua 2 ma tran");
                Console.WriteLine("3. In ma tran tich cua 2 ma tran");
                Console.WriteLine("4. Exit");
                Console.WriteLine("__________________________________________");
                Console.Write("Lua chon cua ban: ");
                if (Int32.TryParse(Console.ReadLine(), out int num))
                {
                    option = num;
                }
                Console.Clear();
                process(option, intArr1, intArr2);
            }
            while (option != 4);
        }
        static void process(int option, int[,] arr1, int[,] arr2)
        {
            switch (option)
            {
                case 1:
                    Console.WriteLine("Mang 1: ");
                    printArray(arr1);
                    Console.WriteLine("Mang 2: ");
                    printArray(arr2);
                    break;
                case 2:
                    int[,] maTranTong = new int[arr1.GetLength(0), arr1.GetLength(1)];
                    maTranTong = TinhMaTranTong(arr1, arr2);
                    Console.WriteLine("Ma tran tong cua 2 ma tran: ");
                    printArray(maTranTong);
                    break;
                case 3:
                    int[,] maTranTich = new int[arr1.GetLength(0), arr1.GetLength(1)];
                    maTranTich = TinhMaTranTich(arr1, arr2);
                    Console.WriteLine("Ma tran tich cua 2 ma tran: ");
                    printArray(maTranTich);
                    break;
            }    
        }
        static int[,] taoMangNgaunhien(int length)
        {
            int[,] intArr = new int[length, length];
            Random rnd = new Random();
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    intArr[i, j] = rnd.Next(10, 40);
                }
            }
            return intArr;
        }
        static void printArray(int[,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(0); j++)
                {
                    Console.Write(arr[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
        static int[,] TinhMaTranTich(int[,] arr1, int[,] arr2)
        {
            int[,] resultArr = new int[arr1.GetLength(0), arr1.GetLength(1)];
            for (int i = 0; i < arr1.GetLength(0); i++)
            {
                for (int j = 0; j < arr1.GetLength(1); j++)
                {
                    resultArr[i, j] = arr1[i, j] * arr2[i, j];
                }
            }
            return resultArr;
        }
        static int[,] TinhMaTranTong(int[,] arr1, int[,] arr2)
        {
            int[,] resultArr = new int[arr1.GetLength(0), arr1.GetLength(1)];
            for (int i = 0; i < arr1.GetLength(0); i++)
            {
                for (int j = 0; j < arr1.GetLength(1); j++)
                {
                    resultArr[i, j] = arr1[i, j] + arr2[i, j];
                }
            }
            return resultArr;
        }
    }
}
