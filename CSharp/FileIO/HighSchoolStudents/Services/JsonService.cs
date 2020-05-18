using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using HighSchoolStudents.Models;
using HighSchoolStudents.Utilities;

namespace HighSchoolStudents
{
    class JsonService
    {
        public string path;
        public string inputFile;
        public string outputFile;
        public DanhSachHocSinh json;
        public JsonService(string pathToFolder, string inputFileName, string outputFileName)
        {
            path = pathToFolder;
            inputFile = inputFileName;
            outputFile = outputFileName;
            ReadJson();
            WriteJson();
        }
        public void ReadJson()
        {
            using StreamReader sr = File.OpenText(path + inputFile);
            var stringData = sr.ReadToEnd();
            json = JsonConvert.DeserializeObject<DanhSachHocSinh>(stringData);
        }
        public void WriteJson()
        {
            using StreamWriter sw = File.CreateText(path + outputFile);
            List<DuLieuHocSinhDauRa> danhSachHocSinhTheoThuHang = new List<DuLieuHocSinhDauRa>();
            foreach (var item in json.danhSachHocSinh)
            {
                var hocSinh = new DuLieuHocSinhDauRa();
                hocSinh.MaHS = item.MaHS;
                hocSinh.HoTen = item.HoTen;
                hocSinh.Lop = item.Lop;
                hocSinh.GioiTinh = item.GioiTinh;
                hocSinh.DiemTrungBinh = item.DiemTrungBinh;
                hocSinh.HocLuc = item.HocLuc;
                danhSachHocSinhTheoThuHang.Add(hocSinh);
            }
            danhSachHocSinhTheoThuHang.Sort(new CustomSort());
            var data = JsonConvert.SerializeObject(danhSachHocSinhTheoThuHang);
            sw.WriteLine(data);
        }
    }
}
