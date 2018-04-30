namespace RiverHouse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateModelAddMemberClassToPayMent : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Payments", "Member_Id", "dbo.Members");
            DropIndex("dbo.Payments", new[] { "Member_Id" });
            RenameColumn(table: "dbo.Payments", name: "Member_Id", newName: "MemberCreated_Id");
            AddColumn("dbo.Members", "PhoneNumber", c => c.String());
            AddColumn("dbo.Members", "Payment_Id", c => c.Byte());
            AddColumn("dbo.Payments", "TotalAmount", c => c.Double(nullable: false));
            AddColumn("dbo.Payments", "SeparateAmount", c => c.Double(nullable: false));
            AddColumn("dbo.Payments", "DateCreated", c => c.DateTime(nullable: false));
            AddColumn("dbo.Payments", "Description", c => c.String());
            AddColumn("dbo.Payments", "IsPaid", c => c.Boolean(nullable: false));
            AddColumn("dbo.Payments", "NumberOfPayer", c => c.Byte(nullable: false));
            AlterColumn("dbo.Payments", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Payments", "MemberCreated_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Members", "Payment_Id");
            CreateIndex("dbo.Payments", "MemberCreated_Id");
            AddForeignKey("dbo.Members", "Payment_Id", "dbo.Payments", "Id");
            AddForeignKey("dbo.Payments", "MemberCreated_Id", "dbo.Members", "Id", cascadeDelete: true);
            DropColumn("dbo.Payments", "Amount");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Payments", "Amount", c => c.Double(nullable: false));
            DropForeignKey("dbo.Payments", "MemberCreated_Id", "dbo.Members");
            DropForeignKey("dbo.Members", "Payment_Id", "dbo.Payments");
            DropIndex("dbo.Payments", new[] { "MemberCreated_Id" });
            DropIndex("dbo.Members", new[] { "Payment_Id" });
            AlterColumn("dbo.Payments", "MemberCreated_Id", c => c.Int());
            AlterColumn("dbo.Payments", "Name", c => c.String());
            DropColumn("dbo.Payments", "NumberOfPayer");
            DropColumn("dbo.Payments", "IsPaid");
            DropColumn("dbo.Payments", "Description");
            DropColumn("dbo.Payments", "DateCreated");
            DropColumn("dbo.Payments", "SeparateAmount");
            DropColumn("dbo.Payments", "TotalAmount");
            DropColumn("dbo.Members", "Payment_Id");
            DropColumn("dbo.Members", "PhoneNumber");
            RenameColumn(table: "dbo.Payments", name: "MemberCreated_Id", newName: "Member_Id");
            CreateIndex("dbo.Payments", "Member_Id");
            AddForeignKey("dbo.Payments", "Member_Id", "dbo.Members", "Id");
        }
    }
}
