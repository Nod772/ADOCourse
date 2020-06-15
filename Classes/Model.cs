using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course.Classes
{
    public class TestModel : DbContext
    {
        public TestModel() : base("name=Course")
        {

            Database.SetInitializer<TestModel>(new CreateDatabaseIfNotExists<TestModel>());
        }
       public virtual DbSet<CashRegister> CashRegisters { get; set; }
       public virtual DbSet<Category> Categories  { get; set; }
       public virtual DbSet<Product>  Products { get; set; }
       public virtual DbSet<Salles> Salles  { get; set; }
       public virtual DbSet<Shoppers> Shoppers  { get; set; }
       public virtual DbSet<Storage> Storages  { get; set; }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>().HasRequired(x => x.Category).WithMany(z => z.Products).WillCascadeOnDelete(true);
  }
    }
}
