using System.Collections.Generic;

namespace QuanLyQuanCaPhe.Models
{
    internal class Bill
    {
        public string table;
        public string timeIn;
        public string timeOut;
        public List<DrinkInBill> orderDetails;
        public CashierInBill cashier;
        public int Total;
    }
}