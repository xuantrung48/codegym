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

            int[,] intArr = TaoMangNgaunhien(length);

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
                Process(option, intArr);
            } while (option != 8);
            
        }
        static void Process(int n, int[,] intArr)
        {
            switch (n)
            {
                case 1:
                    Console.WriteLine("Tong cac so chan trong mang: " + TongSoChan(intArr));
                    break;
                case 2:
                    Console.WriteLine("Tong cac so tren duong cheo chinh: " + TongCheoChinh(intArr));
                    break;
                case 3:
                    Console.WriteLine("Tong cac so tren duong cheo phu: " + TongCheoPhu(intArr));
                    break;
                case 4:
                    Console.WriteLine("Tong cac so tren 4 duong bien: " + TongDuongBien(intArr));
                    break;
                case 5:
                    InMang(intArr); ;
                    break;
                case 6:
                    InMaTranTamGiacDuoi(intArr);
                    break;
                case 7:
                    InMaTranTamGiacTren(intArr);
                    break;
            }
        }
        static int[,] TaoMangNgaunhien(int length)
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
        static void InMaTranTamGiacTren(int[,] arr)
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
        static void InMaTranTamGiacDuoi(int[,] arr)
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
        static void InMang(int[,] arr)
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
        static int TongDuongBien(int[,] arr)
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
        static int TongSoChan(int[,] arr)
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
        static int TongCheoChinh(int[,] arr)
        {
            int sum = 0;
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                sum += arr[i, i];
            }
            return sum;
        }
        static int TongCheoPhu(int[,] arr)
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
