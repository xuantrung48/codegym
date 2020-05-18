using System;
using System.Collections.Generic;
using System.Text;
using HighSchoolStudents;

namespace HighSchoolStudents.Models
{
    class HocSinh
    {
        private static int counter = 0;
        public int MaHS;
        public string HoTen;
        public bool GioiTinh;
        public string Lop;
        public string HocLuc;
        public List<MonHoc> CacMonHoc;
        public double DiemTrungBinh;
        public HocSinh(string hoTen, bool gioiTinh, string lop, List<MonHoc> cacMonHoc)
        {
            bool MaHSExists;
            do
            {
                MaHSExists = false;
                ++counter;
                if (Program.jsonService != null)
                    foreach(var item in Program.jsonService.json.danhSachHocSinh)
                        if (counter == item.MaHS)
                            MaHSExists = true;
            } while (MaHSExists);
            MaHS = counter;
            HoTen = hoTen;
            GioiTinh = gioiTinh;
            Lop = lop;
            CacMonHoc = cacMonHoc;
            TinhDiemTrungBinh();
            XepLoai();
        }
        public void TinhDiemTrungBinh()
        {
            double TongDiem = 0;
            foreach(var monHoc in CacMonHoc)
            {
                if (monHoc.TenMonHoc == "Toán")
                    TongDiem += monHoc.DiemThi * 2;
                else
                    TongDiem += monHoc.DiemThi;
            }
            DiemTrungBinh = Math.Round(TongDiem / 4, 2);
        }
        public void XepLoai()
        {
            if (DiemTrungBinh >= 9.0)
                HocLuc = "xuất sắc";
            else if (DiemTrungBinh >= 8.0)
                HocLuc = "giỏi";
            else if (DiemTrungBinh >= 7.0)
                HocLuc = "khá";
            else if (DiemTrungBinh >= 6.5)
                HocLuc = "trung bình khá";
            else if (DiemTrungBinh >= 5.0)
                HocLuc = "trung bình";
            else if (DiemTrungBinh >= 3.5)
                HocLuc = "yếu";
            else
                HocLuc = "kém";
        }
    }
}
