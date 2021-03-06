﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BaiTap3.Models
{
    class User
    {
        public string id;
        public string name;
        public string email;
        public string passWord;
        public List<WorkingTime> workingTimes = new List<WorkingTime>();
        public List<OrderInUser> orders = new List<OrderInUser>();
        public double coefficientsSalary;
        public Role role;
        public override string ToString()
        {
            string working = "Thời gian làm việc chi tiết của nhân viên: \n";
            foreach (var wokingTime in workingTimes)
                working += $"Vào làm: {wokingTime.startTime}\tKết thúc: {wokingTime.endTime}\tTổng: {Math.Round(wokingTime.workingTime, 2)} tiếng.\n";
            string orderList = "Danh sách đơn hàng của nhân viên: \n";
            foreach (var order in orders)
                orderList += order;
            return $"ID: {id}\tTên: {name}\tEmail: {email}.\n{working}{orderList}\nLương tạm tính: {Program.SalaryOfUser(id)} VND";
        }
    }
}
