namespace RiverHouse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGuestCountToEventModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "GuestCount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Events", "GuestCount");
        }
    }
}
