using System;

namespace TinhBMI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Tinh chi so BMI");
            Console.Write("Nhap vao chieu cao (cm): ");
            double height = double.Parse(Console.ReadLine()) / 100;
            Console.Write("Nhap vao can nang (kg): ");
            double weight = double.Parse(Console.ReadLine());
            double bmi = weight / Math.Pow(height, 2);
            Console.Write("Chi so BMI cua ban la: " + Math.Round(bmi, 1));

            if (bmi < 18)
                Console.WriteLine(" Ban hoi gay.");
            else if (bmi < 25.0)
                Console.WriteLine(" Ban binh thuong.");
            else if (bmi < 30.0)
                Console.WriteLine(" Ban hoi thua can.");
            else
                Console.WriteLine(" Ban bi beo phi.");
        }
    }
}
