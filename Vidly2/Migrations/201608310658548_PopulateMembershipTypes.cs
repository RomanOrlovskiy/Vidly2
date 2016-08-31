namespace Vidly2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMembershipTypes : DbMigration
    {
        public override void Up()
        {

            /* Inserting data in Db
             The purpose of this migration is to initialize the
             MembershipTypes table in ServerExplorer/Tables/.
                The records of this table should be consistent across
             different environments, so Development Database,
             Testing Database and Production Database all should
             have exact same MembershipTypes. 
                To inssure this consistensy with the code-first
             approach we should only change this database using
             migrations. */
            
            Sql("INSERT INTO MembershipTypes (Id, SignUpFee, DurationInMonth, DiscountRate) VALUES (1, 0, 0, 0)");
            Sql("INSERT INTO MembershipTypes (Id, SignUpFee, DurationInMonth, DiscountRate) VALUES (2, 30, 1, 10)");
            Sql("INSERT INTO MembershipTypes (Id, SignUpFee, DurationInMonth, DiscountRate) VALUES (3, 90, 3, 15)");
            Sql("INSERT INTO MembershipTypes (Id, SignUpFee, DurationInMonth, DiscountRate) VALUES (4, 300, 12, 20)");
            //Run "update-database" after those changes 
        }

        public override void Down()
        {
        }
    }
}
