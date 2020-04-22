using System;
using System.Text;

namespace BaiTapOOP3
{
    class Program
    {
        static Number CreateNewNumber(string numberSystem)
        {
            Console.Write("Giá trị của số cần chuyển: ");
            string number = Console.ReadLine();
            Number newNumber = new Number(number, numberSystem);
            return newNumber;
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
            string numberSystem;
            while (true)
            {
                do
                {
                    Console.Write("\nNhâp vào hệ cơ số của số cần chuyển (2/8/10/16): ");
                    numberSystem = Console.ReadLine();
                } while (numberSystem != "2" && numberSystem != "8" && numberSystem != "10" && numberSystem != "16");
                Number numberObj;
                do
                {
                    numberObj = CreateNewNumber(numberSystem);
                    if (!numberObj.ValidateNumber())
                        Console.WriteLine($"{numberObj.NumberValue} không phải là số với hệ cơ số {numberObj.NumberSystem}");
                } while (!numberObj.ValidateNumber());

                Console.WriteLine("_____________________\nKết quả:");
                Console.WriteLine($"Cơ số 2: {numberObj.ConvertTo(2)}");
                Console.WriteLine($"Cơ số 8: {numberObj.ConvertTo(8)}");
                Console.WriteLine($"Cơ số 10: {numberObj.ConvertToDecimal()}");
                Console.WriteLine($"Cơ số 16: {numberObj.ConvertTo(16)}");
            }
        }
    }
}