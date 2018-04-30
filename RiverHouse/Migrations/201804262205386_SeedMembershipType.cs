using System.ComponentModel.DataAnnotations;

namespace RiverHouse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedMembershipType : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO MembershipTypes (Id, MonthlyPayment) VALUES (1, 0)");
            Sql("INSERT INTO MembershipTypes (Id, MonthlyPayment) VALUES (2, 250)");
            Sql("INSERT INTO MembershipTypes (Id, MonthlyPayment) VALUES (3, 350)");
            Sql("INSERT INTO MembershipTypes (Id, MonthlyPayment) VALUES (4, 450)");
        }
        
        public override void Down()
        {
        }
    }
}
