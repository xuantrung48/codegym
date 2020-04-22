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
            string[] BinNumber = { "0", "1" };
            string[] OctaNumber = { "0", "1", "2", "3", "4", "5", "6", "7" };
            string[] HexaNumber = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "a", "b", "c", "d", "e", "f" };
            for (int i = 0; i < GiaTri.Length; i++)
            {
                string[] checkNums = { };
                switch (HeCoSo)
                {
                    case "2":
                        checkNums = BinNumber;
                        break;
                    case "8":
                        checkNums = OctaNumber;
                        break;
                    case "16":
                        checkNums = HexaNumber;
                        break;
                }
                if (!Array.Exists(checkNums, element => element == GiaTri[i].ToString()))
                {
                    numberIsValid = false;
                    break;
                }
            }
            return numberIsValid;
        }
    }
}
