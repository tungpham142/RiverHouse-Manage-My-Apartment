namespace RiverHouse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNameOfPersonWhoPaidTheBill : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bills", "PaidBy", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Bills", "PaidBy");
        }
    }
}
