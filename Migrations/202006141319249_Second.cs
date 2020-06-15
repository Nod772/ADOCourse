namespace Course.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Second : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CashRegisters", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CashRegisters", "Name");
        }
    }
}
