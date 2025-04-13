using System;
using System.Collections.Generic;

namespace Exeption
{
    public class OrderManager
    {
        public Product CheckInventoryForProductName(List<Product> inventory, string productName)
        {
            foreach (var product in inventory)
            {
                if (product.Name.Equals(productName, StringComparison.OrdinalIgnoreCase))
                {
                    return product; 
                }
            }

            throw new KeyNotFoundException("Error: Product not found in inventory.");
        }

        public void ProcessOrder(List<Product> inventory, Order order)
        {
            try
            {
                Product product = CheckInventoryForProductName(inventory, order.Product.Name);

               
                if (order.Quantity > product.Stock)
                {
                    throw new InvalidOperationException("Error: Insufficient stock.");
                }

                
                product.UpdateStock(-order.Quantity); 
            }
            catch (Exception ex)
            {
                
                Console.WriteLine(ex.Message);
            }
        }
    }
}
