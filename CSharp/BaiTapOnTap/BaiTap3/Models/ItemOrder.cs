using System;
using System.Collections.Generic;
using System.Text;

namespace BaiTap3.Models
{
    class ItemOrder
    {
        public string id;
        public string name;
        public int price;
        public int quantity;
        public int itemAmount;
        public override string ToString()
        {
            return $"ID: {id}\tTên SP: {name}\tGiá: {price}\tSố lượng: {quantity}\tThành tiền: {itemAmount} VND\n";
        }
    }
}
