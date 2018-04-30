namespace RiverHouse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNameToEventModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Events", "Name");
        }
    }
}
