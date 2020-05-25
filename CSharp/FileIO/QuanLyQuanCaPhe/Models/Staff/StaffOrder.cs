using System.Collections.Generic;

namespace QuanLyQuanCaPhe.Models.Staff
{
    internal class StaffOrder
    {
        public string tableId;
        public string orderTime;
        public List<DrinkInBill> orderDetails;
    }
}