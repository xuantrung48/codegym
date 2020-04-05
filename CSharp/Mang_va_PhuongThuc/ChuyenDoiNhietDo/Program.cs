using System;

namespace ChuyenDoiNhietDo
{
    class Program
    {
        static void Main(string[] args)
        {
            int option = 0;
            do
            {
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Fahrenheit to Celsius");
                Console.WriteLine("2. Celsius to Fahrenheit");
                Console.WriteLine("3. Exit");
                Console.Write("Your choice: ");
                if (Int32.TryParse(Console.ReadLine(), out int n))
                {
                    option = n;
                }
                process(option);
            } while (option != 3);
        }

        static void process(int option)
        {
            switch(option)
            {
                case 1:
                    double f = 0;
                    Console.Write("Enter Fahrenheit: ");
                    if (Double.TryParse(Console.ReadLine(), out double n))
                    {
                        f = n;
                    }
                    Console.WriteLine("Result: " + f + "f = "+ Math.Round((5.0 / 9) * (f - 32)) + "c");
                    break;
                case 2:
                    double c = 0;
                    Console.Write("Enter Celsius: ");
                    if (Double.TryParse(Console.ReadLine(), out double m))
                    {
                        c = m;
                    }
                    Console.WriteLine("Result: " + c + "c = " + Math.Round((9.0 / 5) * c + 32) + "f");
                    break;
                case 3:
                    Environment.Exit(1);
                    break;
            }
        }
    }
}
