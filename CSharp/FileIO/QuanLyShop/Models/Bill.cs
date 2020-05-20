using System;
using System.Collections.Generic;
using System.Text;

namespace TMDT.Models
{
    class Bill
    {
        public string time;
        public List<CartProduct> items;
        public int total;
    }
}
