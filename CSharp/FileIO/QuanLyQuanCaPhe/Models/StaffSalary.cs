using QuanLyQuanCaPhe.Models.Staff;
using System.Collections.Generic;

namespace QuanLyQuanCaPhe.Models
{
    internal class StaffSalary
    {
        public string id;
        public string name;
        public string payTime;
        public int salary;
        public List<WorkingTime> workingTimes;
        public List<StaffOrder> orders;
    }
}