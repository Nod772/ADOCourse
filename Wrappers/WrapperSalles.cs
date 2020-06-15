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
    public class WrapperSalles : Wrapper<Salles>
    {
        TestModel context = null;
        public new DbSet<Salles> Set { get; set; }

        public WrapperSalles(TestModel model) : base(model)
        {
            context = model;
            Set = model.Salles;
        }
        public override void Delete(Salles item)
        {
            var forDelete = Set.FirstOrDefault<Salles>(x => x.ID == (item.ID));
            context.Entry(forDelete).State = System.Data.Entity.EntityState.Deleted;
            Commit();
        }
        public IEnumerable<object> GetSalles()
        {
            var p = from item in Set.ToList()
                    select new
                    {

                        Price = item.Price,
                        DateOfSalles = item.DateOfSalles,
                        CashRegister = item.CashRegister.Name,
                        Shoppers = item.Shoppers.Name,
                        Storage = item.Storage.Name


                    };
            return p;
        }
    }
}
