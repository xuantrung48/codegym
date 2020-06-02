using System;
using System.Collections.Generic;
using System.Text;

namespace Cau3
{
    class Account : IAccount
    {
        static int accountCounter = 0;
        public int accountId;
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string gender { get; set; }
        public float balance { get; private set; }
        public Account(string firstName, string lastName, string gender, float balance)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.gender = gender;
            this.balance = balance;
            this.accountId = ++accountCounter;
        }
        public void PayInto(float amount)
        {
            balance += amount;
        }

        public string ShowInfo()
        {
            return $"ID: {accountId}\nFirst name: {firstName}\tLast Name: {lastName}\nGender: {gender}\nBalance: {balance}.";
        }
    }
}
