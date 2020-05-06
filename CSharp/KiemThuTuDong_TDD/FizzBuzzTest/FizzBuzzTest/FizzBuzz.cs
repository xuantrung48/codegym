using System;
using System.Collections.Generic;
using System.Text;

namespace FizzBuzzTestDemo
{
    class FizzBuzzTranslate
    {
        private int number;
        public int Number
        {
            get
            {
                return number;
            }
            set
            {
                if (value > 0)
                    number = value;
            }
        }
        public string GetResult()
        {
            if (Number % 3 == 0 && Number % 5 == 0)
                return "FizzBuzz";
            if (Number % 3 == 0)
                return "Fizz";
            if (Number % 5 == 0)
                return "Buzz";
            return Number.ToString();
        }
    }
}
