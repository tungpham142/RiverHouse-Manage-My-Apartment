namespace RiverHouse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddForeignKeyToPaymentId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Members", "Payment_Id", "dbo.Payments");
            DropPrimaryKey("dbo.Payments");
            AlterColumn("dbo.Payments", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Payments", "Id");
            AddForeignKey("dbo.Members", "Payment_Id", "dbo.Payments", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Members", "Payment_Id", "dbo.Payments");
            DropPrimaryKey("dbo.Payments");
            AlterColumn("dbo.Payments", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Payments", "Id");
            AddForeignKey("dbo.Members", "Payment_Id", "dbo.Payments", "Id");
        }
    }
}
