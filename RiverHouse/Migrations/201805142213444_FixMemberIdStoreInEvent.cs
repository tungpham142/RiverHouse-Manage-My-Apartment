namespace RiverHouse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixMemberIdStoreInEvent : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Events", "MemberCreated_Id", "dbo.Members");
            DropIndex("dbo.Events", new[] { "MemberCreated_Id" });
            RenameColumn(table: "dbo.Events", name: "MemberCreated_Id", newName: "MemberCreatedId");
            AlterColumn("dbo.Events", "MemberCreatedId", c => c.Int(nullable: false));
            CreateIndex("dbo.Events", "MemberCreatedId");
            AddForeignKey("dbo.Events", "MemberCreatedId", "dbo.Members", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Events", "MemberCreatedId", "dbo.Members");
            DropIndex("dbo.Events", new[] { "MemberCreatedId" });
            AlterColumn("dbo.Events", "MemberCreatedId", c => c.Int());
            RenameColumn(table: "dbo.Events", name: "MemberCreatedId", newName: "MemberCreated_Id");
            CreateIndex("dbo.Events", "MemberCreated_Id");
            AddForeignKey("dbo.Events", "MemberCreated_Id", "dbo.Members", "Id");
        }
    }
}
