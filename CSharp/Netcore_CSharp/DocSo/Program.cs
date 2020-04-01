using System;

namespace DocSo
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("Enter a number: ");
                int number = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine(readNumber(number));
            }
        }
        static string readNumber(int n)
        {
            if (n >= 0 && n <= 1000)
            {
                switch (n)
                {
                    case 0:
                        return "zero";
                    case 10:
                        return "ten";
                    case 11:
                        return "eleven";
                    case 12:
                        return "twelve";
                    case 13:
                        return "thirteen";
                    case 14:
                        return "fourteen";
                    case 15:
                        return "fifteen";
                    case 16:
                        return "sixteen";
                    case 17:
                        return "seventeen";
                    case 18:
                        return "eightteen";
                    case 19:
                        return "nineteen";
                    case 100:
                        return "one hundred";
                    case 200:
                        return "two hundreds";
                    case 300:
                        return "three hundreds";
                    case 400:
                        return "four hundreds";
                    case 500:
                        return "five hundreds";
                    case 600:
                        return "six hundreds";
                    case 700:
                        return "seven hundreds";
                    case 800:
                        return "eight hundreds";
                    case 900:
                        return "nine hundreds";
                    case 1000:
                        return "one thousand";
                }
                string hundreds = "";
                string tens = "";
                string ones = "";
                switch (n / 100)
                {
                    case 0:
                        hundreds = "";
                        break;
                    case 1:
                        hundreds = "one hundreds and ";
                        break;
                    case 2:
                        hundreds = "two hundreds and ";
                        break;
                    case 3:
                        hundreds = "three hundreds and ";
                        break;
                    case 4:
                        hundreds = "four hundreds and ";
                        break;
                    case 5:
                        hundreds = "five hundreds and ";
                        break;
                    case 6:
                        hundreds = "six hundreds and ";
                        break;
                    case 7:
                        hundreds = "seven hundreds and ";
                        break;
                    case 8:
                        hundreds = "eight hundreds and ";
                        break;
                    case 9:
                        hundreds = "nine hundreds and ";
                        break;
                }
                switch ((n % 100) / 10)
                {
                    case 1:
                        tens = "";
                        break;
                    case 2:
                        tens = "twenty ";
                        break;
                    case 3:
                        tens = "thirty ";
                        break;
                    case 4:
                        tens = "forty ";
                        break;
                    case 5:
                        tens = "fifty ";
                        break;
                    case 6:
                        tens = "sixty ";
                        break;
                    case 7:
                        tens = "seventy ";
                        break;
                    case 8:
                        tens = "eighty ";
                        break;
                    case 9:
                        tens = "ninety ";
                        break;
                }
                switch ((n % 100) % 10)
                {
                    case 0:
                        ones = "";
                        break;
                    case 1:
                        ones = "one";
                        break;
                    case 2:
                        ones = "two";
                        break;
                    case 3:
                        ones = "three";
                        break;
                    case 4:
                        ones = "four";
                        break;
                    case 5:
                        ones = "five";
                        break;
                    case 6:
                        ones = "six";
                        break;
                    case 7:
                        ones = "seven";
                        break;
                    case 8:
                        ones = "eight";
                        break;
                    case 9:
                        ones = "nine";
                        break;
                }
                return hundreds + tens + ones;
            }
            else
                return "out of ability";
        }
    }
}
