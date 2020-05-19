using System.Collections.Generic;

namespace QuanLyQuanCaPhe.Models
{
    class CheckOutCustomer
    {
        public string table;
        public string timeIn;
        public string timeOut;
        public List<CheckOutDrink> orderDetails;
        public int Total;
    }
}
