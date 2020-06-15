namespace Course.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ListProduct : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Storage_ID", c => c.Int());
            CreateIndex("dbo.Products", "Storage_ID");
            AddForeignKey("dbo.Products", "Storage_ID", "dbo.Storages", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "Storage_ID", "dbo.Storages");
            DropIndex("dbo.Products", new[] { "Storage_ID" });
            DropColumn("dbo.Products", "Storage_ID");
        }
    }
}
