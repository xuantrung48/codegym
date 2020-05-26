using System;
using System.Text;

namespace BaiTap1
{
    class Program
    {
        static int[] numbers;
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
            Menu();
        }
        static void Menu()
        {
            do
            {
                Console.Write("Menu\n" +
                    "1. Tạo mảng\n" +
                    "2. Kiểm tra mảng đối xứng\n" +
                    "3. Sắp xếp mảng\n" +
                    "4. Tìm kiếm mảng\n" +
                    "5. Thoát\n" +
                    "_________________________\n" +
                    "Lựa chọn của bạn: ");
                string option = Console.ReadLine();
                Process(option);
            } while (true);
        }
        static void Process (string option)
        {
            switch (option)
            {
                case "1":
                    numbers = CreateArray();
                    ShowArray(numbers);
                    break;
                case "2":
                    Console.WriteLine(IsSymmetryArray(numbers));
                    break;
                case "3":
                    SelectionSort(numbers);
                    ShowArray(numbers);
                    break;
                case "4":
                    if (IsSorted(numbers))
                    {
                        Console.Write("Số cần tìm: ");
                        int.TryParse(Console.ReadLine(), out int number);
                        int idx = Find(number, numbers);
                        if (idx == -1)
                            Console.WriteLine("Không tìm thấy!");
                        else
                            Console.WriteLine($"Vị trí: {idx + 1}");
                    }
                    else
                        Console.WriteLine("Mảng chưa được sắp xếp!");
                    break;
                case "5":
                    Environment.Exit(0);
                    break;
            }
        }
        static int[] CreateArray()
        {
            Console.Write("Nhập vào kích cỡ mảng: ");
            int.TryParse(Console.ReadLine(), out int arraySize);
            int[] numbersArray = new int[arraySize];
            Random rd = new Random();
            for (int i = 0; i < arraySize; i++)
                numbersArray[i] = rd.Next(30, 60);
            return numbersArray;
        }
        static bool IsSymmetryArray(int[] numbersArray)
        {
            for (int i = 0; i < numbersArray.Length / 2; i++)
                if (numbersArray[i] != numbersArray[numbersArray.Length -1 - i])
                    return false;
            return true;
        }
        static bool IsSorted(int[] numbersArray)
        {
            for (int i = 0; i < numbersArray.Length - 2; i++)
                if (numbersArray[i] > numbersArray[i + 1])
                    return false;
            return true;
        }
        static void SelectionSort(int[] numbersArray)
        {
            int n = numbersArray.Length;

            for (int i = 0; i < n - 1; i++)
            {
                int min_idx = i;
                for (int j = i + 1; j < n; j++)
                    if (numbersArray[j] < numbersArray[min_idx])
                        min_idx = j;
                int temp = numbersArray[min_idx];
                numbersArray[min_idx] = numbersArray[i];
                numbersArray[i] = temp;
            }
        }
        static void ShowArray(int[] numbersArray)
        {
            Console.Write("[");
            for (int i = 0; i < numbersArray.Length; i++)
                Console.Write(numbersArray[i] + " ");
            Console.WriteLine("]");
        }
        static int Find(int number, int[] numbersArray)
        {
            int low = 0;
            int high = numbersArray.Length - 1;
            while (high >= low)
            {
                int mid = (low + high) / 2;
                if (number < numbersArray[mid])
                    high = mid - 1;
                else if (number == numbersArray[mid])
                    return mid;
                else
                    low = mid + 1;
            }
            return -1;
        }
    }
}
