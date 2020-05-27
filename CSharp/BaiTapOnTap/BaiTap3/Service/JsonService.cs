using BaiTap3.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json.Serialization;

namespace BaiTap3.Service
{
    class JsonService
    {
        private string path;
        private string databaseFile;
        private string billFolder;
        public Database database;
        public User currentUser;
        public JsonService(string pathToFolder, string databaseFileName, string billFolderName)
        {
            path = pathToFolder;
            databaseFile = databaseFileName;
            billFolder = billFolderName;
        }
        public void ReadDatabase()
        {
            using StreamReader sr = File.OpenText(path + databaseFile);
            var data = sr.ReadToEnd();
            database = JsonConvert.DeserializeObject<Database>(data);
        }
        public void WriteDatabase()
        {
            using StreamWriter sw = File.CreateText(path + databaseFile);
            var data = JsonConvert.SerializeObject(database);
            sw.Write(data);
        }
        public void WriteJsonBill(Order order)
        {
            using StreamWriter sw = File.CreateText(path + billFolder + $"\\{DateTime.Now:ddMMyyyy}_{order.id}");
            var data = JsonConvert.SerializeObject(order);
            sw.Write(data);
        }
    }
}
