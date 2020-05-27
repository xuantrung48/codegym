using BaiTap3.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaiTap3
{
    class OrderInUser
    {
        public string id;
        public string orderTime;
        public List<ItemOrder> items = new List<ItemOrder>();
        public int total;
        public override string ToString()
        {
            string itemOrders = "";
            foreach (var item in items)
                itemOrders += item;
            return $"OrderID: {id}\tThời gian: {orderTime}\nSản phẩm:\n{itemOrders}Tổng cộng: {total} VND\n";
        }
    }
}
