using System;

namespace  Exeption
{
    public class Order
    {
        public Product Product { get; private set; } 
        public int Quantity { get; private set; }   

        public Order(Product product, int quantity)
        {
            Product = product;  
            Quantity = quantity; 
        }
    }
}
