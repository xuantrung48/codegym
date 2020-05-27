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
            foreach(var user in json.database.users)
            {
                if (email == user.email && passWord == user.passWord)
                    if (user.role == Role.Admin)
                    {
                        json.currentUser = user;
                        MenuForAdmin();
                    }
                    else if(user.role == Role.User)
                    {
                        json.currentUser = user;
                        MenuForUser();
                    }
                else
                    Console.WriteLine("Sai email hoặc mật khẩu!");
            }
        }
        static void MenuForAdmin()
        {
            Console.Clear();
            string option;
            do
            {
                Console.Write("TRANG QUẢN LÝ DÀNH CHO QUẢN TRỊ VIÊN\n" +
                    "1. Quản lý khách hàng\n" +
                    "2. Quản lý đơn hàng\n" +
                    "3. Quản lý sản phẩm\n" +
                    "4. Đổi mật khẩu\n" +
                    "5. Quản lý nhân viên\n" +
                    "5. Thoát\n" +
                    "__________________\n" +
                    "Lựa chọn của bạn: ");
                option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        ManageCustomer();
                        break;
                    case "2":
                        ManageOrders();
                        break;
                    case "3":
                        ManageProducts();
                        break;
                    case "4":
                        ChangeCurrentUserPassword();
                        break;
                    case "5":
                        ManageUser();
                        break;
                }
            } while (option != "5");
        }
        static void MenuForUser()
        {
            Console.Clear();
            string option;
            do
            {
                Console.Write("TRANG QUẢN LÝ DÀNH CHO NHÂN VIÊN\n" +
                    "1. Quản lý khách hàng\n" +
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
                        ManageCustomer();
                        break;
                    case "2":
                        ManageOrders();
                        break;
                    case "3":
                        ManageProducts();
                        break;
                    case "4":
                        ChangeCurrentUserPassword();
                        break;
                }
            } while (option != "5");
        }
        static void ManageCustomer()
        {
            Console.Clear();
            string option;
            do
            {
                Console.Write("QUẢN LÝ KHÁCH HÀNG\n" +
                    "1. Hiển thị danh sách khách hàng\n" +
                    "2. Tìm kiếm khách hàng\n" +
                    "3. Chỉnh sửa thông tin khách hàng\n" +
                    "4. Tạo khách hàng mới\n" +
                    "5. Thoát\n" +
                    "_____________________\n" +
                    "Lựa chọn của bạn: ");
                option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        ShowCustomers();
                        break;
                    case "2":
                        SearchCustomer();
                        break;
                    case "3":
                        ChangeCustomerInfo();
                        break;
                    case "4":
                        CreateNewCustomer();
                        break;
                }
            } while (option != "5");

        }
        static void ShowCustomers()
        {
            Console.Clear();
            Console.WriteLine("DANH SÁCH KHÁCH HÀNG");
            foreach (var user in json.database.users)
                Console.WriteLine(user);
        }
        static void SearchCustomer()
        {
            Console.Clear();
            Console.Write("TÌM KIẾM KHÁCH HÀNG\n" +
                "Từ khóa: ");
            string keyWord = Console.ReadLine().ToLower();
            Console.WriteLine("Kết quả: ");
            foreach (var customer in json.database.customers)
                if (customer.id.ToLower().Contains(keyWord) || customer.name.ToLower().Contains(keyWord) || customer.address.ToLower().Contains(keyWord) || customer.phoneNumber.ToLower().Contains(keyWord))
                    Console.WriteLine(customer);
        }
        static void ChangeCustomerInfo()
        {
            Console.Clear();
            Console.Write("ĐỔI THÔNG TIN KHÁCH HÀNG\n" +
                "Nhập vào ID khách hàng: ");
            string userId = Console.ReadLine();
            int indexOfCustomer = IndexOfCustomer(userId);
            if (indexOfCustomer == -1)
                Console.WriteLine($"Không có khách hàng {userId}");
            else
            {
                var customer = json.database.customers[indexOfCustomer];
                Console.WriteLine(customer);
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
                                customer.name = newName;
                                json.WriteDatabase();
                                Console.WriteLine("Đã đổi tên!");
                            }
                            break;
                        case "2":
                            Console.Write("Nhập vào SDT mới: ");
                            string newPhoneNumber = Console.ReadLine();
                            if (ValidatePhoneNumber(newPhoneNumber))
                            {
                                customer.phoneNumber = newPhoneNumber;
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
                                customer.address = newAddress;
                                json.WriteDatabase();
                                Console.WriteLine("Đã đổi địa chỉ!");
                            }
                            break;
                    }
                } while (option != "4");
            }
        }
        static void CreateNewCustomer()
        {
            Console.Clear();
            Console.WriteLine("TẠO KHÁCH HÀNG MỚI");
            string newUserId = ++json.database.customerIdCounter + "";
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
            json.database.customers.Add(new Customer()
            {
                id = newUserId,
                name = newUserName,
                address = newUserAddress,
                phoneNumber = newUserPhoneNumber
            });
            json.WriteDatabase();
            Console.WriteLine("Đã tạo khách hàng mới!");
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
                    "4. Thay đổi thông tin đơn hàng\n" +
                    "5. Tạo đơn hàng mới\n" +
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
                        UpdateOrder();
                        break;
                    case "5":
                        CreateNewOrder();
                        break;
                }
            } while (option != "6");
        }
        static void ShowOrders()
        {
            Console.Clear();
            Console.WriteLine("DANH SÁCH ĐƠN HÀNG");
            foreach (var order in json.database.orders)
                Console.WriteLine(order);
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
                ChangeOrderStatus(orderId);
            }
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
                            ChangeOrderCustomerInfo(orderId);
                            break;
                        case "3":
                            ChangeOrderItems(orderId);
                            break;
                    }
                } while (option != "4");
            }
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
        static void ChangeOrderCustomerInfo(string orderId)
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
                        if (json.database.products[indexOfProduct].remain - (int)itemQuantity < 0)
                            Console.WriteLine("Sản phẩm không đủ số lượng!");
                        else
                        {
                            json.database.orders[indexOfOrder].items.Add(new ItemOrder()
                            {
                                id = productId,
                                name = json.database.products[indexOfProduct].name,
                                price = json.database.products[indexOfProduct].price,
                                quantity = (int)itemQuantity,
                                itemAmount = json.database.products[indexOfProduct].price * (int)itemQuantity
                            });
                            json.database.products[indexOfProduct].remain -= (int)itemQuantity;
                            json.WriteDatabase();
                            Console.WriteLine("Đã thêm sản phẩm!");
                        }
                    }
                }
                else
                {
                    Console.Write("Thêm / bớt số lượng sản phẩm? y/n: ");
                    if (Console.ReadLine() == "y")
                    {
                        Console.Write("Nhập vào số lượng thêm / bớt (+/-): ");
                        int.TryParse(Console.ReadLine(), out int itemQuantity);
                        if (json.database.products[indexOfProduct].remain - (int)itemQuantity < 0)
                            Console.WriteLine("Sản phẩm không đủ số lượng!");
                        else
                        {
                            json.database.orders[indexOfOrder].items[indexOfProductInOrderItems].quantity += itemQuantity;
                            json.database.orders[indexOfOrder].items[indexOfProductInOrderItems].itemAmount += json.database.orders[indexOfOrder].items[indexOfProductInOrderItems].price * itemQuantity;
                            json.database.orders[indexOfOrder].total += json.database.orders[indexOfOrder].items[indexOfProductInOrderItems].price * itemQuantity;
                            json.database.products[indexOfProduct].remain -= itemQuantity;
                            json.WriteDatabase();
                            Console.WriteLine("Đã thay đổi số lượng!");
                        }
                    }
                }
            }
        }
        static void CreateNewOrder()
        {
            Console.Clear();
            Console.WriteLine("TẠO ĐƠN HÀNG MỚI");
            string orderId = ++json.database.orderIdCounter + "";
            string userId = "";
            int indexOfCustomer = 0;
            do
            {
                if (indexOfCustomer == -1)
                {
                    Console.Write($"Không có khách hàng {userId}. Bạn có muốn tạo khách hàng mới không? y/n: ");
                    if (Console.ReadLine() == "y")
                        CreateNewCustomer();
                }
                Console.Write("Nhập vào ID khách hàng: ");
                userId = Console.ReadLine();
                indexOfCustomer = IndexOfCustomer(userId);
            } while (indexOfCustomer == -1);

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
                customer = json.database.customers[indexOfCustomer],
                orderStatus = OrderStatus.Pending,
                items = orderItems,
                staff = new UserInOrder()
                {
                    id = json.currentUser.id,
                    name = json.currentUser.name
                },
                total = orderTotal
            });
            json.WriteDatabase();
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
        static void ShowProducts()
        {
            Console.Clear();
            Console.WriteLine("DANH SÁCH SẢN PHẨM");
            foreach (var product in json.database.products)
                Console.WriteLine(product);
        }
        static void SearchProduct()
        {
            Console.Clear();
            Console.Write("TÌM KIẾM SẢN PHẨM\n" +
                "Nhập vào từ khóa: ");
            string keyWord = Console.ReadLine().ToLower();
            Console.WriteLine("Kết quả: ");
            foreach (var product in json.database.products)
                if (product.id.ToLower().Contains(keyWord) || product.name.ToLower().Contains(keyWord))
                    Console.WriteLine(product);
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
        static void ManageUser()
        {
            Console.Clear();
            Console.WriteLine("QUẢN LÝ NHÂN VIÊN");
            string option;
            do
            {
                Console.Write("1. Hiển thị danh sách nhân viên\n" +
                    "2. Tìm kiếm nhân viên\n" +
                    "3. Thay đổi thông tin nhân viên\n" +
                    "4. Thoát\n" +
                    "____________________________\n" +
                    "Lựa chọn của bạn: ");
                option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        ShowUsers();
                        break;
                    case "2":
                        SearchUser();
                        break;
                    case "3":
                        ChangeUserInfo();
                        break;
                }
            } while (option != "4");
        }
        static void ShowUsers()
        {
            Console.Clear();
            Console.WriteLine("Danh sách nhân viên: ");
            foreach (var user in json.database.users)
                Console.WriteLine(user);
        }
        static void SearchUser()
        {
            Console.Clear();
            Console.WriteLine("TÌM KIẾM NHÂN VIÊN");
            Console.Write("Nhập vào từ khóa: ");
            string keyWord = Console.ReadLine().ToLower();
            Console.WriteLine("Kết quả: ");
            foreach (var user in json.database.users)
                if (user.id.ToLower().Contains(keyWord) || user.name.ToLower().Contains(keyWord) || user.email.ToLower().Contains(keyWord))
                    Console.WriteLine(user);
        }
        static void ChangeUserInfo()
        {
            Console.Clear();
            Console.WriteLine("THAY ĐỔI THÔNG TIN NHÂN VIÊN");
            Console.Write("Nhập vào ID nhân viên: ");
            string userId = Console.ReadLine();
            int indexOfUser = IndexOfUser(userId);
            if (indexOfUser == -1)
                Console.WriteLine($"Không có nhân viên {userId}!");
            else
            {
                Console.WriteLine(json.database.users[indexOfUser]);
                string option;
                do
                {
                    Console.Write("1. Đổi tên\n" +
                        "2. Đổi email\n" +
                        "3. Đối password\n" +
                        "4. Thoát\n" +
                        "__________________\n" +
                        "Lựa chọn của bạn: ");
                    option = Console.ReadLine();
                    switch (option)
                    {
                        case "1":
                            ChangeUserName(indexOfUser);
                            break;
                        case "2":
                            ChangeUserEmail(indexOfUser);
                            break;
                        case "3":
                            ChangeUserPassword(indexOfUser);
                            break;
                    }
                } while (option != "4");
            }
        }
        static void ChangeUserName(int indexOfUser)
        {
            Console.Write("Nhập vào tên mới: ");
            string newName = Console.ReadLine();
            json.database.users[indexOfUser].name = newName;
            json.WriteDatabase();
            Console.WriteLine("Đã đổi tên!");
        }
        static void ChangeUserEmail(int indexOfUser)
        {
            Console.Write("Nhập vào email mới: ");
            string newEmail = Console.ReadLine();
            if (ValidateEmail(newEmail))
            {
                json.database.users[indexOfUser].email = newEmail;
                json.WriteDatabase();
                Console.WriteLine("Đã thay đổi email!");
            }
            else
                Console.WriteLine("Email không hợp lệ!");
        }
        static void ChangeUserPassword(int indexOfUser)
        {
            Console.Write("Nhập vào mật khẩu mới: ");
            string newPassword = Console.ReadLine();
            if (ValidatePassword(newPassword))
            {
                json.database.users[indexOfUser].passWord = newPassword;
                json.WriteDatabase();
                Console.WriteLine("Đã đổi email!");
            }
            else
                Console.WriteLine("Email không hợp lệ!");
        }
        static void ChangeCurrentUserPassword()
        {
            Console.Clear();
            Console.WriteLine("ĐỔI MẬT KHẨU");
            string newPassword;
            bool passWordIsNotValid = false;
            do
            {
                if (passWordIsNotValid)
                    Console.WriteLine("Mật khẩu không đủ mạnh, hãy nhập mật khẩu khác!");
                Console.Write("Mật khẩu mới: ");
                newPassword = Console.ReadLine();
                passWordIsNotValid = !ValidatePassword(newPassword);
            } while (passWordIsNotValid);
            json.database.users[IndexOfUser(json.currentUser.id)].passWord = newPassword;
            json.WriteDatabase();
            Console.WriteLine("Đã thay đổi thành công!");
        }
        static bool ValidateEmail(string email)
        {
            string regex = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
            return Regex.IsMatch(email, regex);
        }
        static bool ValidatePhoneNumber(string phoneNumber)
        {
            string regex = @"^(0[3|5|7|8|9])+([0-9]{8})\b$";
            return Regex.IsMatch(phoneNumber, regex);
        }
        static bool ValidatePassword(string passWord)
        {
            string regex = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,15}$";
            return Regex.IsMatch(passWord, regex);
        }
        static int IndexOfUser(string userId)
        {
            for (int i = 0; i < json.database.users.Count; i++)
                if (userId == json.database.users[i].id)
                    return i;
            return -1;
        }
        static int IndexOfProduct(string productId)
        {
            for (int i = 0; i < json.database.products.Count; i++)
                if (productId == json.database.products[i].id)
                    return i;
            return -1;
        }
        static int IndexOfCustomer(string userId)
        {
            for (int i = 0; i < json.database.users.Count; i++)
                if (userId == json.database.users[i].id)
                    return i;
            return -1;
        }
        static int IndexOfOrder(string orderId)
        {
            for (int i = 0; i < json.database.orders.Count; i++)
                if (orderId == json.database.orders[i].id)
                    return i;
            return -1;
        }
        static int IndexOfProductInOrderItems(string productId, List<ItemOrder> items)
        {
            for (int i = 0; i < items.Count; i++)
                if (productId == items[i].id)
                    return i;
            return -1;
        }
    }
}
