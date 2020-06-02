using System;
using System.Text;
namespace Cau1
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
            Console.Write("Nhập vào kích cỡ ma trận: ");
            uint.TryParse(Console.ReadLine(), out uint n);
            int[,] matrix = CreateMatrix((int)n);
            ShowMatrix(matrix);
            Console.WriteLine("Cheo phu: " + TongCheoPhu(matrix));
            Console.WriteLine("Min: " + FindMin(matrix));
            Console.WriteLine("DiagonalDifference:" + DiagonalDifference(matrix));
        }
        static int[,] CreateMatrix(int size)
        {
            Random rd = new Random();
            int[,] matrix = new int[size,size];
            for(int i = 0; i < matrix.GetLength(0); i++)
                for(int j = 0; j < matrix.GetLength(1); j++)
                    matrix[i, j] = rd.Next(40, 80);
            return matrix;
        }
        static int FindMin(int[,] matrix)
        {
            int min = matrix[0, 0];
            foreach (var number in matrix)
                if (min > number)
                    min = number;
            return min;
        }
        static int DiagonalDifference(int[,] matrix)
        {
            return Math.Abs(TongCheoChinh(matrix) - TongCheoPhu(matrix));
        }
        static int TongCheoChinh(int[,] matrix)
        {
            int sum = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
                sum += matrix[i, i];
            return sum;
        }

        static int TongCheoPhu(int[,] matrix)
        {
            int sum = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
                sum += matrix[i, matrix.GetLength(0) - 1 - i];
            return sum;
        }
        static void ShowMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
