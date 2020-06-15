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
    public class WrapperShopers : Wrapper<Shoppers>
    {
        TestModel context = null;
        public new DbSet<Shoppers> Set { get; set; }

        public WrapperShopers(TestModel model) : base(model)
        {
            context = model;
            Set = model.Shoppers;
        }
        public override void Delete(Shoppers item)
        {
            var forDelete = Set.FirstOrDefault<Shoppers>(x => x.ID == (item.ID));
            context.Entry(forDelete).State = System.Data.Entity.EntityState.Deleted;
            Commit();
        }
    }
}
