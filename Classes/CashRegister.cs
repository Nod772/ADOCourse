using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course.Classes
{
    public class CashRegister
    {
        public CashRegister()
        {
            Storage = new Storage();
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public string Currency { get; set; }
        public double RemainderMoney { get; set; }
        
        public virtual Storage Storage { get; set; }
    
    }
}
