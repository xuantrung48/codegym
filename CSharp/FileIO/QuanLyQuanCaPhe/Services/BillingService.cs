using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using QuanLyQuanCaPhe.Models;
using Newtonsoft.Json;

namespace QuanLyQuanCaPhe.Services
{
    class BillingService
    {
        public string path;
        public string customersJsonFile;
        public string menuJsonFile;
        public string billJsonFolder;
        public Customers customers;
        public Menu menu;
        public BillingService(string pathToFolder, string customersJsonFileName, string menuJsonFileName, string billJsonFolder)
        {
            path = pathToFolder;
            customersJsonFile = customersJsonFileName;
            menuJsonFile = menuJsonFileName;
            this.billJsonFolder = billJsonFolder;
            ReadJson();
        }
        public void ReadJson()
        {
            using StreamReader sr = File.OpenText(path + customersJsonFile);
            var data = sr.ReadToEnd();
            customers = JsonConvert.DeserializeObject<Customers>(data);
            StreamReader mn = File.OpenText(path + menuJsonFile);
            var dataMenu = mn.ReadToEnd();
            menu = JsonConvert.DeserializeObject<Menu>(dataMenu);
        }
        public void WriteJsonBill(CheckOutCustomer customer)
        {
            using StreamWriter sw = File.CreateText(billJsonFolder + $"Bill_{DateTime.Now.ToString("dd_MM_yyyy_hh_mm")}.json");
            var dataCustomer = JsonConvert.SerializeObject(customer);
            sw.Write(dataCustomer);
        }
    }
}
