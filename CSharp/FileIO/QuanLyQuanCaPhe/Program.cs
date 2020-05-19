using QuanLyQuanCaPhe.Models;
using QuanLyQuanCaPhe.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLyQuanCaPhe
{
    class Program
    {
        static BillingService orders;
        static void Main(string[] args)
        {
            orders = new BillingService(@"D:\codegym\github\codegym\CSharp\FileIO\QuanLyQuanCaPhe\Json\", "customers.json", "Menu.json", "JsonBills");
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
            string option = "";
            do
            {
                Console.Write("COFFEE SHOP MANAGEMENT\n" +
                                 "Menu:\n" +
                                 "1. Hiển thị các bàn có khách\n" +
                                 "2. Order mới/Thanh toán\n" +
                                 "3. Thoát\n" +
                                 "___________________________\n" +
                                 "Lựa chọn của bạn: ");
                option = Console.ReadLine();
                Process(option);
            } while (option != "3");
        }
        static void Process(string option)
        {
            switch (option)
            {
                case "1":
                    Console.Clear();
                    Console.WriteLine("Thông tin các bàn:");
                    for(int i = 0; i < orders.customers.customers.Count; i++)
                        ShowCustomerDetails(i);
                    break;
                case "2":
                    Console.Write("Nhập số bàn: ");
                    string table = Console.ReadLine();
                    ProcessTable(table);
                    break;
            }
        }
        static void ProcessTable(string table)
        {
            int tablePos = FindUsingTable(table);
            if (tablePos == -1)
                CreateNewCustomer(table);
            else
            {
                string option;
                do
                {
                    Console.Write($"Bàn {table}\n" +
                        $"1. Order đồ uống\n" +
                        "2. Hiển thị chi tiết\n" +
                        "3. Thanh toán\n" +
                        "4. Thoát\n" +
                        "_____________________\n" +
                        "Lựa chọn của bạn: ");
                    option = Console.ReadLine();
                    switch (option)
                    {
                        case "1":
                            Console.Clear();
                            Console.WriteLine($"Bàn {table}:");
                            AddDrinkToCurrentCustomer(tablePos);
                            break;
                        case "2":
                            Console.Clear();
                            ShowCustomerDetails(tablePos);
                            break;
                        case "3":
                            Console.Clear();
                            CheckOut(tablePos);
                            option = "4";
                            break;
                    }
                } while (option != "4");
            }
        }
        static void CheckOut(int tablePosition)
        {
            ShowCustomerDetails(tablePosition);
            var customer = orders.customers.customers[tablePosition];
            var checkoutDrinks = new List<CheckOutDrink>();
            foreach(var item in customer.orderDetails)
                foreach(var drink in orders.menu.drinks)
                    if (item.drinkId == drink.id)
                        checkoutDrinks.Add(new CheckOutDrink()
                            {
                                drinkName = drink.name,
                                price = drink.price,
                                amount = (int)item.amount
                            });
            var newCheckOut = new CheckOutCustomer()
            {
                table = customer.table,
                timeIn = customer.timeIn,
                timeOut = DateTime.Now.ToString("dd/MM/yyyy hh:mm tt"),
                orderDetails = checkoutDrinks,
                Total = TotalCheckOut(tablePosition)
            };
            orders.WriteJsonBill(newCheckOut);
            Console.WriteLine("Đã tạo bill!");
            orders.customers.customers.RemoveAt(tablePosition);
            orders.WriteJson();
        }
        static int TotalCheckOut(int tablePosition)
        {
            int total = 0;
            foreach(var order in orders.customers.customers[tablePosition].orderDetails)
            {
                foreach(var item in orders.menu.drinks)
                {
                    if (order.drinkId == item.id)
                        total += (int)order.amount * item.price;
                }
            }
            return total;
        }
        static void ShowCustomerDetails(int tablePosition)
        {
            string orderDetails = "Thức uống (số lượng): ";
            var customer = orders.customers.customers[tablePosition];
            foreach (var item in customer.orderDetails)
            {
                orderDetails += $"{item.drinkId}({item.amount})\t";
            }
            string result = $"Bàn: {customer.table}\tGiờ vào: {customer.timeIn}\t{orderDetails}\tTổng cộng: {TotalCheckOut(tablePosition)}";
            Console.WriteLine(result);
        }
        static void AddDrinkToCurrentCustomer(int tablePosition)
        {
            var customer = orders.customers.customers[tablePosition];
            Console.WriteLine("Thêm order: ");
            AddDrinkToTable(out string drinkId, out uint drinkAmount);
            int drinkPos = -1;
            for (int i = 0; i < customer.orderDetails.Count; i++)
                if (drinkId == customer.orderDetails[i].drinkId)
                    drinkPos = i;
            if (drinkPos == -1)
                customer.orderDetails.Add(new orderDrink()
                {
                    drinkId = drinkId,
                    amount = drinkAmount
                });
            else
                customer.orderDetails[drinkPos].amount += drinkAmount;

            orders.WriteJson();
        }
        static void AddDrinkToTable(out string drinkId, out uint drinkAmount)
        {
            bool drinkIsNotValid = false;
            do
            {
                if (drinkIsNotValid)
                {
                    Console.WriteLine("Bạn đã nhập sai ID thức uống, hãy nhập lại!");
                }
                drinkIsNotValid = true;
                Console.Write("Nhập ID thức uống: ");
                drinkId = Console.ReadLine();
                foreach (var item in orders.menu.drinks)
                    if (drinkId == item.id)
                    {
                        drinkIsNotValid = false;
                        break;
                    }
                Console.Write("Nhập số lượng thức uống: ");
                uint.TryParse(Console.ReadLine(), out drinkAmount);
            } while (drinkIsNotValid);
        }
        static void CreateNewCustomer(string table)
        {
            Console.WriteLine($"TẠO BÀN MỚI: {table}");
            var drinksOrder = new List<orderDrink>();
            string option;
            do
            {
                Console.Write("1. Order đồ uống\n" +
                    "2. Thoát\n" +
                    "_______________________\n" +
                    "Lựa chọn của bạn: ");
                option = Console.ReadLine();

                if (option == "1")
                {
                    AddDrinkToTable(out string drinkId, out uint drinkAmount);

                    int inndexOfDrink = -1;
                    for (int i = 0; i < drinksOrder.Count; i++)
                        if (drinkId == drinksOrder[i].drinkId)
                            inndexOfDrink = i;

                    if (inndexOfDrink == -1)
                        drinksOrder.Add(new orderDrink()
                        {
                            drinkId = drinkId,
                            amount = drinkAmount
                        });
                    else
                        drinksOrder[inndexOfDrink].amount += drinkAmount;
                }
            }
            while (option != "2");
            var customer = new Customer
            {
                table = table,
                timeIn = DateTime.Now.ToString("dd/MM/yyyy hh:mm tt"),

                orderDetails = drinksOrder
            };
            orders.customers.customers.Add(customer);
            orders.WriteJson();
        }
        static int FindUsingTable(string table)
        {
            for (int i = 0; i < orders.customers.customers.Count; i++)
                if (table == orders.customers.customers[i].table)
                    return i;
            return -1;
        }
    }
}
