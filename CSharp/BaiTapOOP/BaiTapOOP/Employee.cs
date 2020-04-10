using System;
using System.Collections.Generic;
using System.Text;

namespace BaiTapOOP
{
    class Employee
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime DoB { get; set; }
        public string Address { get; set; }

        public Employee(string name, string email, DateTime dob, string address)
        {
            this.Name = name;
            this.Email = email;
            this.DoB = dob;
            this.Address = address;
            Console.WriteLine("_______________________________");
        }
        public int GetAge()
        {
            int currentYear = DateTime.Now.Year;
            return DateTime.Now.Year - this.DoB.Year;
        }

        public void ShowInfo()
        {
            Console.WriteLine("Name: " + this.Name);
            Console.WriteLine("Email: " + this.Email);
            Console.WriteLine("Date of Birth: " + this.DoB);
            Console.WriteLine("Age: " + this.GetAge());
            Console.WriteLine("Address: " + this.Address);
        }
    }
}
