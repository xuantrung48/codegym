using System;
using System.Text;

namespace BaiTapOOP3
{
    class Program
    {
        static So CreateNewNumber(string heCoSo)
        {
            Console.Write("Giá trị của số cần chuyển: ");
            string number = Console.ReadLine();
            So newNumber = new So(number, heCoSo);
            return newNumber;
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
            string heCoSo;
            while (true)
            {
                do
                {
                    Console.Write("\nHệ cơ số (2/8/16): ");
                    heCoSo = Console.ReadLine();
                } while (heCoSo != "2" && heCoSo != "8" && heCoSo != "16");
                So numberObj;
                do
                {
                    numberObj = CreateNewNumber(heCoSo);
                    if (!numberObj.ValidateNumber())
                        Console.WriteLine($"{numberObj.GiaTri} không phải là số với hệ cơ số {numberObj.HeCoSo}");
                } while (!numberObj.ValidateNumber());

                Console.WriteLine("_____________________");
                Console.WriteLine($"Kết quả: {numberObj.ChuyenVeHCS10()}");
            }
        }
    }
}
