using System;

namespace FizzBuzzTestDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            FizzBuzzTranslate n = new FizzBuzzTranslate();
            n.Number = 15;
            Console.WriteLine(n.GetResult());
        }
    }
}
