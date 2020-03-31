using System;

namespace KiemTraNamNhuan
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a year: ");
            int year = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(year + " is " + (isLeapYear(year) ? "a leap year." : "not a leap year"));
        }
        static bool isLeapYear(int y)
        {
            if ((y % 4 == 0 && y % 100 != 0) || (y % 100 == 0 && y % 400 == 0))
                return true;
            return false;
        }
    }
}
