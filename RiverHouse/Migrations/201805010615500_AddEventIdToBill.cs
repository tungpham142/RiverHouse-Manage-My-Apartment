namespace RiverHouse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEventIdToBill : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bills", "EventId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Bills", "EventId");
        }
    }
}
