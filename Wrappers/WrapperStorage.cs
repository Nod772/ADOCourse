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
    public class WrapperStorage : Wrapper<Storage>
    {
        TestModel context = null;
        public new DbSet<Storage> Set { get; set; }

        public WrapperStorage(TestModel model) : base(model)
        {
            context = model;
            Set = model.Storages;
        }
        public WrapperStorage() 
        {
            context = new TestModel();
            Set = context.Storages;
        }
        public override void Delete(Storage item)
        {
            var forDelete = Set.FirstOrDefault<Storage>(x => x.ID == (item.ID));
            context.Entry(forDelete).State = System.Data.Entity.EntityState.Deleted;
            Commit();
        }
        public List<string> GetStorageNames()
        {
            return (from item in Set
                    select item.Name).ToList();
        }
        public IEnumerable<Product> GetProducts(int idCategory, int idStorage)
        {
          
            Storage st = Set.FirstOrDefault(x => x.ID == idStorage);
            var p= st.Products.Where(x=>x.IDCategory==idCategory).ToList();
            return p;

        }
    }
}
