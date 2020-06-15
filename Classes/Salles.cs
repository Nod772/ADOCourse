using System;
using System.Collections.Generic;

namespace Course.Classes
{
    public class Salles
    {
        public int ID { get; set; }
        public DateTime DateOfSalles { get; set; }
        public double Price { get; set; }
        public Salles()
        {
            CashRegister = new CashRegister();
            Storage = new Storage();
            Shoppers = new Shoppers();
            Products = new List<Product>();
        }

        public virtual CashRegister CashRegister { get; set; }
        public virtual Storage Storage { get; set; }
        public virtual Shoppers Shoppers { get; set; }
        public virtual ICollection<Product>  Products { get; set; }

    }
}