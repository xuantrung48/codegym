using Newtonsoft.Json;
using QuanLyQuanCaPhe.Models;
using QuanLyQuanCaPhe.Services;
using System;
using System.Collections.Generic;
using System.Text;
using QuanLyQuanCaPhe.Models.Staff;

namespace QuanLyQuanCaPhe
{
    class Program
    {
        static JsonService json = new JsonService(@"D:\codegym\github\codegym\CSharp\FileIO\QuanLyQuanCaPhe\Json\", "customers.json", "Menu.json", "JsonBills", "Cashiers.json", "Tables.json", "Staffs.json", "Salary");

        static void Main(string[] args)
        {
            json.ReadJsonMenu();
            json.ReadJsonCashier();
            json.ReadJsonTables();
            json.ReadJsonCustomers();
            json.ReadJsonStaffs();
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
                                 "7. Quản lý danh sách nhân viên\n" +
                                 "8. Kết thúc ngày làm việc\n" +
                                 "9. Thoát\n" +
                                 "___________________________\n" +
                                 "Lựa chọn của bạn: ");
                option = Console.ReadLine();
                Process(option);
            } while (option != "9");
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
                        if (item.available)
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
                    ManageStaffs();
                    break;
                case "8":
                    End();
                    break;
            }
        }
        static int IndexOfStaff(string staffId)
        {
            for (int i = 0; i < json.staffs.staffs.Count; i++)
                if (staffId == json.staffs.staffs[i].id)
                    return i;
            return -1;
        }
        static void StartEndWorkingTime(string staffId)
        {
            int indexOfStaff = IndexOfStaff(staffId);
            var staffWorkingTime = json.staffs.staffs[indexOfStaff].workingTimes;
            if (staffWorkingTime.Count != 0)
                if (staffWorkingTime[^1].endTime == null)
                {
                    Console.Write("Kết thúc ca? y/n: ");
                    if (Console.ReadLine() == "y")
                    {
                        staffWorkingTime[^1].endTime = DateTime.Now.ToString("dd/MM/yyyy hh:mm tt");
                        staffWorkingTime[^1].workingTime = (DateTime.Parse(staffWorkingTime[^1].endTime) - DateTime.Parse(staffWorkingTime[^1].startTime)).TotalMinutes / 60;
                        json.WriteJsonStaffs();
                    }
                }
                else
                {
                    Console.Write("Bắt đầu làm việc? y/n: ");
                    if (Console.ReadLine() == "y")
                    {
                        staffWorkingTime.Add(new WorkingTime()
                        {
                            startTime = DateTime.Now.ToString("dd/MM/yyyy hh:mm tt")
                        });
                        json.WriteJsonStaffs();
                    }
                }
            else
            {
                Console.Write("Bắt đầu làm việc? y/n: ");
                if (Console.ReadLine() == "y")
                {
                    staffWorkingTime.Add(new WorkingTime()
                    {
                        startTime = DateTime.Now.ToString("dd/MM/yyyy hh:mm tt")
                    });
                    json.WriteJsonStaffs();
                }
            }
        }
        static void ManageStaff()
        {
            int indexOfStaff = 0;
            string staffId = "";
            do
            {
                if (indexOfStaff == -1)
                {
                    Console.Write($"Không có nhân viên nào có mã {staffId}. Bạn có muốn thêm mới không? y/n: ");
                    if (Console.ReadLine() == "y")
                    {
                        AddStaff(staffId);
                        json.WriteJsonStaffs();
                    }
                }
                Console.Write("Nhập vào mã nhân viên: ");
                staffId = Console.ReadLine();
                indexOfStaff = IndexOfStaff(staffId);
            } while (indexOfStaff == -1);

            string option;
            do
            {
                Console.Write("1. Vào ca / Kết thúc ca\n" +
                    "2. Hiển thị chi tiết\n" +
                    "3. Tính lương\n" +
                    "4. Thoát\n" +
                    "____________________\n" +
                    "Lựa chọn của bạn: ");
                option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        StartEndWorkingTime(staffId);
                        break;
                    case "2":
                        ShowStaffDetail(staffId);
                        break;
                    case "3":
                        CalculateSalary(staffId);
                        break;
                }
            } while (option != "4");
        }
        static void ManageStaffs()
        {
            string option;
            do
            {
                Console.Write("QUẢN LÝ DANH SÁCH NHÂN VIÊN:\n" +
                    "1. Hiển thị danh sách nhân viên\n" +
                    "2. Quản lý nhân viên\n" +
                    "3. Thêm nhân viên mới\n" +
                    "4. Chỉnh sửa thông tin nhân viên\n" +
                    "5. Loại bỏ nhân viên\n" +
                    "6. Thoát\n" +
                    "___________________\n" +
                    "Lựa chọn của bạn: ");
                option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        ShowStaff();
                        break;
                    case "2":
                        ManageStaff();
                        break;
                    case "3":
                        string staffId = "";
                        int indexOfStaff = -1;
                        do
                        {
                            if (indexOfStaff != -1)
                                Console.WriteLine($"Mã nhân viên {staffId} đã tồn tại, hãy nhập mã khác!");
                            Console.Write("Nhập vào mã nhân viên: ");
                            staffId = Console.ReadLine();
                            indexOfStaff = IndexOfStaff(staffId);
                        } while (indexOfStaff != -1);
                        AddStaff(staffId);
                        break;
                    case "4":
                        EditStaff();
                        break;
                    case "5":
                        RemoveStaff();
                        break;
                }
            } while (option != "6");
        }
        static void EditStaff()
        {
            Console.Write("Nhập vào mã nhân viên: ");
            string staffId = Console.ReadLine();
            int indexOfStaff = IndexOfStaff(staffId);
            if (indexOfStaff == -1)
                Console.WriteLine($"Mã nhân viên {staffId} không tồn tại!");
            else
            {
                string option;
                do
                {
                    Console.Write($"Chỉnh sửa thông tin nhân viên {staffId}:\n" +
                        $"1. Sửa tên\n" +
                        $"2. Sửa hệ số lương\n" +
                        $"3. Thoát\n" +
                        $"_______________\n" +
                        $"Lựa chọn của bạn: ");
                    option = Console.ReadLine();
                    switch (option)
                    {
                        case "1":
                            Console.Write("Nhập tên mới: ");
                            json.staffs.staffs[indexOfStaff].name = Console.ReadLine();
                            break;
                        case "2":
                            Console.Write("Nhập hệ số lương mới: ");
                            double.TryParse(Console.ReadLine(), out json.staffs.staffs[indexOfStaff].coefficientsSalary);
                            break;
                    }
                } while (option != "3");
                json.WriteJsonStaffs();
                Console.WriteLine($"Đã chỉnh sửa thông tin nhân viên {staffId}!");
            }
        }
        static void RemoveStaff()
        {
            Console.Write("Nhập vào mã nhân viên: ");
            string staffId = Console.ReadLine();
            int indexOfStaff = IndexOfStaff(staffId);
            if (indexOfStaff == -1)
                Console.WriteLine($"Mã nhân viên {staffId} không tồn tại!");
            else
            {
                json.staffs.staffs.RemoveAt(indexOfStaff);
                json.WriteJsonStaffs();
                Console.WriteLine($"Đã loại bỏ nhân viên {staffId}!");
            }
        }
        static void AddStaff(string staffId)
        {
            Console.Write("Nhập vào tên nhân viên: ");
            string staffName = Console.ReadLine();
            Console.Write("Nhập vào hệ số lương: ");
            double.TryParse(Console.ReadLine(), out double staffCoefficientsSalary);
            json.staffs.staffs.Add(new Staff()
            {
                id = staffId,
                name = staffName,
                coefficientsSalary = staffCoefficientsSalary,
                orders = new List<StaffOrder>(),
                workingTimes = new List<WorkingTime>()
            });
            json.WriteJsonStaffs();
            Console.WriteLine("Đã tạo thành công nhân viên mới!");
        }
        static void ShowStaff()
        {
            Console.Clear();
            Console.WriteLine("Danh sách nhân viên: ");
            foreach (var staff in json.staffs.staffs)
                Console.WriteLine($"ID: {staff.id}, Tên: {staff.name}, Hệ số lương: {staff.coefficientsSalary}.");
        }
        static void CalculateSalary(string staffId)
        {
            int salary = SalaryOfStaff(staffId);
            Console.WriteLine($"Lương nhân viên: {salary}VND");
            Console.Write("Thanh toán lương cho nhân viên? y/n :");
            if (Console.ReadLine() == "y")
            {
                int indexOfStaff = IndexOfStaff(staffId);

                json.WriteJsonSalary(new StaffSalary()
                {
                    id = staffId,
                    name = json.staffs.staffs[indexOfStaff].name,
                    payTime = DateTime.Now.ToString("dd_MM_yyyy"),
                    salary =  salary,
                    orders = json.staffs.staffs[indexOfStaff].orders,
                    workingTimes = json.staffs.staffs[indexOfStaff].workingTimes
                });
                json.staffs.staffs[indexOfStaff].workingTimes.Clear();
                json.staffs.staffs[indexOfStaff].orders.Clear();
                json.WriteJsonStaffs();
            }
        }
        static int SalaryOfStaff(string staffId)
        {
            Console.Clear();
            double salary = 0;
            foreach (var staff in json.staffs.staffs)
                if (staffId == staff.id)
                    foreach (var workingTimes in staff.workingTimes)
                        salary += workingTimes.workingTime * staff.coefficientsSalary;
            return (int)salary * json.staffs.basicSalary;
        }
        static void ShowStaffDetail(string staffId)
        {
            Console.Clear();
            string result = "";
            foreach (var staff in json.staffs.staffs)
                if (staffId == staff.id)
                {
                    string working = "Working Times: \n";
                    foreach (var workingTimes in staff.workingTimes)
                        working += $"Start time: {workingTimes.startTime},\tEnd Time: {workingTimes.endTime}\tIn hours: {workingTimes.workingTime}.\n";
                    result += $"ID: {staff.id}, Name: {staff.name}\n{working}";
                }
            Console.WriteLine(result);
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
            bool staffIsWorking = false;
            foreach (var staff in json.staffs.staffs)
                if (staff.workingTimes.Count != 0)
                    if (staff.workingTimes[^1].endTime == null)
                        staffIsWorking = true;
            if (staffIsWorking)
                Console.WriteLine("Vẫn còn nhân viên chưa kết thúc ca làm việc. Bạn chưa thể kết thúc ngày.");
            else if (json.customers.customers.Count != 0)
                Console.WriteLine("Vẫn còn bàn chưa thanh toán. Bạn chưa thể kết thúc ngày.");
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
            Console.Write($"Bàn {tableId} không có trong hệ thống. Bạn có muốn tạo mới? y/n: ");
            if (Console.ReadLine() == "y")
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
            int tablePos = IndexOfUsingTable(tableId);
            int indexOfTable = IndexOfTable(tableId);
            if (indexOfTable != -1)
            {
                if (json.tables.tables[indexOfTable].available)
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
            var checkoutDrinks = new List<DrinkInBill>();
            foreach(var item in customer.orderDetails)
                foreach(var drink in json.menu.drinks)
                    if (item.drinkId == drink.id)
                        checkoutDrinks.Add(new DrinkInBill()
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
            AddDrinkToTable(out string drinkId, out int drinkAmount, out int indexOfStaff);
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

            AddOrderToStaff(drinkId, drinkAmount, indexOfStaff, tablePosition);
            json.WriteJsonCustomers();
        }
        static void AddOrderToStaff(string drinkId, int drinkAmount, int indexOfStaff, int tablePosition)
        {
            var customer = json.customers.customers[tablePosition];
            var orderItems = new List<DrinkInBill>();
            var indexOfItem = IndexOfDrink(drinkId);
            orderItems.Add(new DrinkInBill()
            {
                drinkName = json.menu.drinks[indexOfItem].name,
                price = json.menu.drinks[indexOfItem].price,
                amount = drinkAmount
            });
            json.staffs.staffs[indexOfStaff].orders.Add(new StaffOrder()
            {
                tableId = customer.table,
                orderTime = DateTime.Now.ToString("dd/MM/yyyy hh:mm tt"),
                orderDetails = orderItems
            });
            json.WriteJsonStaffs();
        }
        static void AddDrinkToTable(out string drinkId, out int drinkAmount, out int indexOfStaff)
        {
            string staffId = "";
            indexOfStaff = 0;
            do
            {
                if (indexOfStaff == -1)
                    Console.WriteLine($"Không có nhân viên {staffId}, Xin hãy nhập lại!");
                Console.Write("ID nhân viên order: ");
                staffId = Console.ReadLine();
                indexOfStaff = IndexOfStaff(staffId);
            } while (indexOfStaff == -1);

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
                int.TryParse(Console.ReadLine(), out drinkAmount);
            } while (drinkIsNotValid);
        }
        static void CreateNewCustomer(string tableId)
        {
            Console.WriteLine($"TẠO BÀN MỚI: {tableId}");
            var drinksOrder = new List<OrderDrink>();
            AddDrinkToTable(out string drinkId, out int drinkAmount, out int indexOfStaff);

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

            var customer = new Customer
            {
                table = tableId,
                timeIn = DateTime.Now.ToString("dd/MM/yyyy hh:mm tt"),
                orderDetails = drinksOrder
            };
            json.tables.tables[IndexOfTable(tableId)].available = false;
            json.WriteJsonTables();
            json.customers.customers.Add(customer);
            AddOrderToStaff(drinkId, drinkAmount, indexOfStaff, IndexOfUsingTable(tableId));
            json.WriteJsonCustomers();
        }
        static int IndexOfUsingTable(string tableId)
        {
            for (int i = 0; i < json.customers.customers.Count; i++)
                if (tableId == json.customers.customers[i].table)
                    return i;
            return -1;
        }
    }
}
