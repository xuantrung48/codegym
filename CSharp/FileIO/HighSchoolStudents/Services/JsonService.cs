using System.Collections.Generic;
using System.IO;
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
            XepHangHocSinh danhSachXepHangHocSinh = new XepHangHocSinh()
            {
                DanhSachXepHangHocSinh = new List<KetQuaDuLieuHocSinh>()
            };

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
                danhSachXepHangHocSinh.DanhSachXepHangHocSinh.Add(hocSinh);
            }
            danhSachXepHangHocSinh.DanhSachXepHangHocSinh.Sort(new CustomSort());
            var data = JsonConvert.SerializeObject(danhSachXepHangHocSinh);
            sw.WriteLine(data);
        }
    }
}
