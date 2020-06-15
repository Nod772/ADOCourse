using Course.BLL;
using Course.Classes;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course.Wrappers
{
    public class Wrapper_CashRegister : Wrapper<CashRegister>
    {
        TestModel context = null;
        public new DbSet<CashRegister> Set { get; set; }

        public Wrapper_CashRegister(TestModel model) : base(model)
        {
            context = model;
            Set = model.CashRegisters;
        }
        public override void Delete(CashRegister item)
        {
            var forDelete = Set.FirstOrDefault<CashRegister>(x => x.ID == (item.ID));
            context.Entry(forDelete).State = System.Data.Entity.EntityState.Deleted;
            Commit();
        }
        public IEnumerable<CashRegister> GetCategories()
        {
            return Set.ToList();
        }
        public IEnumerable<CashRegister> GetCashFromStorages(int id)
        {
            return Set.Where(x => x.ID == id).ToList();
        }
        public void AddCash(int id,double value)
        {
            CashRegister cash = Set.FirstOrDefault(x => x.ID == id);
            cash.RemainderMoney += value;
            Commit();
        }
    }
}
