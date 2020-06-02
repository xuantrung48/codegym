using System;
using System.Collections.Generic;
using System.Text;

namespace Cau3
{
    class Bank
    {
        static Dictionary<int, Account> AccountList= new Dictionary<int, Account>();
        public static void Main(string[] args)
        {
            string option;
            do
            {
                Console.Write("MENU\n" +
                    "1. Create Account\n" +
                    "2. Pay Into\n" +
                    "3. Show Customers data\n" +
                    "4. Exit\n" +
                    "___________________________\n" +
                    "Your option: ");
                option = Console.ReadLine();
                Process(option);
            } while (option != "4");
        }
        static void Process(string option)
        {
            switch (option)
            {
                case "1":
                    CreateNewAccount();
                    break;
                case "2":
                    PayInto();
                    break;
                case "3":
                    ShowData();
                    break;
            }
        }
        static void CreateNewAccount()
        {
            Console.Write("First Name: ");
            string firstName = Console.ReadLine();
            Console.Write("Last Name: ");
            string lastName = Console.ReadLine();
            Console.Write("Gender: ");
            string gender = Console.ReadLine();
            Console.Write("Balance: ");
            float.TryParse(Console.ReadLine(), out float balance);

            Account newAccount = new Account(firstName, lastName, gender, balance);
            AccountList.Add(newAccount.accountId, newAccount);
        }
        static void PayInto()
        {
            Console.Write("Pay to Account ID: ");
            int.TryParse(Console.ReadLine(), out int id);
            Console.Write("Amount: ");
            float.TryParse(Console.ReadLine(), out float amount);
            bool isAccountNotExist = true;
            foreach(var key in AccountList.Keys)
            {
                if (id == key)
                {
                    AccountList[key].PayInto(amount);
                    isAccountNotExist = false;
                }
            }
            if (isAccountNotExist)
                Console.WriteLine("Tài khoản không tồn tại!");
        }
        static void ShowData()
        {
            Console.WriteLine("Account List: ");
            foreach(var accountData in AccountList.Values)
            {
                Console.WriteLine(accountData.ShowInfo());
            }
        }
    }
}
