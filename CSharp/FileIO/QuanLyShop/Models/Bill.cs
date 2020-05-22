using QuanLyShop;
using QuanLyShop.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace TMDT.Models
{
    class Bill
    {
        public string time;
        public Customer customerDetails;
        public List<BillProduct> items;
        public int totalAmount;
    }
}
