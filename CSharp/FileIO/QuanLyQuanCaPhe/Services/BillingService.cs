using System;
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
            ReadJsonCustomers();
            ReadJsonMenu();
        }
        public void ReadJsonCustomers()
        {
            using StreamReader sr = File.OpenText(path + customersJsonFile);
            var data = sr.ReadToEnd();
            customers = JsonConvert.DeserializeObject<Customers>(data);
        }
        public void ReadJsonMenu()
        {
            StreamReader mn = File.OpenText(path + menuJsonFile);
            var dataMenu = mn.ReadToEnd();
            menu = JsonConvert.DeserializeObject<Menu>(dataMenu);
        }
        public void WriteJson()
        {
            using StreamWriter sw = File.CreateText(path + customersJsonFile);
            var data = JsonConvert.SerializeObject(customers);
            sw.Write(data);
        }
        public void WriteJsonBill(CheckOutCustomer customer)
        {
            using StreamWriter sw = File.CreateText($"{path}{billJsonFolder}\\Bill_{DateTime.Now.ToString("dd_MM_yyyy_hh_mm")}.json");
            var dataCustomer = JsonConvert.SerializeObject(customer);
            sw.Write(dataCustomer);
        }
    }
}
