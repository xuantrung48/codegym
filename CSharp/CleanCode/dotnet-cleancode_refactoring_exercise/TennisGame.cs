using System;

namespace cleancode_refactoring_exercise
{
    public class TennisGame
    {
        public static String GetScore(String player1Name, String player2Name, int player1Score, int player2Score)
        {
            string score;
            if (player1Score >= 4 || player2Score >= 4)
            {
                int minusResult = player1Score - player2Score;
                score = (minusResult ==  0) ? "Deuce" :
                        (minusResult ==  1) ? $"Advantage {player1Name}" :
                        (minusResult == -1) ? $"Advantage {player2Name}" :
                        (minusResult >=  2) ? $"Win for {player1Name}" : $"Win for {player2Name}";
            }

            else if (player1Score == player2Score)
                score = $"{GetScoreName(player1Score)} - All";

            else
                score = $"{GetScoreName(player1Score)} - {GetScoreName(player2Score)}";
            return score;
        }
        public static string GetScoreName(int score)
        {
            return (score == 0) ? "Love" : 
                   (score == 1) ? "Fifteen" : 
                   (score == 2) ? "Thirty" : "Forty";
        }
    }
}
