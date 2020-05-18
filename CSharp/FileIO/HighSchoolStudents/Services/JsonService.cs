using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using HighSchoolStudents.Models;
using HighSchoolStudents.Utilities;
using System;

namespace HighSchoolStudents
{
    class JsonService
    {
        public string path;
        public string inputFile;
        public string outputFile;
        public DanhSachHocSinh json;
        public XepHangHocSinh JsonXepHangHocSinh = new XepHangHocSinh()
        {
            DanhSachXepHangHocSinh = new List<KetQuaDuLieuHocSinh>()
        };

        public JsonService(string pathToFolder, string inputFileName, string outputFileName)
        {
            path = pathToFolder;
            inputFile = inputFileName;
            outputFile = outputFileName;
            ReadJson();
        }
        public void ReadJson()
        {
            using StreamReader sr = File.OpenText(path + inputFile);
            var stringData = sr.ReadToEnd();
            json = JsonConvert.DeserializeObject<DanhSachHocSinh>(stringData);

            foreach (var item in json.danhSachHocSinh)
            {
                var hocSinh = new KetQuaDuLieuHocSinh()
                {
                    MaHS = item.MaHS,
                    HoTen = item.HoTen,
                    GioiTinh = item.GioiTinh ? "nam" : "nữ",
                    Lop = item.Lop,
                    DiemTrungBinh = item.DiemTrungBinh,
                    HocLuc = item.HocLuc
                };
                JsonXepHangHocSinh.DanhSachXepHangHocSinh.Add(hocSinh);
            }
            JsonXepHangHocSinh.DanhSachXepHangHocSinh.Sort(new CustomSort());
        }
        public void WriteJson()
        {
            using StreamWriter sw = File.CreateText(path + outputFile);
            var data = JsonConvert.SerializeObject(JsonXepHangHocSinh);
            sw.WriteLine(data);
        }
        public void ShowJsonInput()
        {
            Console.WriteLine("DANH SÁCH HỌC SINH:");
            foreach(var hocSinh in json.danhSachHocSinh)
            {
                string diemCacMon = "";
                foreach(var diemThi in hocSinh.CacMonHoc)
                    diemCacMon += $"{diemThi.TenMonHoc}: {diemThi.DiemThi} ";
                Console.WriteLine($"Mã HS: {hocSinh.MaHS}\tHọ tên: {hocSinh.HoTen}\tGiới tính: {(hocSinh.GioiTinh ? "nam" : "nữ")}\tLớp: {hocSinh.Lop}\tĐiểm các môn: {diemCacMon}");
            }
        }
        public void ShowJsonOutput()
        {
            Console.WriteLine("DANH SÁCH HỌC SINH:");
            foreach (var hocSinh in JsonXepHangHocSinh.DanhSachXepHangHocSinh)
            {
                Console.WriteLine($"Mã HS: {hocSinh.MaHS}\tHọ tên: {hocSinh.HoTen}\tGiới tính: {hocSinh.GioiTinh}\tLớp: {hocSinh.Lop}\tĐiểm TB: {hocSinh.DiemTrungBinh}\tHọc lực: {hocSinh.HocLuc}");
            }
        }
    }
}
