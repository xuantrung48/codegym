using System;
using System.Collections.Generic;
using System.Text;

namespace BaiTap3.Models
{
    class Salary
    {
        public string id;
        public string name;
        public List<WorkingTime> workingTimes;
        public List<OrderInUser> orders;
        public double coefficientsSalary;
        public int totalSalary;
        public override string ToString()
        {
            string working = "Thời gian làm việc chi tiết của nhân viên: \n";
            foreach (var wokingTime in workingTimes)
                working += $"Vào làm: {wokingTime.startTime}\tKết thúc: {wokingTime.endTime}\tTổng: {Math.Round(wokingTime.workingTime, 2)} tiếng.\n";
            string orderList = "Danh sách đơn hàng của nhân viên: \n";
            foreach (var order in orders)
                orderList += order;
            return $"ID: {id}\tTên: {name}\n{working}{orderList}\nLương: {Program.SalaryOfUser(id)} VND";
        }
    }
}
