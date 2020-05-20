using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using TMDT.Models;

namespace TMDT.Services
{
    class JsonService
    {
        public string path;
        public string productsJsonFile;
        public string outputBillsFolder;
        public Products products;
        public JsonService(string pathToFolder, string productsJsonFile, string outputBillsFolder)
        {
            path = pathToFolder;
            this.productsJsonFile = productsJsonFile;
            this.outputBillsFolder = outputBillsFolder;
            ReadJsonData();
        }
        public void ReadJsonData()
        {
            using StreamReader sr = File.OpenText(path + productsJsonFile);
            string data = sr.ReadToEnd();
            products = JsonConvert.DeserializeObject<Products>(data);
        }
        public void WriteJsonData(Products products)
        {
            using StreamWriter sw = File.CreateText(path + productsJsonFile);
            string data = JsonConvert.SerializeObject(products);
            sw.WriteLine(data);
        }
        public void WriteJsonBill(Bill bill)
        {
            using StreamWriter sw = File.CreateText($"{path + outputBillsFolder}\\Bill_{DateTime.Now:dd_MM_yyyy_hh_mm_tt}.json");
            string dataBill = JsonConvert.SerializeObject(bill);
            sw.WriteLine(dataBill);
        }
    }
}
