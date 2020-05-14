using System;
using System.IO;
namespace BaiTap
{
    class Program
    {
        static string fileInput = "inputData.txt";
        static string fileOutput = "outputData.txt";
        static string path = @"D:\codegym\github\codegym\CSharp\FileIO\BaiTap\Files\";
        static int[,] matrix;
        static void Main(string[] args)
        {
            
            using (StreamReader sr = (File.OpenText(path + fileInput)))
            {
                string rowColLine = sr.ReadLine();
                string[] rowColValue = rowColLine.Split(" ");
                matrix = new int[int.Parse(rowColValue[0]), int.Parse(rowColValue[1])];

                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    string rowMatrix = sr.ReadLine();
                    string[] rowMatrixValue = rowMatrix.Split(" ");
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        matrix[i, j] = int.Parse(rowMatrixValue[j]);
                    }
                }
            }

            using(StreamWriter sw = (File.CreateText(path + fileOutput)))
            {
                sw.WriteLine($"Tong gia tri trong ma tran: {GetTotalMatrix()}");
                sw.WriteLine($"So luong nguyen to trong ma tran: {NumberOfPrimeNumbers()}");
                sw.WriteLine($"So luong so le trong ma tran: {NumberOfOddNumbers()}");
                sw.WriteLine($"Tong duong bien trong ma tran: {TotalOfBorders()}");
                sw.WriteLine($"Ma tran sau khi cac gia tri x 3: ");
                int[,] newMatrix = MultiWithThree();
                for (int i = 0; i < newMatrix.GetLength(0); i++)
                {
                    for (int j = 0; j < newMatrix.GetLength(1); j++)
                    {
                        sw.Write(newMatrix[i, j] + " ");
                    }
                    sw.WriteLine();
                }
            }
        }
        static int TotalOfBorders()
        {
            int result = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (i == 0 || i == (matrix.GetLength(0) - 1))
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        result += matrix[i, j];
                    }
                }
                else
                {
                    result += matrix[i, 0] + matrix[i, matrix.GetLength(1) - 1];
                }
            }
            return result;
        }
        static int NumberOfOddNumbers()
        {
            int result = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1); j++)
                    if (matrix[i, j] % 2 != 0)
                        result++;
            return result;
        }
        static int NumberOfPrimeNumbers()
        {
            int result = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1); j++)
                    if (IsPrime(matrix[i, j]))
                        result++;
            return result;
        }
        static bool IsPrime(int number)
        {
            if (number < 2)
                return false;
            for (int i = 2; i < Math.Sqrt(number); i++)
                if (number % i == 0)
                    return false;
            return true;
        }
        static int[,] MultiWithThree()
        {
            int[,] tempMatrix = new int[matrix.GetLength(0), matrix.GetLength(1)];
            for (int i = 0; i < tempMatrix.GetLength(0); i++)
                for (int j = 0; j < tempMatrix.GetLength(1); j++)
                    tempMatrix[i, j] = 3 * matrix[i, j];
            return tempMatrix;
        }
        static int GetTotalMatrix()
        {
            int total = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    total += matrix[i, j];
                }
            }
            return total;
        }
    }
}
