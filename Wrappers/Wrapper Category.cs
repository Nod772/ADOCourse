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

    public class Wrapper_Category : Wrapper<Category>
    {
        TestModel context = null;
        public new DbSet<Category> Set { get; set; }

        public Wrapper_Category(TestModel model) : base(model)
        {
            context = model;
            Set = model.Categories;
        }
        public override void Delete(Category item)
        {
            var forDelete = Set.FirstOrDefault<Category>(x => x.ID == (item.ID));
            context.Entry(forDelete).State = System.Data.Entity.EntityState.Deleted;
            Commit();
        }
        public IEnumerable<Category> GetCategories()
        {
            return Set.ToList();
        }

        public IEnumerable<Product> GetProducts(int idCategory)
        {
            TestModel test = new TestModel();
            Category ct= Set.FirstOrDefault(x=>x.ID== idCategory);
          
            return ct.Products;
        }
    }
}
