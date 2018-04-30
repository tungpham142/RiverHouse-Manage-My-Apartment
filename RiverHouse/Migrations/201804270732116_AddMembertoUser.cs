namespace RiverHouse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMembertoUser : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "Member_Id", "dbo.Members");
            DropIndex("dbo.AspNetUsers", new[] { "Member_Id" });
            RenameColumn(table: "dbo.AspNetUsers", name: "Member_Id", newName: "MemberId");
            AlterColumn("dbo.AspNetUsers", "MemberId", c => c.Int(nullable: false));
            CreateIndex("dbo.AspNetUsers", "MemberId");
            AddForeignKey("dbo.AspNetUsers", "MemberId", "dbo.Members", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "MemberId", "dbo.Members");
            DropIndex("dbo.AspNetUsers", new[] { "MemberId" });
            AlterColumn("dbo.AspNetUsers", "MemberId", c => c.Int());
            RenameColumn(table: "dbo.AspNetUsers", name: "MemberId", newName: "Member_Id");
            CreateIndex("dbo.AspNetUsers", "Member_Id");
            AddForeignKey("dbo.AspNetUsers", "Member_Id", "dbo.Members", "Id");
        }
    }
}
