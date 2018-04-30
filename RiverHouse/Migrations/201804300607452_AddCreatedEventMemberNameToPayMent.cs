namespace RiverHouse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCreatedEventMemberNameToPayMent : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Payments", "PaidFor", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Payments", "PaidFor");
        }
    }
}
