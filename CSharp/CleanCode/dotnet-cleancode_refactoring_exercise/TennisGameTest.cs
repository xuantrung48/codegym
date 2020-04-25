using System;

namespace cleancode_refactoring_exercise
{
    class TennisGameTest
    {
        static void Main(string[] args)
        {
            string result = TennisGame.GetScore("Isner", "Nadal", 21, 20);
            Console.WriteLine(result);
        }
    }
}
