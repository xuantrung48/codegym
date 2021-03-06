﻿using System;

namespace BaiTapOOP3
{
    class Number
    {
        public string NumberValue { get; }
        public string NumberSystem { get; }
        public Number(string numberValue, string numberSystem)
        {
            NumberValue = numberValue.ToUpper();
            NumberSystem = numberSystem;
        }
        public string ConvertToDecimal()
        {
            if (NumberSystem == "10")
                return NumberValue;
            else
            {
                double result = 0;
                for (int i = 0; i < NumberValue.Length; i++)
                {
                    string charInNumber = NumberValue[i].ToString();
                    charInNumber = (charInNumber == "A") ? "10" :
                                   (charInNumber == "B") ? "11" :
                                   (charInNumber == "C") ? "12" :
                                   (charInNumber == "D") ? "13" :
                                   (charInNumber == "E") ? "14" :
                                   (charInNumber == "F") ? "15" : charInNumber;
                    result += Convert.ToDouble(charInNumber) * Math.Pow(Convert.ToDouble(NumberSystem), NumberValue.Length - 1 - i);
                }
                return result.ToString();
            }
        }
        public string ConvertToNumberSystem(ulong numberSystem)
        {
            if (NumberSystem == numberSystem.ToString())
                return NumberValue;
            else
            {
                ulong num = 0;
                try
                {
                    num = ulong.Parse(ConvertToDecimal());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                var result = "";
                do
                {
                    result += (num % numberSystem == 10) ? "A" :
                              (num % numberSystem == 11) ? "B" :
                              (num % numberSystem == 12) ? "C" :
                              (num % numberSystem == 13) ? "D" :
                              (num % numberSystem == 14) ? "E" :
                              (num % numberSystem == 15) ? "F" : (num % numberSystem).ToString();
                    num /= numberSystem;
                } while (num != 0);
                char[] resultChar = result.ToCharArray();
                Array.Reverse(resultChar);
                result = new string(resultChar);
                return result;
            }
        }
        public bool Validate()
        {
            string validNums = (NumberSystem ==  "2") ? "01" : 
                               (NumberSystem ==  "8") ? "01234567" :
                               (NumberSystem == "10") ? "0123456789" : "0123456789ABCDEF";
            foreach (var charInNumber in NumberValue)
            {
                if (!validNums.Contains(charInNumber))
                    return false;
            }
            return true;
        }
    }
}