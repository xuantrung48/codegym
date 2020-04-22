using System;

namespace BaiTapOOP3
{
    class So
    {
        public string GiaTri { get; set; }
        public string HeCoSo { get; set; }
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
        public bool CheckValidNumber()
        {
            bool numberIsValid = true;

            char[] BinNumber = { '0', '1' };
            char[] OctaNumber = { '0', '1', '2', '3', '4', '5', '6', '7' };
            char[] HexaNumber = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'a', 'b', 'c', 'd', 'e', 'f' };

            char[] checkNums = (HeCoSo == "2") ? BinNumber : (HeCoSo == "8") ? OctaNumber : HexaNumber;

            for (int i = 0; i < GiaTri.Length; i++)
            {
                if (!Array.Exists(checkNums, element => element == GiaTri[i]))
                {
                    numberIsValid = false;
                    break;
                }
            }
            return numberIsValid;
        }
    }
}
