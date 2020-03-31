using System;

namespace TinhTienLai
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Nhap vao so von ban dau: ");
            float i = int.Parse(Console.ReadLine());
            Console.Write("Nhap vao lai suat: ");
            float r = float.Parse(Console.ReadLine());
            Console.Write("Nhap vao so thang cho vay: ");
            float t = int.Parse(Console.ReadLine());
            Console.WriteLine("So tien lai la: " + tinhTienLai(i, r, t));
        }
        static float tinhTienLai(float i, float r, float t)
        {
            return i * r / 100 / 12 * 3;
        }
    }
}
