namespace Vidly2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenresTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (Id, Name) VALUES (1, 'Action')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (2, 'Comedy')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (3, 'Romance')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (4, 'Family')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (5, 'Thriller')");
        }
        
        public override void Down()
        {
        }
    }
}
