namespace Course.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Second1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Salles", "Price", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Salles", "Price");
        }
    }
}
