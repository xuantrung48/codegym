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
        public string ConvertToDecimal()
        {
            double result = 0;
            for (int i = 0; i < NumberValue.Length; i++)
            {
                string valueAtIndex = NumberValue[i].ToString().ToLower();
                switch (valueAtIndex)
                {
                    case "a":
                        valueAtIndex = "10";
                        break;
                    case "b":
                        valueAtIndex = "11";
                        break;
                    case "c":
                        valueAtIndex = "12";
                        break;
                    case "d":
                        valueAtIndex = "13";
                        break;
                    case "e":
                        valueAtIndex = "14";
                        break;
                    case "f":
                        valueAtIndex = "15";
                        break;
                }
                result += Convert.ToDouble(valueAtIndex) * Math.Pow(Convert.ToDouble(NumberSystem), NumberValue.Length - 1 - i);
            }
            return result.ToString();
        }
        public bool ValidateNumber()
        {
            bool numberIsValid = true;
            string BinNumbers = "01";
            string OctaNumbers = "01234567";
            string HexaNumbers = "0123456789abcdef";
            string checkNums = (NumberSystem == "2") ? BinNumbers : (NumberSystem == "8") ? OctaNumbers : HexaNumbers;
            for (int i = 0; i < NumberValue.Length; i++)
            {
                if (!checkNums.Contains(NumberValue[i]))
                {
                    numberIsValid = false;
                    break;
                }
            }
            return numberIsValid;
        }
    }
}
