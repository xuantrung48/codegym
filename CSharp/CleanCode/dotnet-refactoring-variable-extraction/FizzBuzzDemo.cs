using System;

namespace refactoring_variable_extraction
{
    class FizzBuzzDemo
    {
        public static String FizzBuzz(int number)
        {
            bool isFizz = number % 3 == 0;
            bool isBuzz = number % 5 == 0;
            if (isFizz && isBuzz)
                return "FizzBuzz";

            if (isFizz)
                return "Fizz";

            if (isBuzz)
                return "Buzz";

            return number + "";
        }
    }
}