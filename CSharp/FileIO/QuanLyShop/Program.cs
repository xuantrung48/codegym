using TMDT.Models;
using TMDT.Services;
using System;
using System.Text;
using System.Collections.Generic;
using QuanLyShop.Models;

namespace TMDT
{
    class Program
    {
        static JsonService json = new JsonService(@"D:\codegym\github\codegym\CSharp\FileIO\QuanLyShop\Data\", "products.json", "Bills");
        static Cart cart = new Cart()
        {
            items = new List<CartProduct>()
        };
        static void Main(string[] args)
        {
            json.ReadJsonData();
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
            string option = "";
            do
            {
                Console.Write("______COCO STORE_______\n" +
                                "Menu\n" +
                                "1. Hiển thị sản phẩm trong cửa hàng\n" +
                                "2. Hiển thị giỏ hàng\n" +
                                "3. Thêm vào giỏ hàng\n" +
                                "4. Thoát chương trình\n" +
                                "______________________\n" +
                                "Lựa chọn của bạn: ");
                option = Console.ReadLine();
                Process(option);
            } while (option != "4");
        }
        static void Process(string option)
        {
            switch (option)
            {
                case "1":
                    ShowProducts();
                    break;
                case "2":
                    ShowCart();
                    break;
                case "3":
                    AddProduct();
                    break;
            }
        }
        static void ShowProducts()
        {
            Console.Clear();
            string result = "Danh sách sản phẩm:\n";
            var products = json.products.products;
            foreach (var product in products)
                result += $"ID: {product.id}\tTên SP: {product.name}\tGiá: {product.price}\tSố lượng: {product.remain}\n";
            Console.WriteLine(result);
        }
        static int CalculateItemAmount(string productID)
        {
            var result = 0;
            foreach(var item in cart.items)
                if (item.id == productID)
                    result += item.quantity * item.price;
            return result;
        }
        static void ShowCart()
        {
            Console.Clear();
            string result = "Giỏ hàng:\n";
            foreach (var product in cart.items)
                result += $"Sản phẩm: {product.name}\tGiá SP: {product.price}\tSố lượng: {product.quantity}\tThành tiền: {CalculateItemAmount(product.id)}\n";
            result += $"_______________________Total: {cart.Total}_______________________";
            Console.WriteLine(result);
            string option;
            do
            {
                Console.Write("1. Hiển thị giỏ hàng\n" +
                    "2. Thêm vào giỏ hàng\n" +
                    "3. Cập nhật giỏ hàng\n" +
                    "4. Thanh toán\n" +
                    "5. Hủy giỏ hàng\n" +
                    "6. Về menu chính\n" +
                    "___________________\n" +
                    "Lựa chọn của bạn: ");
                option = Console.ReadLine();
                ProcessCart(option);
            } while (option != "6");
        }
        static void ProcessCart(string option)
        {
            switch (option)
            {
                case "1":
                    ShowCart();
                    break;
                case "2":
                    AddProduct();
                    break;
                case "3":
                    UpdateCart();
                    break;
                case "4":
                    CheckOut();
                    break;
                case "5":
                    cart = new Cart()
                    {
                        items = new List<CartProduct>()
                    };
                    break;
            }
        }
        static int CalculateTotalInCart()
        {
            int total = 0;
            foreach(var item in cart.items)
                total += item.quantity * item.price;
            return total;
        }
        static void CheckOut()
        {
            json.ReadJsonData();
            bool canCheckOut = true;
            foreach(var item in cart.items)
                if (item.quantity > json.products.products[IndexOfProductInProducts(item.id)].remain)
                {
                    Console.WriteLine("Một trong các sản phẩm trong giỏ hàng của bạn vượt quá số lượng chúng tôi có thể cung cấp, hãy cập nhật lại giỏ hàng của bạn!");
                    canCheckOut = false;
                    break;
                }
            if (canCheckOut)
            {
                var productList = new List<BillProduct>();
                foreach(var item in cart.items)
                    productList.Add(new BillProduct()
                    {
                        id = item.id,
                        name = item.name,
                        price = item.price,
                        quantity = item.quantity,
                        itemAmount = item.price * item.quantity
                    });
                var bill = new Bill()
                {
                    time = DateTime.Now.ToString("dd_MM_yyyy hh:mm tt"),
                    items = productList,
                    totalAmount = CalculateTotalInCart()
                };
                json.WriteJsonBill(bill);
                foreach (var item in bill.items)
                    json.products.products[IndexOfProductInProducts(item.id)].remain -= item.quantity;
                json.WriteJsonData(json.products);
                cart = new Cart()
                {
                    items = new List<CartProduct>()
                };
                Console.Clear();
                Console.WriteLine("Đã tạo bill!");
            }
        }
        static void EnterValidQuantity(out int number, string productID, bool updateCart)
        {
            int indexOfProductInCart = IndexOfProductInCart(productID);
            bool quantityIsOver = false;
            bool negativeQuantity = false;
            bool numberNegative = false;
            number = 0;
            do
            {
                if (numberNegative)
                    Console.WriteLine("Bạn đã nhập vào một số âm, hãy nhập lại!");
                if (quantityIsOver)
                    Console.WriteLine("Bạn đã nhập quá số lượng sẵn có của chúng tôi, hãy nhập lại!");
                if (negativeQuantity)
                    Console.WriteLine("Bạn đã bớt quá số lượng có trong giỏ hàng, hãy nhập lại!");
                negativeQuantity = false;
                quantityIsOver = false;
                if (updateCart)
                    Console.Write("Số lượng thêm/bớt: ");
                else
                    Console.Write("Số lượng sản phẩm: ");
                int.TryParse(Console.ReadLine(), out number);
                if (indexOfProductInCart == -1)
                {
                    if (number > json.products.products[IndexOfProductInProducts(productID)].remain)
                        quantityIsOver = true;
                    if (number < 0)
                        numberNegative = true;
                }
                else
                {
                    if (number + cart.items[indexOfProductInCart].quantity > json.products.products[IndexOfProductInProducts(productID)].remain)
                        quantityIsOver = true;
                    if (number + cart.items[indexOfProductInCart].quantity < 0)
                        negativeQuantity = true;
                }

            } while (quantityIsOver || negativeQuantity);
        }
        static void UpdateCart()
        {
            Console.Clear();
            ShowCart();
            Console.WriteLine("Cập nhật giỏ hàng");

            Console.Write("Nhập vào ID sản phẩm: ");
            string productID = Console.ReadLine();
            int indexOfProductInCart = IndexOfProductInCart(productID);
            if (indexOfProductInCart == -1)
                Console.WriteLine("Sản phẩm không có trong giỏ hàng!");
            else
            {
                EnterValidQuantity(out int number, productID, true);
                cart.items[indexOfProductInCart].quantity += number;
            }
            cart.Total = CalculateTotalInCart();
        }
        static int IndexOfProductInCart(string productID)
        {
            for(int i = 0; i < cart.items.Count; i++)
                if (productID == cart.items[i].id)
                    return i;
            return -1;
        }
        static int IndexOfProductInProducts(string productID)
        {
            for (int i = 0; i < json.products.products.Count; i++)
                if (productID == json.products.products[i].id)
                    return i;
            return -1;
        }
        static void AddProduct()
        {
            Console.Clear();
            ShowProducts();
            bool ProductIsNotValid = false;
            string productID;
            do
            {
                if (ProductIsNotValid)
                    Console.WriteLine("Sản phẩm không có, xin hãy nhập lại!");
                ProductIsNotValid = true;
                Console.Write("Nhập ID SP: ");
                productID = Console.ReadLine();
                foreach (var product in json.products.products)
                    if (productID == product.id)
                    {
                        ProductIsNotValid = false;
                        break;
                    }
            } while (ProductIsNotValid);


            string productName = "";
            int productPrice = 0;

            foreach (var product in json.products.products)
                if (productID == product.id)
                {
                    productName = product.name;
                    productPrice = product.price;
                }

            int indexOfProductInCart = IndexOfProductInCart(productID);

            EnterValidQuantity(out int quantity, productID, false);

            if (indexOfProductInCart == -1)
            {
                cart.items.Add(new CartProduct()
                {
                    id = productID,
                    name = productName,
                    price = productPrice,
                    quantity = quantity
                });
            }
            else
                cart.items[indexOfProductInCart].quantity += quantity;

            cart.Total = CalculateTotalInCart();
        }
    }
}
