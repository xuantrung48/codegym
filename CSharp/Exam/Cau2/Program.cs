using System;
using System.Text;
namespace Cau2
{
    class Program
    {
        static int[] numbers;
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
            string option;
            do
            {
                Console.Write("MENU\n" +
                    "1. Tạo mảng\n" +
                    "2. Kiểm tra mảng đối xứng\n" +
                    "3. Sắp xếp mảng\n" +
                    "4. Tìm kiếm mảng\n" +
                    "5. Hiển thị mảng\n" +
                    "6. Thoát\n" +
                    "______________________\n" +
                    "Lựa chọn của bạn: ");
                option = Console.ReadLine();
                Process(option);
            } while (option != "6");

        }
        static void Process(string option)
        {
            switch (option)
            {
                case "1":
                    Console.Write("Nhập vào kích cỡ mảng: ");
                    uint.TryParse(Console.ReadLine(), out uint size);
                    numbers = CreateArray((int) size);
                    break;
                case "2":
                    Console.WriteLine(IsSymmetry() ? "Mảng là đối xứng" : "Mảng không đối xứng");
                    break;
                case "3":
                    BubbleSort();
                    break;
                case "4":
                    if (IsIncrement())
                    {
                        Console.Write("Gía trị cần tìm kiếm: ");
                        int.TryParse(Console.ReadLine(), out int number);
                        int indexOfNumber = Find(number);
                        if (indexOfNumber == -1)
                            Console.WriteLine($"{number} không có trong mảng.");
                        else
                            Console.WriteLine($"Vị trí của {number}: {indexOfNumber + 1}");
                    }
                    else
                        Console.WriteLine("Mảng chưa được sắp xếp");
                    break;
                case "5":
                    ShowArray();
                    break;
            }
        }
        static void ShowArray()
        {
            for (int i = 0; i < numbers.Length; i++)
                Console.Write(numbers[i] + " ");
            Console.WriteLine();
        }
        static int[] CreateArray(int n)
        {
            Random rd = new Random();
            int[] array = new int[n];
            for (int i = 0; i < array.Length; i++)
                array[i] = rd.Next(10, 50);
            return array;
        }
        static void BubbleSort()
        {
            int i, j, temp;
            int n = numbers.Length;
            bool swapped;
            for (i = 0; i < n - 1; i++)
            {
                swapped = false;
                for (j = 0; j < n - i - 1; j++)
                {
                    if (numbers[j] > numbers[j + 1])
                    {
                        temp = numbers[j];
                        numbers[j] = numbers[j + 1];
                        numbers[j + 1] = temp;
                        swapped = true;
                    }
                }
                if (swapped == false)
                    break;
            }
        }
        static bool IsSymmetry()
        {
            for (int i = 0; i < numbers.Length / 2; i++)
                if (numbers[0] != numbers[numbers.Length - i - 1])
                    return false;
            return true;
        }
        static bool IsIncrement()
        {
            for (int i = 0; i < numbers.Length - 1; i++)
                if (numbers[i] > numbers[i + 1])
                    return false;
            return true;
        }
        static int Find(int number)
        {
            int low = 0;
            int high = numbers.Length - 1;
            while (high >= low)
            {
                int mid = (low + high) / 2;
                if (number < numbers[mid])
                    high = mid - 1;
                else if (number == numbers[mid])
                    return mid;
                else
                    low = mid + 1;
            }
            return -1;
        }
    }
}
