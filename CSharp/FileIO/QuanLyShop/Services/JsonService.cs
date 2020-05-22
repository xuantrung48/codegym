using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using TMDT.Models;
using QuanLyShop.Models;

namespace TMDT.Services
{
    class JsonService
    {
        private string path;
        private string productsJsonFile;
        private string couponJsonFile;
        private string outputBillsFolder;
        public Products products { get; private set; }
        public Coupons coupons { get; private set; }
        public JsonService(string pathToFolder, string productsJsonFile, string couponJsonFile, string outputBillsFolder)
        {
            path = pathToFolder;
            this.productsJsonFile = productsJsonFile;
            this.couponJsonFile = couponJsonFile;
            this.outputBillsFolder = outputBillsFolder;
        }
        public void ReadJsonData()
        {
            using StreamReader sr = File.OpenText(path + productsJsonFile);
            string data = sr.ReadToEnd();
            products = JsonConvert.DeserializeObject<Products>(data);
            using StreamReader cp = File.OpenText(path + couponJsonFile);
            string cpData = cp.ReadToEnd();
            coupons = JsonConvert.DeserializeObject<Coupons>(cpData);
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
