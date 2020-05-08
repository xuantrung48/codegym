using System;

namespace Bai1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] a = CreateMatrix(5,3);
            Console.WriteLine("Matrix: ");
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    Console.Write(a[i, j] + " ");
                }
                Console.WriteLine();
            }

            ShowMaxRow(a);
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
        static void ShowMaxRow(int[,] matrix)
        {
            Console.Write("Max row: ");
            int[] maxArr = GetRow(matrix, 0);
            int maxRow = 0;
            for (int i = 1; i < matrix.GetLength(0); i++)
            {
                if (Sum(maxArr) < Sum(GetRow(matrix, i)))
                {
                    maxArr = GetRow(matrix, i);
                    maxRow = i;
                }
            }
            for (int i = 0; i < maxArr.Length; i++)
            {
                Console.Write(maxArr[i] + " ");
            }
            Console.WriteLine($"(Row: {maxRow + 1})");
        }
    }
}
