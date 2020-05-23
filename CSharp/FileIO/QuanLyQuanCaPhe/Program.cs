using Newtonsoft.Json;
using QuanLyQuanCaPhe.Models;
using QuanLyQuanCaPhe.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLyQuanCaPhe
{
    class Program
    {
        static JsonService json = new JsonService(@"D:\codegym\github\codegym\CSharp\FileIO\QuanLyQuanCaPhe\Json\", "customers.json", "Menu.json", "JsonBills", "Cashiers.json", "Tables.json");

        static void Main(string[] args)
        {
            json.ReadJsonMenu();
            json.ReadJsonCashier();
            json.ReadJsonTables();
            json.ReadJsonCustomers();
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
            string option;
            do
            {
                Console.Write("COFFEE SHOP MANAGEMENT\n" +
                                 "1. Hiển thị các bàn có khách\n" +
                                 "2. Hiển thị bàn trống\n" +
                                 "3. Order đồ uống/Thanh toán\n" +
                                 "4. Chỉnh sửa thực đơn\n" +
                                 "5. Quản lý bàn\n" +
                                 "6. Cập nhật thu ngân vào nhận ca\n" +
                                 "7. Kết thúc ngày làm việc\n" +
                                 "8. Thoát\n" +
                                 "___________________________\n" +
                                 "Lựa chọn của bạn: ");
                option = Console.ReadLine();
                Process(option);
            } while (option != "8");
        }
        static void Process(string option)
        {
            switch (option)
            {
                case "1":
                    Console.Clear();
                    Console.WriteLine("Thông tin các bàn:");
                    for(int i = 0; i < json.customers.customers.Count; i++)
                        ShowCustomerDetails(i);
                    break;
                case "2":
                    Console.Clear();
                    string emptyTables = "Bàn trống: ";
                    foreach (var item in json.tables.tables)
                        if (item.available == true)
                            emptyTables += $"{item.id}\t";
                    Console.WriteLine(emptyTables);
                    break;
                case "3":
                    if (json.currentCashier == null)
                        Console.WriteLine("Hãy cập nhật thông tin thu ngân trước khi xử lý");
                    else
                    {
                        Console.Write("Nhập số bàn: ");
                        ProcessTable(Console.ReadLine());
                    }
                    break;
                case "4":
                    EditMenu();
                    break;
                case "5":
                    ManageTables();
                    break;
                case "6":
                    UpdateCashier();
                    break;
                case "7":
                    End();
                    break;
            }
        }
        static void ManageTables()
        {
            string option;
            do
            {
                Console.Write("Quản lý bàn:\n" +
                    "1. Thêm bàn\n" +
                    "2. Sửa ID bàn\n" +
                    "3. Xóa bàn\n" +
                    "4. Thoát\n" +
                    "_____________________\n" +
                    "Lựa chọn của bạn: ");
                option = Console.ReadLine();
                string tableID = "";
                if (option == "1" || option == "2" || option == "3")
                {
                    Console.Write("Nhập vào ID bàn: ");
                    tableID = Console.ReadLine();
                }
                switch (option)
                {
                    case "1":
                        if (IndexOfTable(tableID) == -1)
                            CreateNewTable(tableID);
                        else
                            Console.WriteLine($"Bàn {tableID} đã có trên hệ thống.");
                        break;
                    case "2":
                        if (IndexOfTable(tableID) != -1)
                            EditTableID(tableID);
                        else
                            Console.WriteLine($"Bàn {tableID} không có trên hệ thống.");
                        break;
                    case "3":
                        if (IndexOfTable(tableID) != -1)
                            RemoveTable(tableID);
                        else
                            Console.WriteLine($"Bàn {tableID} không có trên hệ thống.");
                        break;
                }
            } while (option != "4");

        }
        static void EditTableID(string tableID)
        {
            int indexOfNewTable = -1;
            string newTableID = "";
            do
            {
                indexOfNewTable = IndexOfTable(newTableID);
                if (indexOfNewTable != -1)
                    Console.WriteLine($"Đã có bàn {newTableID}!");
                Console.Write("Nhập vào ID mới: ");
                newTableID = Console.ReadLine();
            } while (indexOfNewTable != -1);
            json.tables.tables[IndexOfTable(tableID)].id = newTableID;
            json.WriteJsonTables();
            Console.WriteLine($"Đã đổi bàn thành {newTableID}!");
        }
        static void RemoveTable(string tableID)
        {
            json.tables.tables.RemoveAt(IndexOfTable(tableID));
            json.WriteJsonTables();
            Console.WriteLine($"Đã xóa bàn {tableID}!");
        }
        static void End()
        {
            if (json.customers.customers.Count != 0)
                Console.WriteLine("Vẫn còn bàn chưa thanh toán. Bạn không thể kết thúc ngày.");
            else
            {
                Console.Write("Bạn có chắc kết thúc ngày làm việc không?\n" +
                    "1. Có\n" +
                    "2. Không\n" +
                    "____________\n" +
                    "Lựa chọn của bạn: ");
                if (Console.ReadLine() == "1")
                {
                    string endTime = DateTime.Now.ToString("dd/MM/yyyy hh:mm tt");
                    if (json.currentCashier != null)
                    {
                        string cashierID = json.currentCashier.id;
                        json.cashiers.cashiers[IndexOfCashier(json.currentCashier.id)].workingTimes[json.currentCashier.workingTimes.Count - 1].endTime = endTime;
                        json.currentCashier = null;
                        json.WriteJsonCashier();
                    }
                }
            }
        }
        static int IndexOfTable(string tableID)
        {
            for (int i = 0; i < json.tables.tables.Count; i++)
                if (tableID == json.tables.tables[i].id)
                    return i;
            return -1;
        }
        static int IndexOfCashier(string cashierID)
        {
            for (int i = 0; i < json.cashiers.cashiers.Count; i++)
                if (cashierID == json.cashiers.cashiers[i].id)
                    return i;
            return -1;
        }
        static void AddNewCashier(string cashierID)
        {
            Console.Write("Nhập vào tên nhân viên: ");
            string cashierName = Console.ReadLine();
            json.cashiers.cashiers.Add(new Cashier()
            {
                id = cashierID,
                name = cashierName,
                workingTimes = new List<WorkingTime>()
            });
            json.WriteJsonCashier();
        }
        static void UpdateCashier()
        {
            int index = 0;
            string cashierID = "";
            do
            {
                if (index == -1)
                {
                    Console.Write("ID đã nhập không tồn tại! Bạn muốn tạo tài khoản thu ngân mới không?\n" +
                        "1. Có\n" +
                        "2. Không\n" +
                        "_______________\n" +
                        "Lựa chọn của bạn: ");
                    if (Console.ReadLine() == "1")
                        AddNewCashier(cashierID);
                }
                if (json.currentCashier != null)
                    if (cashierID == json.currentCashier.id)
                        Console.WriteLine("ID đã nhập trùng với ID nhân viên đang làm việc!");
                Console.Write("Nhập vào ID nhân viên nhận ca: ");
                cashierID = Console.ReadLine();
                index = IndexOfCashier(cashierID);
            } while (index == -1 || (json.currentCashier != null && cashierID == json.currentCashier.id));
            string shiftTime = DateTime.Now.ToString("dd/MM/yyyy hh:mm tt");
            if (json.currentCashier != null)
                json.cashiers.cashiers[IndexOfCashier(json.currentCashier.id)].workingTimes[json.currentCashier.workingTimes.Count - 1].endTime = shiftTime;
            json.cashiers.cashiers[IndexOfCashier(cashierID)].workingTimes.Add(new WorkingTime()
            {
                startTime = shiftTime
            });
            json.currentCashier = json.cashiers.cashiers[IndexOfCashier(cashierID)];
            json.WriteJsonCashier();
        }
        static void ShowMenu()
        {
            string menu = "";
            foreach (var item in json.menu.drinks)
                menu += $"ID: {item.id}\tTên: {item.name}\tGiá: {item.price}VND\n";
            Console.Write($"Thực đơn:\n{menu}\n");
        }
        static void EditMenu()
        {
            string option;
            do
            {
                ShowMenu();
                Console.Write($"1. Thêm món\n" +
                    $"2. Bỏ món\n" +
                    $"3. Cập nhật giá\n" +
                    $"4. Thoát\n" +
                    $"__________________\n" +
                    $"Lựa chọn của bạn: ");
                option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        AddDrinkToMenu();
                        break;
                    case "2":
                        RemoveDrinkFromMenu();
                        break;
                    case "3":
                        UpdateDrinkPrice();
                        break;
                }
            } while (option != "4");
        }
        static void UpdateDrinkPrice()
        {
            Console.Write("Nhập ID thức uống: ");
            string drinkId = Console.ReadLine();
            int indexOfDrinkId = IndexOfDrink(drinkId);
            if (indexOfDrinkId == -1)
                Console.WriteLine("Đồ uống không tồn tại!");
            else
            {
                Console.Write("Nhập vào giá mới: ");
                int.TryParse(Console.ReadLine(), out int newPrice);
                json.menu.drinks[indexOfDrinkId].price = newPrice;
                json.WriteJsonMenu();
                Console.WriteLine("Đã cập nhật giá thức uống!");
            }
        }
        static int IndexOfDrink(string drinkID)
        {
            for (int i = 0; i < json.menu.drinks.Count; i++)
                if (drinkID == json.menu.drinks[i].id)
                    return i;
            return -1;
        }
        static void RemoveDrinkFromMenu()
        {
            Console.Write("Nhập ID thức uống: ");
            string drinkId = Console.ReadLine();
            int indexOfDrinkId = IndexOfDrink(drinkId);
            if (indexOfDrinkId == -1)
                Console.WriteLine("Đồ uống không tồn tại!");
            else
            {
                json.menu.drinks.RemoveAt(indexOfDrinkId);
                json.WriteJsonMenu();
                Console.WriteLine("Đã bỏ thức uống!");
            }
        }
        static void AddDrinkToMenu()
        {
            int indexOfDrinkId = -1;
            string drinkId;
            do
            {
                if (indexOfDrinkId != -1)
                    Console.WriteLine("ID đã tồn tại, hãy nhập ID khác!");
                Console.Write("Nhập ID thức uống: ");
                drinkId = Console.ReadLine();
                indexOfDrinkId = IndexOfDrink(drinkId);
            } while (indexOfDrinkId != -1);
            Console.Write("Nhập tên thức uống: ");
            string drinkName = Console.ReadLine();
            Console.Write("Nhập giá thức uống: ");
            int.TryParse(Console.ReadLine(), out int drinkPrice);
            json.menu.drinks.Add(new Drink()
            {
                id = drinkId,
                name = drinkName,
                price = drinkPrice
            });
            json.WriteJsonMenu();
        }
        static bool CreateNewTable(string tableId)
        {
            Console.Write($"Bàn {tableId} không có trong hệ thống. Bạn có muốn tạo mới?\n" +
                $"1. Có\n" +
                $"2. Không\n" +
                $"___________________\n" +
                $"Lựa chọn của bạn: ");
            if (Console.ReadLine() == "1")
            {
                json.tables.tables.Add(new Table()
                {
                    id = tableId,
                    available = true
                });
                json.WriteJsonTables();
                Console.WriteLine($"Đã thêm bàn {tableId}");
                return true;
            }
            return false;
        }
        static void ProcessTable(string tableId)
        {
            if (IndexOfTable(tableId) == -1)
                if (CreateNewTable(tableId))
                    CreateNewCustomer(tableId);
            int tablePos = FindUsingTable(tableId);
            int indexOfTable = IndexOfTable(tableId);
            if (indexOfTable != -1)
            {
                if (json.tables.tables[indexOfTable].available == true)
                    CreateNewCustomer(tableId);
                else
                {
                    string option;
                    do
                    {
                        Console.Write($"Bàn {tableId}\n" +
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
                                Console.WriteLine($"Bàn {tableId}:");
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
        }
        static void CheckOut(int tablePosition)
        {
            ShowCustomerDetails(tablePosition);
            var customer = json.customers.customers[tablePosition];
            var checkoutDrinks = new List<CheckOutDrink>();
            foreach(var item in customer.orderDetails)
                foreach(var drink in json.menu.drinks)
                    if (item.drinkId == drink.id)
                        checkoutDrinks.Add(new CheckOutDrink()
                            {
                                drinkName = drink.name,
                                price = drink.price,
                                amount = (int)item.amount
                            });
            var newCheckOut = new Bill()
            {
                table = customer.table,
                timeIn = customer.timeIn,
                timeOut = DateTime.Now.ToString("dd/MM/yyyy hh:mm tt"),
                orderDetails = checkoutDrinks,
                cashier = new CashierInBill()
                {
                    name = json.currentCashier.name
                },
                Total = TotalCheckOut(tablePosition)
            };
            json.WriteJsonBill(newCheckOut);
            Console.WriteLine("Đã tạo bill!");
            json.customers.customers.RemoveAt(tablePosition);
            json.tables.tables[IndexOfTable(customer.table)].available = true;
            json.WriteJsonTables();
            json.WriteJsonCustomers();
        }
        static int TotalCheckOut(int tablePosition)
        {
            int total = 0;
            foreach(var order in json.customers.customers[tablePosition].orderDetails)
                foreach(var item in json.menu.drinks)
                    if (order.drinkId == item.id)
                        total += (int)order.amount * item.price;
            return total;
        }
        static void ShowCustomerDetails(int tablePosition)
        {
            string orderDetails = "Thức uống (số lượng): ";
            var customer = json.customers.customers[tablePosition];
            foreach (var item in customer.orderDetails)
                orderDetails += $"{item.drinkId}({item.amount})\t";
            string result = $"Bàn: {customer.table}\tGiờ vào: {customer.timeIn}\t{orderDetails}\tTổng cộng: {TotalCheckOut(tablePosition)}";
            Console.WriteLine(result);
        }
        static void AddDrinkToCurrentCustomer(int tablePosition)
        {
            var customer = json.customers.customers[tablePosition];
            Console.WriteLine("Thêm order: ");
            AddDrinkToTable(out string drinkId, out uint drinkAmount);
            int drinkPos = -1;
            for (int i = 0; i < customer.orderDetails.Count; i++)
                if (drinkId == customer.orderDetails[i].drinkId)
                    drinkPos = i;
            if (drinkPos == -1)
                customer.orderDetails.Add(new OrderDrink()
                {
                    drinkId = drinkId,
                    amount = drinkAmount
                });
            else
                customer.orderDetails[drinkPos].amount += drinkAmount;

            json.WriteJsonCustomers();
        }
        static void AddDrinkToTable(out string drinkId, out uint drinkAmount)
        {
            ShowMenu();
            bool drinkIsNotValid = false;
            do
            {
                if (drinkIsNotValid)
                    Console.WriteLine("Bạn đã nhập sai ID thức uống, hãy nhập lại!");
                drinkIsNotValid = true;
                Console.Write("Nhập ID thức uống: ");
                drinkId = Console.ReadLine();
                foreach (var item in json.menu.drinks)
                    if (drinkId == item.id)
                    {
                        drinkIsNotValid = false;
                        break;
                    }
                Console.Write("Nhập số lượng thức uống: ");
                uint.TryParse(Console.ReadLine(), out drinkAmount);
            } while (drinkIsNotValid);
        }
        static void CreateNewCustomer(string tableId)
        {
            Console.WriteLine($"TẠO BÀN MỚI: {tableId}");
            var drinksOrder = new List<OrderDrink>();
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
                        drinksOrder.Add(new OrderDrink()
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
                table = tableId,
                timeIn = DateTime.Now.ToString("dd/MM/yyyy hh:mm tt"),
                orderDetails = drinksOrder
            };
            json.tables.tables[IndexOfTable(tableId)].available = false;
            json.WriteJsonTables();
            json.customers.customers.Add(customer);
            json.WriteJsonCustomers();
        }
        static int FindUsingTable(string tableId)
        {
            for (int i = 0; i < json.customers.customers.Count; i++)
                if (tableId == json.customers.customers[i].table)
                    return i;
            return -1;
        }
    }
}
