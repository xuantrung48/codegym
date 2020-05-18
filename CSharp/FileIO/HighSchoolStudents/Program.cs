using HighSchoolStudents.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HighSchoolStudents
{
    class Program
    {
        public static JsonService jsonService;
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
            jsonService = new JsonService(@"D:\codegym\github\codegym\CSharp\FileIO\HighSchoolStudents\JSON\", "data.json", "Outcome.json");
            string option = "";
            do
            {
                Console.Write($"____________________________________\n"+
                    $"MENU:\n" +
                    $"1. Thêm học sinh\n" +
                    $"2. Tạo file JSON chứa danh sách học sinh đã xếp hạng\n" +
                    $"3. Hiển thị danh sách học sinh\n" +
                    $"4. Hiển thị danh sách học sinh theo xếp hạng điểm TB\n" +
                    $"5. Thoát\n" +
                    $"____________________________________\n" +
                    $"Lựa chọn của bạn: ");
                option = Console.ReadLine();
                Process(option);
            } while (option != "5");
        }
        static void Process(string option)
        {
            switch (option)
            {
                case "1":
                    Console.Clear();
                    AddStudent();
                    break;
                case "2":
                    Console.Clear();
                    jsonService.WriteJson();
                    Console.WriteLine("Đã tạo!");
                    break;
                case "3":
                    Console.Clear();
                    jsonService.ShowJsonInput();
                    break;
                case "4":
                    Console.Clear();
                    jsonService.ShowJsonOutput();
                    break;
            }
        }
        static void AddStudent()
        {
            Console.Write("Thêm học sinh\nHọ tên: ");
            string hoTen = Console.ReadLine();

            bool gioiTinh = true;
            string gioiTinhString;
            bool gioiTinhIsNotValid = false;
            do
            {
                if (gioiTinhIsNotValid)
                    Console.WriteLine("Bạn đã nhập không đúng giới tính. Xin nhập lại!");
                gioiTinhIsNotValid = true;
                Console.Write("Giới tính (nam/nữ): ");
                gioiTinhString = Console.ReadLine();
                if (gioiTinhString == "nam" || gioiTinhString == "Nam")
                {
                    gioiTinh = true;
                    gioiTinhIsNotValid = false;
                }
                if (gioiTinhString == "Nữ" || gioiTinhString == "nữ" || gioiTinhString == "Nu" || gioiTinhString == "nu")
                {
                    gioiTinh = false;
                    gioiTinhIsNotValid = false;
                }
            } while (gioiTinhIsNotValid);
            Console.Write("Lớp: ");
            string lop = Console.ReadLine();
            Console.Write("Điểm toán: ");
            double toan = 0;
            if (double.TryParse(Console.ReadLine(), out double t))
            {
                toan = t;
            }
            Console.Write("Điểm lý: ");
            double ly = 0;
            if (double.TryParse(Console.ReadLine(), out double l))
            {
                ly = l;
            }
            Console.Write("Điểm hóa: ");
            double hoa = 0;
            if (double.TryParse(Console.ReadLine(), out double h))
            {
                hoa = h;
            }

            List<MonHoc> cacMonHoc = new List<MonHoc>()
            {
                new MonHoc()
                {
                    TenMonHoc = "Toán",
                    DiemThi = toan
                },
                new MonHoc()
                {
                    TenMonHoc = "Lý",
                    DiemThi = ly
                },
                new MonHoc()
                {
                    TenMonHoc = "Hóa",
                    DiemThi = hoa
                }
            };
            HocSinh hocSinh = new HocSinh(hoTen, gioiTinh, lop, cacMonHoc);
            jsonService.json.danhSachHocSinh.Add(hocSinh);
            jsonService.JsonXepHangHocSinh.DanhSachXepHangHocSinh.Add(new KetQuaDuLieuHocSinh()
            {
                MaHS = hocSinh.MaHS,
                HoTen = hocSinh.HoTen,
                Lop = hocSinh.Lop,
                GioiTinh = hocSinh.GioiTinh ? "nam" : "nữ",
                DiemTrungBinh = hocSinh.DiemTrungBinh,
                HocLuc = hocSinh.HocLuc
            });
        }
    }
}
