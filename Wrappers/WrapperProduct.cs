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
    public class WrapperProduct : Wrapper<Product>
    {
        TestModel context = null;
        public new DbSet<Product> Set { get; set; }

        public WrapperProduct(TestModel model) : base(model)
        {
            context = model;
            Set = model.Products;
        }
        public override void Delete(Product item)
        {
            var forDelete = Set.FirstOrDefault<Product>(x => x.ID == (item.ID));
            context.Entry(forDelete).State = System.Data.Entity.EntityState.Deleted;
            Commit();
        }
       
        public void SellProduct(int id,int count)
        {
            Product p = Set.FirstOrDefault(x => x.ID == id);
            p.Count -= count;
            Commit();
        }
    }
}
