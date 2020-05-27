using System;
using System.Collections.Generic;
using System.Text;

namespace BaiTap3.Models
{
    class Database
    {
        public List<User> users = new List<User>();
        public int userIdCounter;
        public List<Product> products = new List<Product>();
        public List<Customer> customers = new List<Customer>();
        public int customerIdCounter;
        public List<Order> orders = new List<Order>();
        public int orderIdCounter;
    }
}
