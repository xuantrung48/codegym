using QuanLyQuanCaPhe.Models.Staff;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLyQuanCaPhe.Models
{
    class StaffSalary
    {
        public string id;
        public string name;
        public string payTime;
        public int salary;
        public List<WorkingTime> workingTimes;
        public List<StaffOrder> orders;
    }
}
