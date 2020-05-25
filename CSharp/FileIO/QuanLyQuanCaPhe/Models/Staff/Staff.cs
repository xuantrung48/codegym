using System.Collections.Generic;

namespace QuanLyQuanCaPhe.Models.Staff
{
    internal class Staff
    {
        public string id;
        public string name;
        public double coefficientsSalary;
        public List<WorkingTime> workingTimes;
        public List<StaffOrder> orders;
    }
}