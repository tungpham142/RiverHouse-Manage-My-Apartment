namespace RiverHouse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixPayMentClass : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Payments", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Payments", "Name", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Payments", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Payments", "Name", c => c.String(nullable: false));
        }
    }
}
