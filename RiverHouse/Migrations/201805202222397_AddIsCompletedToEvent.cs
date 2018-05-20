namespace RiverHouse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsCompletedToEvent : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "IsCompleted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Events", "IsCompleted");
        }
    }
}
