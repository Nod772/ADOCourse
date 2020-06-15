namespace Course.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CashRegisters",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Currency = c.String(),
                        RemainderMoney = c.Double(nullable: false),
                        Storage_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Storages", t => t.Storage_ID)
                .Index(t => t.Storage_ID);
            
            CreateTable(
                "dbo.Storages",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Salles",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        DateOfSalles = c.DateTime(nullable: false),
                        CashRegister_ID = c.Int(),
                        Shoppers_ID = c.Int(),
                        Storage_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.CashRegisters", t => t.CashRegister_ID)
                .ForeignKey("dbo.Shoppers", t => t.Shoppers_ID)
                .ForeignKey("dbo.Storages", t => t.Storage_ID)
                .Index(t => t.CashRegister_ID)
                .Index(t => t.Shoppers_ID)
                .Index(t => t.Storage_ID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Double(nullable: false),
                        SellingPrice = c.Double(nullable: false),
                        Count = c.Int(nullable: false),
                        Category_ID = c.Int(),
                        Salles_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Categories", t => t.Category_ID)
                .ForeignKey("dbo.Salles", t => t.Salles_ID)
                .Index(t => t.Category_ID)
                .Index(t => t.Salles_ID);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Shoppers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Phone = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Salles", "Storage_ID", "dbo.Storages");
            DropForeignKey("dbo.Salles", "Shoppers_ID", "dbo.Shoppers");
            DropForeignKey("dbo.Products", "Salles_ID", "dbo.Salles");
            DropForeignKey("dbo.Products", "Category_ID", "dbo.Categories");
            DropForeignKey("dbo.Salles", "CashRegister_ID", "dbo.CashRegisters");
            DropForeignKey("dbo.CashRegisters", "Storage_ID", "dbo.Storages");
            DropIndex("dbo.Products", new[] { "Salles_ID" });
            DropIndex("dbo.Products", new[] { "Category_ID" });
            DropIndex("dbo.Salles", new[] { "Storage_ID" });
            DropIndex("dbo.Salles", new[] { "Shoppers_ID" });
            DropIndex("dbo.Salles", new[] { "CashRegister_ID" });
            DropIndex("dbo.CashRegisters", new[] { "Storage_ID" });
            DropTable("dbo.Shoppers");
            DropTable("dbo.Categories");
            DropTable("dbo.Products");
            DropTable("dbo.Salles");
            DropTable("dbo.Storages");
            DropTable("dbo.CashRegisters");
        }
    }
}
