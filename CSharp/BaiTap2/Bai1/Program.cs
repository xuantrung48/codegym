using System;

namespace Bai1
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = 0;

            Console.Write("Nhap vao do dai mang: ");
            if(Int32.TryParse(Console.ReadLine(), out int n))
            {
                length = n;
            }

            int[,] intArr = taoMangNgaunhien(length);

            int option = 0;
            do
            {
                Console.WriteLine("__________________________________________");
                Console.WriteLine("MENU:");
                Console.WriteLine("1. Tinh tong cac so chan trong mang");
                Console.WriteLine("2. Tinh tong cac so tren duong cheo chinh");
                Console.WriteLine("3. Tinh tong cac so tren duong cheo phu");
                Console.WriteLine("4. Tinh tong duong bien");
                Console.WriteLine("5. In mang");
                Console.WriteLine("6. In ma tran tam giac duoi");
                Console.WriteLine("7. In ma tran tam giac tren");
                Console.WriteLine("8. Exit");
                Console.WriteLine("__________________________________________");
                Console.Write("Lua chon cua ban: ");
                if (Int32.TryParse(Console.ReadLine(), out int num))
                {
                    option = num;
                }
                Console.Clear();
                process(option, intArr);
            } while (option != 8);
            
        }
        static void process(int n, int[,] intArr)
        {
            switch (n)
            {
                case 1:
                    Console.WriteLine("Tong cac so chan trong mang: " + tongSoChan(intArr));
                    break;
                case 2:
                    Console.WriteLine("Tong cac so tren duong cheo chinh: " + tongCheoChinh(intArr));
                    break;
                case 3:
                    Console.WriteLine("Tong cac so tren duong cheo phu: " + tongCheoPhu(intArr));
                    break;
                case 4:
                    Console.WriteLine("Tong cac so tren 4 duong bien: " + tongDuongBien(intArr));
                    break;
                case 5:
                    inMang(intArr); ;
                    break;
                case 6:
                    inMaTranTamGiacDuoi(intArr);
                    break;
                case 7:
                    inMaTranTamGiacTren(intArr);
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
                    intArr[i, j] = rnd.Next(10, 90);
                }
            }
            return intArr;
        }
        static void inMaTranTamGiacTren(int[,] arr)
        {
            Console.WriteLine("In ma tran tam giac tren: ");
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int k = 0; k < i; k++)
                {
                    Console.Write("   ");
                }
                for (int j = 0; j < arr.GetLength(0) - i; j++)
                {
                    Console.Write(arr[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
        static void inMaTranTamGiacDuoi(int[,] arr)
        {
            Console.WriteLine("In ma tran tam giac duoi: ");
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    Console.Write(arr[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
        static void inMang(int[,] arr)
        {
            Console.WriteLine("In mang: ");
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(0); j++)
                {
                    Console.Write(arr[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
        static int tongDuongBien(int[,] arr)
        {
            int sum = 0;
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(0); j++)
                {
                    if (i == 0 || i == arr.GetLength(0) - 1)
                        sum += arr[i, j];
                    else
                    {
                        if (j == 0 || j == arr.GetLength(0) - 1)
                            sum += arr[i,j];
                    }
                }
            }
            return sum;
        }
        static int tongSoChan(int[,] arr)
        {
            int sum = 0;
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(0); j++)
                {
                    if (arr[i, j] % 2 == 0) sum += arr[i, j];
                }
            }
            return sum;
        }
        static int tongCheoChinh(int[,] arr)
        {
            int sum = 0;
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                sum += arr[i, i];
            }
            return sum;
        }
        static int tongCheoPhu(int[,] arr)
        {
            int sum = 0;
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                sum += arr[i, arr.GetLength(0) - 1 - i];
            }
            return sum;
        }
    }
}
