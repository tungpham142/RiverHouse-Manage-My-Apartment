namespace RiverHouse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTotalRemainToEvent : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "TotalRemain", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Events", "TotalRemain");
        }
    }
}
