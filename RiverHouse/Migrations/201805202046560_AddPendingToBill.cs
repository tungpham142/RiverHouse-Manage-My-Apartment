namespace RiverHouse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPendingToBill : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bills", "Pending", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Bills", "Pending");
        }
    }
}
