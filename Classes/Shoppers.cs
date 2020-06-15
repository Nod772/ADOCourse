using System.Collections.Generic;

namespace Course.Classes
{
    public class Shoppers
    {
        public Shoppers()
        {
            Salles = new List<Salles>();
        }
        public int ID { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }

        public virtual ICollection<Salles> Salles { get; set; } 
    }
}