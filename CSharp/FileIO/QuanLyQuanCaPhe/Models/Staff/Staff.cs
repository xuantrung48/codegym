using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLyQuanCaPhe.Models.Staff
{
    class Staff
    {
        public string id;
        public string name;
        public double coefficientsSalary;
        public List<WorkingTime> workingTimes;
        public List<StaffOrder> orders;
    }
}
