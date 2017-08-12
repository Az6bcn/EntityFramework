namespace VidzyCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TablesContextCreatedAndSqlDataPopulation : DbMigration
    {
        public override void Up()
        {
            //Use SQL syntax to insert data
            Sql("INSERT INTO Genres (Name) VALUES ('Horror') ");
            Sql("INSERT INTO Genres (Name) VALUES ('Comedy') ");
            Sql("INSERT INTO Genres (Name) VALUES ('Action') ");
            Sql("INSERT INTO Genres (Name) VALUES ('Thriller') ");
            Sql("INSERT INTO Genres (Name) VALUES ('Family') ");
            Sql("INSERT INTO Genres (Name) VALUES ('Romance') ");
            //Update the DB --> Update-Database
        }

        public override void Down()
        {
        }
    }
}
