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
            switch (HeCoSo)
            {
                case "2":
                case "8":
                    for (int i = 0; i < GiaTri.Length; i++)
                    {
                        double valueAtIndex = Char.GetNumericValue(GiaTri[i]);
                        result += valueAtIndex * Math.Pow(Convert.ToDouble(HeCoSo), GiaTri.Length - 1 - i);
                    }
                    break;
                case "16":
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
                        result += Convert.ToDouble(valueAtIndex) * Math.Pow(16, GiaTri.Length - 1 - i);
                    }
                    break;
            }
            return result.ToString();
        }
        public bool CheckValidNumber()
        {
            bool numberIsValid = false;
            switch (HeCoSo)
            {
                case "2":
                    for (int i = 0; i < GiaTri.Length; i++)
                    {
                        if (GiaTri[i] == '0' || GiaTri[i] == '1')
                            numberIsValid = true;
                        else
                        {
                            numberIsValid = false;
                            break;
                        }
                    }
                    break;
                case "8":
                    for (int i = 0; i < GiaTri.Length; i++)
                    {
                        if (GiaTri[i] == '0' || GiaTri[i] == '1' || GiaTri[i] == '2' || GiaTri[i] == '3' || GiaTri[i] == '4' || GiaTri[i] == '5' || GiaTri[i] == '6' || GiaTri[i] == '7')
                            numberIsValid = true;
                        else
                        {
                            numberIsValid = false;
                            break;
                        }
                    }
                    break;
                case "16":
                    for (int i = 0; i < GiaTri.Length; i++)
                    {
                        if (GiaTri[i] == '0' || GiaTri[i] == '1' || GiaTri[i] == '2' || GiaTri[i] == '3' || GiaTri[i] == '4' || GiaTri[i] == '5' || GiaTri[i] == '6' || GiaTri[i] == '7' || GiaTri[i] == '8' || GiaTri[i] == '9' || GiaTri[i] == 'a' || GiaTri[i] == 'b' || GiaTri[i] == 'c' || GiaTri[i] == 'd' || GiaTri[i] == 'e' || GiaTri[i] == 'f')
                            numberIsValid = true;
                        else
                        {
                            numberIsValid = false;
                            break;
                        }
                    }
                    break;
            }
            return numberIsValid;
        }
    }
}
