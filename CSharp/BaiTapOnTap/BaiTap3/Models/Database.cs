using System;
using System.Collections.Generic;
using System.Text;

namespace BaiTap3.Models
{
    class Database
    {
        public Admin admin;
        public List<Product> products;
        public List<User> users;
        public int userIdCounter;
        public List<Order> orders;
        public int orderIdCounter;
    }
}
