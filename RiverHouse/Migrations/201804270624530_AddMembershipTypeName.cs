namespace RiverHouse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMembershipTypeName : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MembershipTypes SET Name = 'Regular' Where Id = 1");
            Sql("UPDATE MembershipTypes SET Name = 'Junior' Where Id = 2");
            Sql("UPDATE MembershipTypes SET Name = 'Senior' Where Id = 3");
            Sql("UPDATE MembershipTypes SET Name = 'Master' Where Id = 4");
        }
        
        public override void Down()
        {
        }
    }
}
