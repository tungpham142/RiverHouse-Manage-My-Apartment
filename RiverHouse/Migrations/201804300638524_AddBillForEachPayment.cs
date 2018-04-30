namespace RiverHouse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBillForEachPayment : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bills",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        PaidFor = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                        Amount = c.Double(nullable: false),
                        MemberId = c.Int(nullable: false),
                        IsPaid = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Bills");
        }
    }
}
