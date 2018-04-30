namespace RiverHouse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIdToPaymentDto : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Members", "Payment_Id", "dbo.Payments");
            DropIndex("dbo.Members", new[] { "Payment_Id" });
            AlterColumn("dbo.Members", "Payment_Id", c => c.Int());
            AlterColumn("dbo.Payments", "Id", c => c.Int(nullable: false, identity: true));
            CreateIndex("dbo.Members", "Payment_Id");
            AddForeignKey("dbo.Members", "Payment_Id", "dbo.Payments", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Members", "Payment_Id", "dbo.Payments");
            DropIndex("dbo.Members", new[] { "Payment_Id" });
            AlterColumn("dbo.Payments", "Id", c => c.Byte(nullable: false));
            AlterColumn("dbo.Members", "Payment_Id", c => c.Byte());
            CreateIndex("dbo.Members", "Payment_Id");
            AddForeignKey("dbo.Members", "Payment_Id", "dbo.Payments", "Id");
        }
    }
}
