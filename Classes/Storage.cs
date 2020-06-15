using System.Collections.Generic;

namespace Course.Classes
{
    public class Storage
    {
        public Storage()
        {
            CashRegisters = new List<CashRegister>();
            Salles = new List<Salles>();
            Products = new List<Product>();
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public virtual ICollection<CashRegister> CashRegisters { get; set; }
        public virtual ICollection<Salles> Salles { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}