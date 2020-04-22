using System;

namespace BaiTapOOP3
{
    class Number
    {
        public string NumberValue { get; }
        public string NumberSystem { get; }
        public Number(string numberValue, string numberSystem)
        {
            NumberValue = numberValue;
            NumberSystem = numberSystem;
        }
        public double ConvertToDecimal()
        {
            double result = 0;
            for (int i = 0; i < NumberValue.Length; i++)
            {
                string valueAtIndex = NumberValue[i].ToString().ToLower();
                valueAtIndex = (valueAtIndex == "a") ? "10" :
                               (valueAtIndex == "b") ? "11" :
                               (valueAtIndex == "c") ? "12" :
                               (valueAtIndex == "d") ? "13" :
                               (valueAtIndex == "e") ? "14" :
                               (valueAtIndex == "f") ? "15" : valueAtIndex;
                result += Convert.ToDouble(valueAtIndex) * Math.Pow(Convert.ToDouble(NumberSystem), NumberValue.Length - 1 - i);
            }
            return result;
        }
        public bool ValidateNumber()
        {
            string BinNumbers = "01";
            string OctaNumbers = "01234567";
            string HexaNumbers = "0123456789abcdef";
            string checkNums = (NumberSystem == "2") ? BinNumbers : 
                               (NumberSystem == "8") ? OctaNumbers : HexaNumbers;
            for (int i = 0; i < NumberValue.Length; i++)
            {
                if (!checkNums.Contains(NumberValue[i]))
                    return false;
            }
            return true;
        }
    }
}