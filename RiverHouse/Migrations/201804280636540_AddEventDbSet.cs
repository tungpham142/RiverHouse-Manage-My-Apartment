namespace RiverHouse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEventDbSet : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TotalAmount = c.Double(nullable: false),
                        DateCreated = c.DateTime(),
                        Description = c.String(),
                        MemberCreated_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Members", t => t.MemberCreated_Id)
                .Index(t => t.MemberCreated_Id);
            
            AddColumn("dbo.Members", "Event_Id", c => c.Int());
            CreateIndex("dbo.Members", "Event_Id");
            AddForeignKey("dbo.Members", "Event_Id", "dbo.Events", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Events", "MemberCreated_Id", "dbo.Members");
            DropForeignKey("dbo.Members", "Event_Id", "dbo.Events");
            DropIndex("dbo.Members", new[] { "Event_Id" });
            DropIndex("dbo.Events", new[] { "MemberCreated_Id" });
            DropColumn("dbo.Members", "Event_Id");
            DropTable("dbo.Events");
        }
    }
}
