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
                Console.Write($"MENU:\n" +
                    $"1. Thêm học sinh\n" +
                    $"2. Tạo file JSON chứa danh sách học sinh đã xếp hạng\n" +
                    $"3. Thoát\n" +
                    $"____________________________________\n" +
                    $"Lựa chọn của bạn: ");
                option = Console.ReadLine();
                Process(option);
            } while (option != "3");
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
                    jsonService.WriteJson();
                    Console.WriteLine("Đã tạo!");
                    Console.WriteLine("____________________________________");
                    break;
            }
        }
        static void AddStudent()
        {
            Console.Write("Thêm học sinh\nHọ tên: ");
            string hoTen = Console.ReadLine();

            bool gioiTinh = true;
            string gioiTinhString = "";
            do
            {
                Console.Write("Giới tính (nam/nữ): ");
                gioiTinhString = Console.ReadLine();
                if (gioiTinhString == "nam" || gioiTinhString == "Nam")
                    gioiTinh = true;
                if (gioiTinhString == "Nữ" || gioiTinhString == "nữ" || gioiTinhString == "Nu" || gioiTinhString == "nu")
                    gioiTinh = false;
            } while (gioiTinhString != "nam" && gioiTinhString != "Nam" && gioiTinhString != "Nữ" && gioiTinhString != "nữ" && gioiTinhString != "Nu" && gioiTinhString != "nu");
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
        }
    }
}
