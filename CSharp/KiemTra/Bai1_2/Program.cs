using System;

namespace Bai1_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] numbersArray = CreateMatrix(5, 3);
            Console.WriteLine("Matrix: ");
            ShowMatrix(numbersArray);
            Console.WriteLine("Max Row: ");
            ShowArray(ShowMaxRow(numbersArray, out int pos));
            Console.WriteLine($"Max row position: {pos + 1}");
        }
        static int[][] CreateMatrix(int n, int m)
        {
            Random rd = new Random();
            int[][] matrix = new int[n][];
            for (int i = 0; i < n; i++)
            {
                matrix[i] = new int[m];
                for (int j = 0; j < m; j++)
                {
                    matrix[i][j] = rd.Next(10, 50);
                }
            }
            return matrix;
        }
        static int Sum(int[] array)
        {
            int sum = 0;
            foreach (var number in array)
                sum += number;
            return sum;
        }
        static int[] ShowMaxRow(int[][] matrix, out int pos)
        {
            pos = 0;
            int sumMaxRow = Sum(matrix[0]);
            for (int i = 1; i < matrix.Length; i++)
            {
                if (sumMaxRow < Sum(matrix[i]))
                {
                    sumMaxRow = Sum(matrix[i]);
                    pos = i;
                }
            }
            return matrix[pos];
        }
        static void ShowArray(int[] array)
        {
            foreach (var item in array)
                Console.Write(item + " ");
            Console.WriteLine();
        }
        static void ShowMatrix(int[][] matrix)
        {
            foreach (var array in matrix)
                ShowArray(array);
        }
    }
}
