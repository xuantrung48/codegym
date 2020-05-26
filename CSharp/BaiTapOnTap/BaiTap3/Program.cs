using BaiTap3.Models;
using BaiTap3.Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace BaiTap3
{
    class Program
    {
        static JsonService json = new JsonService(@"D:\codegym\github\codegym\CSharp\BaiTapOnTap\BaiTap3\json\", "database.json", "Bills");
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            json.ReadDatabase();

            Console.WriteLine("2NDBEST");
            LogIn();
            Console.ReadKey();
        }
        static void LogIn()
        {
            Console.WriteLine("ĐĂNG NHẬP");
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Mật khẩu: ");
            string passWord = Console.ReadLine();
            if (email != json.database.admin.email || passWord != json.database.admin.passWord)
                Console.WriteLine("Sai email hoặc mật khẩu!");
            else
                Manage();
        }
        static void Manage()
        {
            Console.Clear();
            string option;
            do
            {
                Console.Write("TRANG QUẢN TRỊ\n" +
                    "1. Quản lý thành viên\n" +
                    "2. Quản lý đơn hàng\n" +
                    "3. Quản lý sản phẩm\n" +
                    "4. Đổi mật khẩu\n" +
                    "5. Thoát\n" +
                    "__________________\n" +
                    "Lựa chọn của bạn: ");
                option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        ManageUsers();
                        break;
                    case "2":
                        ManageOrders();
                        break;
                    case "3":
                        ManageProducts();
                        break;
                    case "4":
                        ChangeAdminPassword();
                        break;
                }
            } while (option != "5");
        }
        static void ManageOrders()
        {
            Console.Clear();
            string option;
            do
            {
                Console.Write("QUẢN LÝ ĐƠN HÀNG\n" +
                    "1. Hiển thị các đơn hàng\n" +
                    "2. Tìm kiếm đơn hàng\n" +
                    "3. Đổi trạng thái đơn hàng\n" +
                    "4. Tạo đơn hàng mới\n" +
                    "5. Thay đổi thông tin đơn hàng\n" +
                    "6. Thoát\n" +
                    "_________________________\n" +
                    "Lựa chọn của bạn: ");
                option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        ShowOrders();
                        break;
                    case "2":
                        SearchOrder();
                        break;
                    case "3":
                        ChangeOrderStatus();
                        break;
                    case "4":
                        CreateNewOrder();
                        break;
                    case "5":
                        UpdateOrder();
                        break;
                }
            } while (option != "6");
        }
        static void UpdateOrder()
        {
            Console.Write("Nhập vào ID đơn hàng: ");
            string orderId = Console.ReadLine();
            int indexOfOrder = IndexOfOrder(orderId);
            if (indexOfOrder == -1 || json.database.orders[indexOfOrder].orderStatus == OrderStatus.Canceled || json.database.orders[indexOfOrder].orderStatus == OrderStatus.Completed)
                Console.WriteLine("Đơn hàng không tồn tại hoặc đã hoàn thành / đã hủy!");
            else
            {
                string option;
                do
                {
                    Console.WriteLine($"Thay đổi thông tin đơn hàng {orderId}");
                    Console.Write("1. Thay đổi trạng thái đơn hàng\n" +
                        "2. Thay đổi thông tin khách hàng\n" +
                        "3. Thay đổi sản phẩm đặt hàng\n" +
                        "4. Thoát\n" +
                        "___________________\n" +
                        "Lựa chọn của bạn: ");
                    option = Console.ReadLine();
                    switch (option)
                    {
                        case "1":
                            ChangeOrderStatus(orderId);
                            break;
                        case "2":
                            ChangeOrderUserInfo(orderId);
                            break;
                        case "3":
                            ChangeOrderItems(orderId);
                            break;
                    }
                } while (option != "4");
            }
        }
        static void ChangeOrderItems(string orderId)
        {
            int indexOfOrder = IndexOfOrder(orderId);
            Console.Write("Nhập ID sản phẩm: ");
            string productId = Console.ReadLine();
            int indexOfProduct = IndexOfProduct(productId);
            if (indexOfProduct == -1)
                Console.WriteLine($"Không có sản phẩm {productId}!");
            else
            {
                int indexOfProductInOrderItems = IndexOfProductInOrderItems(productId, json.database.orders[indexOfOrder].items);
                if (indexOfProductInOrderItems == -1)
                {
                    Console.Write("Thêm vào sản phẩm khác? y/n: ");
                    if (Console.ReadLine() == "y")
                    {
                        Console.Write("Nhập vào số lượng: ");
                        uint.TryParse(Console.ReadLine(), out uint itemQuantity);
                        json.database.orders[indexOfOrder].items.Add(new ItemOrder()
                        {
                            id = productId,
                            name = json.database.products[indexOfProduct].name,
                            price = json.database.products[indexOfProduct].price,
                            quantity = (int)itemQuantity,
                            itemAmount = json.database.products[indexOfProduct].price * (int)itemQuantity
                        });
                        json.database.products[indexOfProduct].remain += (int)itemQuantity;
                        json.WriteDatabase();
                        Console.WriteLine("Đã thêm sản phẩm!");
                    }
                }
                else
                {
                    Console.Write("Thêm / bớt số lượng sản phẩm? y/n: ");
                    if (Console.ReadLine() == "y")
                    {
                        Console.Write("Nhập vào số lượng thêm / bớt (+/-): ");
                        int.TryParse(Console.ReadLine(), out int itemQuantity);
                        json.database.orders[indexOfOrder].items[indexOfProductInOrderItems].quantity += itemQuantity;
                        json.database.orders[indexOfOrder].items[indexOfProductInOrderItems].itemAmount += json.database.orders[indexOfOrder].items[indexOfProductInOrderItems].price * itemQuantity;
                        json.database.orders[indexOfOrder].total += json.database.orders[indexOfOrder].items[indexOfProductInOrderItems].price * itemQuantity;
                        json.database.products[indexOfProduct].remain += itemQuantity;
                        json.WriteDatabase();
                        Console.WriteLine("Đã thay đổi số lượng!");
                    }
                }
            }
        }
        static void ChangeOrderUserInfo(string orderId)
        {
            string option;
            do
            {
                Console.Write("1. Đổi tên\n" +
                    "2. Đổi số điện thoại\n" +
                    "3. Đổi địa chỉ\n" +
                    "4. Thoát\n" +
                    "________________\n" +
                    "Lựa chọn của bạn: ");
                option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        Console.Write("Nhập tên mới: ");
                        json.database.orders[IndexOfOrder(orderId)].customer.name = Console.ReadLine();
                        json.WriteDatabase();
                        Console.WriteLine("Đã đổi tên!");
                        break;
                    case "2":
                        Console.Write("Nhập số điện thoại mới: ");
                        string newPhoneNumber = Console.ReadLine();
                        if (ValidatePhoneNumber(newPhoneNumber))
                        {
                            json.database.orders[IndexOfOrder(orderId)].customer.name = Console.ReadLine();
                            json.WriteDatabase();
                            Console.WriteLine("Đã đổi tên!");
                        }
                        else
                            Console.WriteLine("Số điện thoại không hợp lệ!");
                        break;
                    case "3":
                        Console.Write("Nhập địa chỉ mới: ");
                        json.database.orders[IndexOfOrder(orderId)].customer.address = Console.ReadLine();
                        json.WriteDatabase();
                        Console.WriteLine("Đã đổi địa chỉ!");
                        break;
                }
            } while (option != "4");
        }
        static void CreateNewOrder()
        {
            Console.Clear();
            Console.WriteLine("TẠO ĐƠN HÀNG MỚI");
            string orderId = ++json.database.orderIdCounter + "";
            string userId = "";
            int indexOfUser = 0;
            do
            {
                if (indexOfUser == -1)
                {
                    Console.Write($"Không có khách hàng {userId}. Bạn có muốn tạo khách hàng mới không? y/n: ");
                    if (Console.ReadLine() == "y")
                        CreateNewUser();
                }
                Console.Write("Nhập vào ID khách hàng: ");
                userId = Console.ReadLine();
                indexOfUser = IndexOfUser(userId);
            } while (indexOfUser == -1);

            var orderItems = new List<ItemOrder>();
            string option;
            do
            {
                Console.Write("Id sản phẩm: ");
                string productId = Console.ReadLine();
                int indexOfProduct = IndexOfProduct(productId);
                if (indexOfProduct == -1)
                    Console.WriteLine($"Không có sản phẩm {productId}");
                else
                {
                    Console.Write("Số lượng: ");
                    uint.TryParse(Console.ReadLine(), out uint productQuantity);
                    int indexOfProductInOrderItems = IndexOfProductInOrderItems(productId, orderItems);
                    if (indexOfProductInOrderItems == -1)
                    {
                        orderItems.Add(new ItemOrder()
                        {
                            id = productId,
                            name = json.database.products[indexOfProduct].name,
                            price = json.database.products[indexOfProduct].price,
                            quantity = (int)productQuantity,
                            itemAmount = json.database.products[indexOfProduct].price * (int)productQuantity
                        });
                    }
                    else
                    {
                        orderItems[indexOfProductInOrderItems].quantity += (int) productQuantity;
                    }
                }
                Console.Write("Thêm sản phẩm khác? y/n: ");
                option = Console.ReadLine(); 
            } while (option == "y");
            int orderTotal = 0;
            foreach (var item in orderItems)
                orderTotal += item.itemAmount;
            json.database.orders.Add(new Order()
            {
                id = orderId,
                customer = json.database.users[indexOfUser],
                orderStatus = OrderStatus.Pending,
                items = orderItems,
                total = orderTotal
            });
            json.WriteDatabase();
        }
        static int IndexOfProductInOrderItems(string productId, List<ItemOrder> items)
        {
            for (int i = 0; i < items.Count; i++)
                if (productId == items[i].id)
                    return i;
            return -1;
        }

        static void ChangeOrderStatus(string orderId)
        {
            string option;
            do
            {
                var order = json.database.orders[IndexOfOrder(orderId)];
                Console.Write("1. Pending\n" +
                    "2. Processing\n" +
                    "3. Completed\n" +
                    "4. Canceled\n" +
                    "______________\n" +
                    "Lựa chọn của bạn: ");
                option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        order.orderStatus = OrderStatus.Pending;
                        json.WriteDatabase();
                        break;
                    case "2":
                        order.orderStatus = OrderStatus.Processing;
                        json.WriteDatabase();
                        break;
                    case "3":
                        order.orderStatus = OrderStatus.Completed;
                        json.WriteJsonBill(order);
                        json.WriteDatabase();
                        break;
                    case "4":
                        order.orderStatus = OrderStatus.Canceled;
                        foreach (var item in order.items)
                            json.database.products[IndexOfProduct(item.id)].remain += item.quantity;
                        json.WriteDatabase();
                        break;
                }
            } while (option != "1" && option != "2" && option != "3" && option != "4");
        }
        static void ChangeOrderStatus()
        {
            Console.Clear();
            Console.WriteLine("THAY ĐỔI TRẠNG THÁI ĐƠN HÀNG");
            Console.Write("ID đơn hàng: ");
            string orderId = Console.ReadLine();
            int indexOfOrder = IndexOfOrder(orderId);
            if (indexOfOrder == -1)
                Console.WriteLine($"Không có đơn hàng {orderId}");
            else
            {
                string option;
                do
                {
                    var order = json.database.orders[indexOfOrder];
                    Console.Write("1. Pending\n" +
                        "2. Processing\n" +
                        "3. Completed\n" +
                        "4. Canceled\n" +
                        "______________\n" +
                        "Lựa chọn của bạn: ");
                    option = Console.ReadLine();
                    switch (option)
                    {
                        case "1":
                            order.orderStatus = OrderStatus.Pending;
                            json.WriteDatabase();
                            break;
                        case "2":
                            order.orderStatus = OrderStatus.Processing;
                            json.WriteDatabase();
                            break;
                        case "3":
                            order.orderStatus = OrderStatus.Completed;
                            json.WriteJsonBill(order);
                            json.WriteDatabase();
                            break;
                        case "4":
                            order.orderStatus = OrderStatus.Canceled;
                            foreach(var item in order.items)
                                json.database.products[IndexOfProduct(item.id)].remain += item.quantity;
                            json.WriteDatabase();
                            break;
                    }
                } while (option != "1" && option != "2" && option != "3" && option != "4");
            }
        }
        static int IndexOfOrder(string orderId)
        {
            for(int i = 0; i < json.database.orders.Count; i++)
                if (orderId == json.database.orders[i].id)
                    return i;
            return -1;
        }
        static void SearchOrder()
        {
            Console.WriteLine("TÌM KIẾM ĐƠN HÀNG");
            Console.Write("Nhập vào từ khóa: ");
            string keyWord = Console.ReadLine().ToLower();
            Console.WriteLine("Kết quả: ");
            foreach (var order in json.database.orders)
                if (order.id.Contains(keyWord) || order.customer.name.Contains(keyWord) || order.customer.address.Contains(keyWord))
                    Console.WriteLine(order);
        }
        static void ShowOrders()
        {
            Console.Clear();
            Console.WriteLine("DANH SÁCH ĐƠN HÀNG");
            foreach (var order in json.database.orders)
                Console.WriteLine(order);
        }
        static void ManageUsers()
        {
            Console.Clear();
            string option;
            do
            {
                Console.Write("QUẢN LÝ THÀNH VIÊN\n" +
                    "1. Hiển thị danh sách thành viên\n" +
                    "2. Chỉnh sửa thông tin thành viên\n" +
                    "3. Tạo thành viên mới\n" +
                    "4. Thoát\n" +
                    "_____________________\n" +
                    "Lựa chọn của bạn: ");
                option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        ShowUsers();
                        break;
                    case "2":
                        ChangeUserInfo();
                        break;
                    case "3":
                        CreateNewUser();
                        break;
                }
            } while (option != "4");
            
        }
        static void CreateNewUser()
        {
            Console.Clear();
            Console.WriteLine("TẠO THÀNH VIÊN MỚI");
            string newUserId = ++json.database.userIdCounter + "";
            string newUserName;
            string newUserPhoneNumber;
            string newUserAddress;
            bool inputNotValid = false;
            do
            {
                if (inputNotValid)
                    Console.WriteLine("Tên không được để trống!");
                inputNotValid = false;
                Console.Write("Nhập tên: ");
                newUserName = Console.ReadLine();
                if (newUserName == "")
                    inputNotValid = true;
            } while (inputNotValid);

            do
            {
                if (inputNotValid)
                    Console.WriteLine("Số điện thoại không hợp lệ!");
                inputNotValid = false;
                Console.Write("Nhập số điện thoại: ");
                newUserPhoneNumber = Console.ReadLine();
                if (!ValidatePhoneNumber(newUserPhoneNumber))
                    inputNotValid = true;
            } while (inputNotValid);

            do
            {
                if (inputNotValid)
                    Console.WriteLine("Địa chỉ không được để trống!");
                inputNotValid = false;
                Console.Write("Nhập địa chỉ: ");
                newUserAddress = Console.ReadLine();
                if (newUserAddress == "")
                    inputNotValid = true;
            } while (inputNotValid);
            json.database.users.Add(new User()
            {
                id = newUserId,
                name = newUserName,
                address = newUserAddress,
                phoneNumber = newUserPhoneNumber
            });
            json.WriteDatabase();
            Console.WriteLine("Đã tạo thành viên mới!");
        }
        static void ChangeUserInfo()
        {
            Console.Clear();
            Console.Write("ĐỔI THÔNG TIN THÀNH VIÊN\n" +
                "Nhập vào ID thành viên: ");
            string userId = Console.ReadLine();
            int indexOfUser = IndexOfUser(userId);
            if (indexOfUser == -1)
                Console.WriteLine($"Không có thành viên {userId}");
            else
            {
                var user = json.database.users[indexOfUser];
                Console.WriteLine(user);
                string option;
                do
                {
                    Console.Write("1. Đổi tên\n" +
                        "2. Đổi số điện thoại\n" +
                        "3. Đổi địa chỉ\n" +
                        "4. Thoát\n" +
                        "_______________\n" +
                        "Lựa chọn của bạn: ");
                    option = Console.ReadLine();
                    switch (option)
                    {
                        case "1":
                            Console.Write("Nhập vào tên mới: ");
                            string newName = Console.ReadLine();
                            if (newName == "")
                                Console.WriteLine("Tên không được để trống!");
                            else
                            {
                                user.name = newName;
                                json.WriteDatabase();
                                Console.WriteLine("Đã đổi tên!");
                            }
                            break;
                        case "2":
                            Console.Write("Nhập vào SDT mới: ");
                            string newPhoneNumber = Console.ReadLine();
                            if (ValidatePhoneNumber(newPhoneNumber))
                            {
                                user.phoneNumber = newPhoneNumber;
                                json.WriteDatabase();
                                Console.WriteLine("Đã đổi số điện thoại!");
                            }
                            else
                            {
                                Console.WriteLine("Số điện thoại không hợp lệ!");
                            }
                            break;
                        case "3":
                            Console.Write("Nhập vào địa chỉ mới: ");
                            string newAddress = Console.ReadLine();
                            if (newAddress == "")
                                Console.WriteLine("Địa chỉ không được để trống!");
                            else
                            {
                                user.address = newAddress;
                                json.WriteDatabase();
                                Console.WriteLine("Đã đổi địa chỉ!");
                            }
                            break;
                    }
                } while (option != "4");
            }
        }
        static bool ValidatePhoneNumber(string phoneNumber)
        {
            string regex = @"^(0[3|5|7|8|9])+([0-9]{8})\b$";
            return Regex.IsMatch(phoneNumber, regex);
        }
        static int IndexOfUser(string userId)
        {
            for (int i = 0; i < json.database.users.Count; i++)
                if (userId == json.database.users[i].id)
                    return i;
            return -1;
        }
        static void ShowUsers()
        {
            Console.Clear();
            Console.WriteLine("DANH SÁCH THÀNH VIÊN");
            foreach (var user in json.database.users)
                Console.WriteLine(user);
        }
        static void ManageProducts()
        {
            Console.Clear();
            string option;
            do
            {
                Console.Write("QUẢN LÝ SẢN PHẨM\n" +
                    "1. Hiển thị danh sách sản phẩm\n" +
                    "2. Tìm kiếm sản phẩm\n" +
                    "3. Đổi thông tin sản phẩm\n" +
                    "4. Thêm sản phẩm\n" +
                    "5. Thoát\n" +
                    "__________________________\n" +
                    "Lựa chọn của bạn: ");
                option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        ShowProducts();
                        break;
                    case "2":
                        SearchProduct();
                        break;
                    case "3":
                        ChangeProductInfo();
                        break;

                }
            } while (option != "5");
        }
        static void ChangeProductInfo()
        {
            Console.Clear();
            Console.Write("ĐỔI THÔNG TIN SẢN PHẨM\n" +
                "Nhập vào ID sản phẩm: ");
            string productId = Console.ReadLine();
            int indexOfProduct = IndexOfProduct(productId);
            if (indexOfProduct == -1)
                Console.WriteLine($"Không có sản phẩm {productId}");
            else
            {
                var product = json.database.products[indexOfProduct];
                Console.WriteLine(json.database.products[indexOfProduct]);
                string option;
                do
                {
                    Console.Write("1. Đổi tên\n" +
                        "2. Đổi giá\n" +
                        "3. Đổi số lượng tồn kho\n" +
                        "4. Thoát\n" +
                        "_______________\n" +
                        "Lựa chọn của bạn: ");
                    option = Console.ReadLine();
                    switch (option)
                    {
                        case "1":
                            Console.Write("Nhập vào tên mới: ");
                            string newName = Console.ReadLine();
                            product.name = newName;
                            json.WriteDatabase();
                            break;
                        case "2":
                            Console.Write("Nhập vào gía mới: ");
                            uint.TryParse(Console.ReadLine(), out uint newPrice);
                            product.price = (int)newPrice;
                            json.WriteDatabase();
                            break;
                        case "3":
                            Console.Write("Nhập vào số lượng tồn kho mới: ");
                            uint.TryParse(Console.ReadLine(), out uint newRemain);
                            product.remain = (int)newRemain;
                            json.WriteDatabase();
                            break;
                    }
                } while (option != "4");
            }
        }
        static void SearchProduct()
        {
            Console.Clear();
            Console.Write("TÌM KIẾM SẢN PHẨM\n" +
                "Nhập vào từ khóa: ");
            string keyWord = Console.ReadLine().ToLower();
            foreach (var product in json.database.products)
                if (product.id.ToLower().Contains(keyWord) || product.name.ToLower().Contains(keyWord))
                    Console.WriteLine(product);
        }
        static void ShowProducts()
        {
            Console.Clear();
            Console.WriteLine("DANH SÁCH SẢN PHẨM");
            foreach (var product in json.database.products)
                Console.WriteLine(product);
        }
        static int IndexOfProduct(string productId)
        {
            for (int i = 0; i < json.database.products.Count; i++)
                if (productId == json.database.products[i].id)
                    return i;
            return -1;
        }
        static void ChangeAdminPassword()
        {
            Console.Clear();
            Console.WriteLine("ĐỔI MẬT KHẨU");
            string regex = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,15}$";
            string newPassword;
            bool passWordIsNotValid = false;
            do
            {
                if (passWordIsNotValid)
                    Console.WriteLine("Mật khẩu không đủ mạnh, hãy nhập mật khẩu khác!");
                Console.Write("Mật khẩu mới: ");
                newPassword = Console.ReadLine();
                passWordIsNotValid = !Regex.IsMatch(newPassword, regex);
            } while (passWordIsNotValid);
            json.database.admin.passWord = newPassword;
            json.WriteDatabase();
            Console.WriteLine("Đã thay đổi thành công!");
        }
    }
}
