using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLyShop.Models
{
    class BillProduct
    {
        public string id { get; set; }
        public string name { get; set; }
        public int price { get; set; }
        public int quantity { get; set; }
        public int itemAmount { get; set; }
    }
}
