namespace RiverHouse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNewPaymentAttrForCreateNewPayment : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Payments", "DateCreated", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Payments", "DateCreated", c => c.DateTime(nullable: false));
        }
    }
}
