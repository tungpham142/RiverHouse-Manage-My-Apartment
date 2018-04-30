namespace RiverHouse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMemberIdToPaymentModel : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Payments", name: "MemberCreated_Id", newName: "MemberCreatedId");
            RenameIndex(table: "dbo.Payments", name: "IX_MemberCreated_Id", newName: "IX_MemberCreatedId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Payments", name: "IX_MemberCreatedId", newName: "IX_MemberCreated_Id");
            RenameColumn(table: "dbo.Payments", name: "MemberCreatedId", newName: "MemberCreated_Id");
        }
    }
}
