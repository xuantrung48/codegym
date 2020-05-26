using System;
using System.Text;

namespace BaiTap2
{
    class Program
    {
        static int[][] matrix;
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
            do
            {
                Console.Write("1. Tạo ma trận\n" +
                    "2. Nhân ma trận\n" +
                    "3. Hiển thị ma trận\n" +
                    "4. Thoát\n" +
                    "______________________\n" +
                    "Lựa chọn của bạn: ");
                Process(Console.ReadLine());
            } while (true);
        }
        static void Process (string option)
        {
            switch (option)
            {
                case "1":
                    Console.Write("Hàng: ");
                    int.TryParse(Console.ReadLine(), out int n);
                    Console.WriteLine("Cột: ");
                    int.TryParse(Console.ReadLine(), out int m);
                    matrix = CreateMatrix(n, m);
                    ShowMatrix(matrix);
                    break;
                case "2":
                    Console.WriteLine("Ma trận A: ");
                    var A = CreateMatrix(4, 3);
                    ShowMatrix(A);
                    Console.WriteLine("Ma trận B: ");
                    var B = CreateMatrix(3, 4);
                    ShowMatrix(B);
                    Console.WriteLine("Tích của 2 ma trận: ");
                    ShowMatrix(MultipleMatrix(A, B));
                    break;
                case "3":
                    ShowMatrix(matrix);
                    break;
                case "4":
                    Environment.Exit(0);
                    break;
            }
        }
        static int[][] MultipleMatrix(int[][] A, int[][] B)
        {
            int[][] resultMatrix = new int[A.Length][];
            for (int i = 0; i < resultMatrix.Length; i++)
            {
                resultMatrix[i] = new int[B[0].Length];
                for (int j = 0; j < resultMatrix[i].Length; j++)
                    resultMatrix[i][j] = MultiArray(A[i], GetCol(B, j));
            }
            return resultMatrix;
        }
        static int[] GetCol(int[][] matrix, int index)
        {
            int[] array = new int[matrix.Length];
            for (int i = 0; i < array.Length; i++)
                array[i] = matrix[i][index];
            return array;
        }
        static int MultiArray(int[] A, int[] B)
        {
            int result = 0;
            for (int i = 0; i < A.Length; i++)
                result += A[i] * B[i];
            return result;
        }
        static int[][] CreateMatrix(int n, int m)
        {
            int[][] matrix = new int[n][];
            for (int i = 0; i < n; i++)
                matrix[i] = CreateArray(m);
            return matrix;
        }
        static int[] CreateArray(int arraySize)
        {
            int[] numbersArray = new int[arraySize];
            Random rd = new Random();
            for (int i = 0; i < arraySize; i++)
                numbersArray[i] = rd.Next(10, 50);
            return numbersArray;
        }
        static void ShowMatrix(int[][] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
                ShowArray(matrix[i]);
        }
        static void ShowArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
                Console.Write(array[i] + "\t");
            Console.WriteLine();
        }
    }
}
