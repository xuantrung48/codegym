using Newtonsoft.Json;
using QuanLyQuanCaPhe.Models;
using QuanLyQuanCaPhe.Models.Staff;
using System;
using System.IO;

namespace QuanLyQuanCaPhe.Services
{
    internal class JsonService
    {
        private string path;
        private string customersJsonFile;
        private string menuJsonFile;
        private string billJsonFolder;
        private string cashierJsonName;
        private string tablesJsonFile;
        private string staffsJsonFile;
        private string StaffSalaryFolder;
        public Cashier currentCashier { get; set; }
        public Customers customers { get; private set; }
        public Menu menu { get; private set; }
        public Cashiers cashiers { get; private set; }
        public Tables tables { get; set; }
        public Staffs staffs { get; set; }

        public JsonService(string pathToFolder, string customersJsonFileName, string menuJsonFileName, string billJsonFolderName, string cashierJsonFileName, string tablesJsonFileName, string staffsJsonFileName, string StaffSalaryFolderName)
        {
            path = pathToFolder;
            customersJsonFile = customersJsonFileName;
            menuJsonFile = menuJsonFileName;
            billJsonFolder = billJsonFolderName;
            cashierJsonName = cashierJsonFileName;
            tablesJsonFile = tablesJsonFileName;
            staffsJsonFile = staffsJsonFileName;
            StaffSalaryFolder = StaffSalaryFolderName;
        }

        public void WriteJsonSalary(StaffSalary staffSalary)
        {
            using StreamWriter sw = File.CreateText($"{path + StaffSalaryFolder}\\{staffSalary.name}_{staffSalary.payTime}.json");
            sw.Write(JsonConvert.SerializeObject(staffSalary));
        }

        public void ReadJsonStaffs()
        {
            using StreamReader sr = File.OpenText(path + staffsJsonFile);
            staffs = JsonConvert.DeserializeObject<Staffs>(sr.ReadToEnd());
            sr.Close();
        }

        public void WriteJsonStaffs()
        {
            using StreamWriter sw = File.CreateText(path + staffsJsonFile);
            sw.Write(JsonConvert.SerializeObject(staffs));
        }

        public void ReadJsonCashier()
        {
            using StreamReader sr = File.OpenText(path + cashierJsonName);
            cashiers = JsonConvert.DeserializeObject<Cashiers>(sr.ReadToEnd());
            foreach (var item in cashiers.cashiers)
                if (item.workingTimes.Count != 0)
                    if (item.workingTimes[^1].endTime == null)
                        currentCashier = item;
            sr.Close();
        }

        public void WriteJsonCashier()
        {
            using StreamWriter sw = File.CreateText(path + cashierJsonName);
            sw.Write(JsonConvert.SerializeObject(cashiers));
        }

        public void WriteJsonTables()
        {
            using StreamWriter sw = File.CreateText(path + tablesJsonFile);
            sw.Write(JsonConvert.SerializeObject(tables));
        }

        public void ReadJsonTables()
        {
            using StreamReader sr = File.OpenText(path + tablesJsonFile);
            tables = JsonConvert.DeserializeObject<Tables>(sr.ReadToEnd());
            sr.Close();
        }

        public void ReadJsonCustomers()
        {
            using StreamReader sr = File.OpenText(path + customersJsonFile);
            customers = JsonConvert.DeserializeObject<Customers>(sr.ReadToEnd());
            sr.Close();
        }

        public void ReadJsonMenu()
        {
            StreamReader mn = File.OpenText(path + menuJsonFile);
            menu = JsonConvert.DeserializeObject<Menu>(mn.ReadToEnd());
            mn.Close();
        }

        public void WriteJsonCustomers()
        {
            using StreamWriter sw = File.CreateText(path + customersJsonFile);
            sw.Write(JsonConvert.SerializeObject(customers));
        }

        public void WriteJsonBill(Bill customer)
        {
            using StreamWriter sw = File.CreateText($"{path}{billJsonFolder}\\Bill_{DateTime.Now.ToString("dd_MM_yyyy_hh_mm")}.json");
            sw.Write(JsonConvert.SerializeObject(customer));
        }

        public void WriteJsonMenu()
        {
            using StreamWriter sw = File.CreateText(path + menuJsonFile);
            sw.Write(JsonConvert.SerializeObject(menu));
        }
    }
}