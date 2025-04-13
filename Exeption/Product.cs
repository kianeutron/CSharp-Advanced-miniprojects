using System;

namespace Exeption
{
    public class Product
    {
        public string Name { get; private set; }
        public int Stock { get; private set; }
        public decimal Price { get; private set; }

        public Product(string name, int stock, decimal price)
        {
            Name = name;
            Stock = stock;
            Price = price;
        }

        public void PrintDetails()
        {
            Console.WriteLine($"Product: {Name}");
            Console.WriteLine($"Price: {Price:C}");
            Console.WriteLine($"Current Stock: {Stock}");
        }

        public void UpdateStock(int amount)
        {
            if (Stock + amount < 0)
            {
                throw new ArgumentException("Error: Amount exceeds stock.");
            }

            Stock += amount;
        }
    }
}
