using System;

namespace TinhDoPhucTapCuaThuatToan
{
    class AlgorithmComplexityTest
    {
        static void Main(string[] args)
        {
            
            Console.Write("Input your string: ");
            string stringInput = Console.ReadLine();

            int[] frequentChar = new int[255];

            for (int i = 0; i < stringInput.Length; i++)
                frequentChar[(int)stringInput[i]]++;

            int MostFrequentChar = frequentChar[0];
            char mostChar = (char)0;
            for (int i = 0; i < frequentChar.Length; i++)
            {
                if (MostFrequentChar < frequentChar[i])
                {
                    MostFrequentChar = frequentChar[i];
                    mostChar = (char)i;
                }
            }

            Console.WriteLine($"The most appearing letter is '{mostChar}' with a frequency of {MostFrequentChar} times.");
        }
    }
}
