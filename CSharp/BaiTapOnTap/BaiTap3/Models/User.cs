﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BaiTap3.Models
{
    class User
    {
        public string id;
        public string name;
        public string phoneNumber;
        public string address;
        public override string ToString()
        {
            return $"User ID: {id}\tTên: {name}\tSDT: {phoneNumber}\tĐịa chỉ: {address}";
        }
    }
}
