using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLyQuanCaPhe.Models.Staff
{
    class StaffOrder
    {
        public string tableId;
        public string orderTime;
        public List<DrinkInBill> orderDetails;
    }
}
