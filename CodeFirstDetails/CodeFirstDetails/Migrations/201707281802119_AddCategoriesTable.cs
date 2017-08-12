namespace CodeFirstDetails.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCategoriesTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            //Use SQL syntax to insert data
            Sql("INSERT INTO Categories (Name) VALUES ('Web Development') ");
            Sql("INSERT INTO Categories (Name) VALUES ('Mobile Development') ");
            //Update the DB --> Update-Database
        }
        
        public override void Down()
        {
            DropTable("dbo.Categories");
        }
    }
}
