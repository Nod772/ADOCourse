namespace Course.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ListProduct2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "Storage_ID", "dbo.Storages");
            DropIndex("dbo.Products", new[] { "Storage_ID" });
            CreateTable(
                "dbo.ProductStorages",
                c => new
                    {
                        Product_ID = c.Int(nullable: false),
                        Storage_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Product_ID, t.Storage_ID })
                .ForeignKey("dbo.Products", t => t.Product_ID, cascadeDelete: true)
                .ForeignKey("dbo.Storages", t => t.Storage_ID, cascadeDelete: true)
                .Index(t => t.Product_ID)
                .Index(t => t.Storage_ID);
            
            DropColumn("dbo.Products", "Storage_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "Storage_ID", c => c.Int());
            DropForeignKey("dbo.ProductStorages", "Storage_ID", "dbo.Storages");
            DropForeignKey("dbo.ProductStorages", "Product_ID", "dbo.Products");
            DropIndex("dbo.ProductStorages", new[] { "Storage_ID" });
            DropIndex("dbo.ProductStorages", new[] { "Product_ID" });
            DropTable("dbo.ProductStorages");
            CreateIndex("dbo.Products", "Storage_ID");
            AddForeignKey("dbo.Products", "Storage_ID", "dbo.Storages", "ID");
        }
    }
}
