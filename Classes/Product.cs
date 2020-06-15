using Course.Classes;
using System.Collections.Generic;

namespace Course
{
    public class Product
    {
        public Product()
        {
            Category = new Category();
            Storages = new List<Storage>();
            Count = 0;
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public double SellingPrice { get; set; }
        public int Count { get; set; }
        public int IDCategory { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<Storage> Storages { get; set; }
    }
}