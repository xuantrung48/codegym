﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BaiTap3.Models
{
    class Order
    {
        public string id;
        public OrderStatus orderStatus;
        public User customer;
        public List<ItemOrder> items;
        public int total;
        public override string ToString()
        {
            string listItem = "";
            foreach(var item in items)
                listItem += $"Tên SP: {item.name}\tGiá: {item.price}\tSố lượng: {item.quantity}\tThành tiền: {item.itemAmount}\n";
            return $"Order ID: {id}\nTrạng thái đơn hàng: {orderStatus}\nThông tin khách hàng:\n{customer.ToString()}\nSản phẩm đặt mua:\n{listItem}Tổng cộng: {total}\n______________________";
        }
    }
}
