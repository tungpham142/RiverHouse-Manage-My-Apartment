namespace RiverHouse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateModelAddNewEventModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Members", "Payment_Id", "dbo.Payments");
            DropIndex("dbo.Members", new[] { "Payment_Id" });
            RenameColumn(table: "dbo.Payments", name: "MemberCreatedId", newName: "MemberId");
            RenameIndex(table: "dbo.Payments", name: "IX_MemberCreatedId", newName: "IX_MemberId");
            AddColumn("dbo.Payments", "Amount", c => c.Double(nullable: false));
            AlterColumn("dbo.Payments", "DateCreated", c => c.DateTime(nullable: false));
            DropColumn("dbo.Members", "Payment_Id");
            DropColumn("dbo.Payments", "TotalAmount");
            DropColumn("dbo.Payments", "SeparateAmount");
            DropColumn("dbo.Payments", "Description");
            DropColumn("dbo.Payments", "NumberOfPayer");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Payments", "NumberOfPayer", c => c.Byte(nullable: false));
            AddColumn("dbo.Payments", "Description", c => c.String());
            AddColumn("dbo.Payments", "SeparateAmount", c => c.Double(nullable: false));
            AddColumn("dbo.Payments", "TotalAmount", c => c.Double(nullable: false));
            AddColumn("dbo.Members", "Payment_Id", c => c.Int());
            AlterColumn("dbo.Payments", "DateCreated", c => c.DateTime());
            DropColumn("dbo.Payments", "Amount");
            RenameIndex(table: "dbo.Payments", name: "IX_MemberId", newName: "IX_MemberCreatedId");
            RenameColumn(table: "dbo.Payments", name: "MemberId", newName: "MemberCreatedId");
            CreateIndex("dbo.Members", "Payment_Id");
            AddForeignKey("dbo.Members", "Payment_Id", "dbo.Payments", "Id");
        }
    }
}
