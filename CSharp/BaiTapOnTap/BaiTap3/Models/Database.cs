using System;
using System.Collections.Generic;
using System.Text;

namespace BaiTap3.Models
{
    class Database
    {
        public List<User> users;
        public int userIdCounter;
        public List<Product> products;
        public List<Customer> customers;
        public int customerIdCounter;
        public List<Order> orders;
        public int orderIdCounter;
    }
}
