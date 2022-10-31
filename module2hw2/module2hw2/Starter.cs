using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace Module2hw2
{
    public class Starter
    {
        public static void Run()
        {
            Store store = Store.GetInstance();
            FillStore();
            Console.Write(store.ToString());
            Order[] oldOrders = { new Order(), new Order(), new Order(), new Order() };
            var chosenProducts = FillBasket();
            var order = CreateOrder(chosenProducts);
            Console.Write(order.ToString());
        }

        public static void FillStore()
        {
            Store store = Store.GetInstance();
            store.AddProduct(1, "T-shirt", "Polka-dot, color: white, fabric - cotton", 500);
            store.AddProduct(2, "Slim dress", "Short, color: wine", 900);
            store.AddProduct(3, "Jacket", "Classic, color: black", 2000);
            store.AddProduct(4, "Pants", "Classic, color: black", 1800);
            store.AddProduct(5, "Skirt", "Short, color: pink", 800);
            store.AddProduct(6, "Top", "Sexy asymmetric, color: red", 400);
            store.AddProduct(7, "Bomber", "Season: winter, color: white", 3600);
        }

        public static Basket CreateBasket()
        {
            Basket basket = new Basket();

            bool check;
            string input = string.Empty;
            string[] lexems = null;
            Console.WriteLine("\nInfo: If you want 2 or more pieces of same product, just enter its id multiple times.");
            do
            {
                try
                {
                    System.Console.WriteLine("\nEnter IDs of products that you want to add to basket:");
                    input = System.Console.ReadLine();
                    lexems = input.Split(" ");
                    if (lexems.Length > 10)
                    {
                        System.Console.WriteLine("\nMaximum quantity of products per order is 10.\n");
                        check = false;
                    }
                    else if (string.IsNullOrEmpty(input))
                    {
                        System.Console.WriteLine("\nYou should write at least one ID or more (with space between them).\n");
                        check = false;
                    }

                    bool areAllNums = true;

                    for (int i = 0; i < lexems.Length; i++)
                    {
                        if (!int.TryParse(lexems[i], out int result))
                        {
                            areAllNums = false;
                        }
                    }

                    if (areAllNums)
                    {
                        bool areAllInRange = true;

                        for (int i = 0; i < lexems.Length; i++)
                        {
                            if ((int.Parse(lexems[i]) > Store.GetInstance().GetProducts().Length) || (int.Parse(lexems[i]) < 1))
                            {
                                areAllInRange = false;
                            }
                        }

                        if (areAllInRange)
                        {
                            check = true;
                        }
                        else
                        {
                            check = false;
                            System.Console.WriteLine("\nEnter IDs from available in store.\n");
                        }
                    }
                    else
                    {
                        check = false;
                    }
                }
                catch (Exception e)
                {
                    System.Console.WriteLine(e.Data);
                    check = false;
                }
            }
            while (!check);

            for (int i = 0; i < lexems.Length; i++)
            {
                basket.AddProductID(int.Parse(lexems[i]));
            }

            return basket;
        }

        public static Product[] FillBasket()
        {
            Basket basket = CreateBasket();
            Console.Write("\nYour basket:\n");
            for (int i = 0; i < basket.GetIDs().Length; i++)
            {
                Console.Write(Store.GetInstance().GetProduct(basket.GetIDs()[i]).ToString());
            }

            Product[] products = new Product[basket.GetIDs().Length];

            for (int i = 0; i < products.Length; i++)
            {
                products[i] = Store.GetInstance().GetProduct(basket.GetIDs()[i]);
            }

            return products;
        }

        public static Order CreateOrder(Product[] products)
        {
            bool check;
            string input = string.Empty;
            string name = string.Empty;
            string address = string.Empty;
            string number = string.Empty;
            System.Console.WriteLine("\nNow enter your data for order.");
            do
            {
                try
                {
                    System.Console.WriteLine("\nEnter your full name:");
                    input = System.Console.ReadLine();
                    if (string.IsNullOrEmpty(input))
                    {
                        check = false;
                    }
                    else
                    {
                        check = true;
                        name = input;
                    }
                }
                catch (Exception e)
                {
                    System.Console.WriteLine(e.Data);
                    check = false;
                }
            }
            while (!check);

            do
            {
                try
                {
                    System.Console.WriteLine("\nEnter your address:");
                    input = System.Console.ReadLine();
                    if (string.IsNullOrEmpty(input))
                    {
                        check = false;
                    }
                    else
                    {
                        check = true;
                        address = input;
                    }
                }
                catch (Exception e)
                {
                    System.Console.WriteLine(e.Data);
                    check = false;
                }
            }
            while (!check);

            do
            {
                try
                {
                    System.Console.WriteLine("\nEnter your number:");
                    input = System.Console.ReadLine();
                    if (string.IsNullOrEmpty(input))
                    {
                        check = false;
                    }
                    else
                    {
                        check = true;
                        number = input;
                    }
                }
                catch (Exception e)
                {
                    System.Console.WriteLine(e.Data);
                    check = false;
                }
            }
            while (!check);

            return new Order(products, name, address, number);
        }
    }
}
