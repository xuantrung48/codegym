using System;
using System.Collections.Generic;
using System.Text;

namespace BaiTap3.Models
{
    class Product
    {
        public string id;
        public string name;
        public int price;
        public int remain;
        public override string ToString()
        {
            return $"ID: {id}\tTên SP: {name}\tGiá: {price}\tTồn kho: {remain}";
        }
    }
}
