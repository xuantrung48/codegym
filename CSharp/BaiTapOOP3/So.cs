using System;

namespace BaiTapOOP3
{
    class So
    {
        public string GiaTri { get; }
        public string HeCoSo { get; }
        public So(string giaTri, string heCoSo)
        {
            GiaTri = giaTri;
            HeCoSo = heCoSo;
        }
        public string ChuyenVeHCS10()
        {
            double result = 0;
            for (int i = 0; i < GiaTri.Length; i++)
            {
                string valueAtIndex = GiaTri[i].ToString().ToLower();
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
                result += Convert.ToDouble(valueAtIndex) * Math.Pow(Convert.ToDouble(HeCoSo), GiaTri.Length - 1 - i);
            }
            return result.ToString();
        }
        public bool ValidateNumber()
        {
            bool numberIsValid = true;
            string BinNumbers = "01";
            string OctaNumbers = "01234567";
            string HexaNumbers = "0123456789abcdef";
            string checkNums = (HeCoSo == "2") ? BinNumbers : (HeCoSo == "8") ? OctaNumbers : HexaNumbers;
            for (int i = 0; i < GiaTri.Length; i++)
            {
                if (!checkNums.Contains(GiaTri[i]))
                {
                    numberIsValid = false;
                    break;
                }
            }
            return numberIsValid;
        }
    }
}
