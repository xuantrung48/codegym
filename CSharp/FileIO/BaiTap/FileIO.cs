using System;
using System.IO;

namespace FileIO
{
    class Matrix
    {
        public int[,] Numbers;
        public string path;
        public string inputFileName;
        public string outputFileName;
        public Matrix(string path, string inputFileName, string outputFileName)
        {
            this.path = path;
            this.inputFileName = inputFileName;
            this.outputFileName = outputFileName;
            ReadInputFile();
            WriteOutputFile();
        }
        public void ReadInputFile()
        {
            using StreamReader sr = (File.OpenText(path + inputFileName));
            string rowColLine = sr.ReadLine();
            string[] rowCol = rowColLine.Split(" ");
            Numbers = new int[int.Parse(rowCol[0]), int.Parse(rowCol[1])];

            for (int i = 0; i < Numbers.GetLength(0); i++)
            {
                string matrixLine = sr.ReadLine();
                string[] matrixRowValues = matrixLine.Split(" ");
                for (int j = 0; j < Numbers.GetLength(1); j++)
                {
                    Numbers[i, j] = int.Parse(matrixRowValues[j]);
                }
            }
        }
        public void WriteOutputFile()
        {
            using StreamWriter sr = (File.CreateText(path + outputFileName));
            sr.WriteLine($"Tổng giá trị trong ma trận: {Helper.SumOfMatrix(Numbers)}");
            sr.WriteLine($"Số lượng số nguyên tố trong ma trận: {Helper.NumberOfPrimeNumbers(Numbers)}");
            sr.WriteLine($"Số lượng số lẻ trong ma trận: {Helper.NumberOfOddNumbers(Numbers)}");
            sr.WriteLine($"Tổng giá trị các đường biên: {Helper.SumOfBorders(Numbers)}");
            sr.WriteLine($"Ma trận với các giá trị * 3: ");
            int[,] newMatrix = Helper.MultiWith(Numbers, 3);
            for (int i = 0; i < newMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < newMatrix.GetLength(1); j++)
                    sr.Write(newMatrix[i, j] + "\t");
                sr.WriteLine();
            }
        }
    }
}
