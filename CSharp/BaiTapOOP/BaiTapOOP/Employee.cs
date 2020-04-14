using System;
using System.Collections.Generic;
using System.Text;

namespace BaiTapOOP
{
    class Employee
    {
        private string name;
        private string email;
        private DateTime dob;
        private string address;
        public string Name
        {
            get => name;
            set => name = value;
        }
        public string Email
        {
            get => email;
            set => email = value;
        }
        public DateTime DoB
        {
            get => dob;
            set => dob = value;
        }
        public string Address
        {
            get => address;
            set => address = value;
        }

        public Employee(string name, string email, DateTime dob, string address)
        {
            this.Name = name;
            this.Email = email;
            this.DoB = dob;
            this.Address = address;
        }
        public int GetAge()
        {
            int currentYear = DateTime.Now.Year;
            return DateTime.Now.Year - this.DoB.Year;
        }

        public string ShowInfo()
        {
            return "Name: " + this.Name + " |Email: " + this.Email + " |Date of Birth: " + this.DoB.ToString("dd/MM/yyyy") + " |Age: " + this.GetAge() + " |Address: " + this.Address;
        }
    }
}
