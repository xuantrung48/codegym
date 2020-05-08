using System;

namespace Bai1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] matrix = CreateMatrix(5,3);
            Console.WriteLine("Matrix:");
            ShowMatrix(matrix);
            Console.WriteLine("Max row:");
            ShowArray(ShowMaxRow(matrix, out int pos));
            Console.WriteLine($"Max row position: {pos + 1}");
        }
        static int[,] CreateMatrix(int n, int m)
        {
            int[,] matrix = new int[n, m];
            Random rd = new Random();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    matrix[i, j] = rd.Next(10, 50);
                }
            }
            return matrix;
        }
        static int Sum(int[] numbersArray)
        {
            int sum = 0;
            foreach(var number in numbersArray)
            {
                sum += number;
            }
            return sum;
        }
        static int[] GetRow(int[,] matrix, int row)
        {
            int[] array = new int[matrix.GetLength(1)];
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                array[i] = matrix[row, i];
            }
            return array;
        }
        static int[] ShowMaxRow(int[,] matrix, out int pos)
        {
            pos = 0;
            int[] maxArr = GetRow(matrix, 0);
            for (int i = 1; i < matrix.GetLength(0); i++)
            {
                if (Sum(maxArr) < Sum(GetRow(matrix, i)))
                {
                    maxArr = GetRow(matrix, i);
                    pos = i;
                }
            }
            return maxArr;

        }
        static void ShowArray(int[] array)
        {
            foreach (var item in array)
                Console.Write(item + " ");
            Console.WriteLine();
        }
        static void ShowMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
                ShowArray(GetRow(matrix, i));
        }
    }
}
