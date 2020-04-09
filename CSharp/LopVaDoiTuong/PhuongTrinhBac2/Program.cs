using System;

namespace PhuongTrinhBac2
{
    class QuadraticEquation
    {
        public double a
        { get; set; }
        public double b
        { get; set; }
        public double c
        { get; set; }
        public double GetDiscriminant()
        {
            return (Math.Pow(this.b, 2) - 4 * this.a * this.c);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
