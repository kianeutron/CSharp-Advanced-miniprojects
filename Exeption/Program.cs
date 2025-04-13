using System;
using System.Collections.Generic;

namespace Exeption
{
    class Program
    {
        static List<Product> inventory = new List<Product>();
        static List<string> logs = new List<string>();

        static void Main(string[] args)
        {
            inventory.Add(new Product("Laptop", 10, 1000.00m));
            inventory.Add(new Product("Mouse", 20, 20.00m));
            inventory.Add(new Product("Keyboard", 15, 50.00m));

            DisplayInventory();

            OrderProduct(inventory);

            if (logs.Count > 0)
            {
                Console.WriteLine("\nLogs:");
                foreach (var log in logs)
                {
                    Console.WriteLine(log);
                }
            }

            DisplayInventory();
        }

        static void DisplayInventory()
        {
            Console.WriteLine("\nInventory:");
            foreach (var product in inventory)
            {
                product.PrintDetails();
                Console.WriteLine();
            }
        }

        static void OrderProduct(List<Product> inventory)
        {
            OrderManager orderManager = new OrderManager();

            Console.WriteLine("\nEnter product name:");
            string productName = Console.ReadLine();
            Console.WriteLine("Enter quantity:");
            int quantity = int.Parse(Console.ReadLine());

            try
            {
                Product product = orderManager.CheckInventoryForProductName(inventory, productName);
                Order order = new Order(product, quantity);

                orderManager.ProcessOrder(inventory, order);
            }
            catch (Exception ex)
            {
                logs.Add(ex.Message);
                Console.WriteLine(ex.Message);
            }
        }
    }
}
