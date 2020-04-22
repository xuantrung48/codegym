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
            if (NumberSystem == "10")
                return NumberValue;
            else
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
                return result.ToString();
            }
        }
        public string ConvertTo(int heCoSo)
        {
            if (NumberSystem == heCoSo.ToString())
                return NumberValue;
            else
            {
                int num = Convert.ToInt32(ConvertToDecimal());
                var result = "";
                do
                {
                    result += (num % heCoSo == 10) ? "A" :
                              (num % heCoSo == 11) ? "B" :
                              (num % heCoSo == 12) ? "C" :
                              (num % heCoSo == 13) ? "D" :
                              (num % heCoSo == 14) ? "E" :
                              (num % heCoSo == 15) ? "F" : (num % heCoSo).ToString();
                    num /= heCoSo;
                } while (num != 0);
                char[] resultChar = result.ToCharArray();
                Array.Reverse(resultChar);
                result = new string(resultChar);
                return result;
            }
        }
        public bool ValidateNumber()
        {
            string BinaNumbers = "01";
            string OctaNumbers = "01234567";
            string DeciNumbers = "0123456789";
            string HexaNumbers = "0123456789abcdef";
            string checkNums = (NumberSystem == "2") ? BinaNumbers : 
                               (NumberSystem == "8") ? OctaNumbers :
                               (NumberSystem == "10") ? DeciNumbers : HexaNumbers;
            for (int i = 0; i < NumberValue.Length; i++)
            {
                if (!checkNums.Contains(NumberValue[i]))
                    return false;
            }
            return true;
        }
    }
}