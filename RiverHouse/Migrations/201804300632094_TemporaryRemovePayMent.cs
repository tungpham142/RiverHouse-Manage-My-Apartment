namespace RiverHouse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TemporaryRemovePayMent : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Payments", "MemberId", "dbo.Members");
            DropIndex("dbo.Payments", new[] { "MemberId" });
            DropTable("dbo.Payments");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        PaidFor = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                        MemberId = c.Int(nullable: false),
                        Amount = c.Double(nullable: false),
                        IsPaid = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.Payments", "MemberId");
            AddForeignKey("dbo.Payments", "MemberId", "dbo.Members", "Id", cascadeDelete: true);
        }
    }
}
