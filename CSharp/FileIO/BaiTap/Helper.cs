using System;

namespace FileIO
{
    class Helper
    {
        public static bool IsPrime(int number)
        {
            if (number < 2)
                return false;
            for (int i = 2; i < Math.Sqrt(number); i++)
                if (number % i == 0)
                    return false;
            return true;
        }
        public static int NumberOfPrimeNumbers(int[,] matrix)
        {
            int result = 0;
            foreach (var number in matrix)
                if (IsPrime(number))
                    result++;
            return result;
        }
        public static int SumOfMatrix(int[,] matrix)
        {
            int sum = 0;
            foreach (var number in matrix)
                sum += number;
            return sum;
        }
        public static int NumberOfOddNumbers(int[,] matrix)
        {
            int result = 0;
            foreach (var number in matrix)
                if (number % 2 != 0)
                    result++;
            return result;
        }
        public static int SumOfBorders(int[,] matrix)
        {
            int result = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (i == 0 || i == matrix.GetLength(0) - 1)
                    for (int j = 0; j < matrix.GetLength(1); j++)
                        result += matrix[i, j];
                else
                    result += matrix[i, 0] + matrix[i, matrix.GetLength(1) - 1];
            }
            return result;
        }
        public static int[,] MultiWith(int[,] matrix, int number)
        {
            int[,] newMatrix = new int[matrix.GetLength(0), matrix.GetLength(1)];
            for (int i = 0; i < newMatrix.GetLength(0); i++)
                for (int j = 0; j < newMatrix.GetLength(1); j++)
                    newMatrix[i, j] = matrix[i, j] * number;
            return newMatrix;
        }
    }
}