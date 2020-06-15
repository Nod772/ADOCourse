namespace Course.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ListProduct3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "IDCategory", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "IDCategory");
        }
    }
}
