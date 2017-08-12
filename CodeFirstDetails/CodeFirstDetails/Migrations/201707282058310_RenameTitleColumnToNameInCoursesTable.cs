namespace CodeFirstDetails.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameTitleColumnToNameInCoursesTable : DbMigration
    {
        public override void Up()
        {
            //make this Column not nullable
            AddColumn("dbo.Courses", "Name", c => c.String(nullable : false));
            //before we drop the Title column we pass everything in the this column 
            //to the (New) Name Column using the Sql syntax. Bcos when this column is dropped all it's data is lost.
            Sql("UPDATE Courses SET Name = Title");
            DropColumn("dbo.Courses", "Title");
        }
        
        public override void Down()
        {   //make this Column not nullable
            AddColumn("dbo.Courses", "Title", c => c.String(nullable : false));
            //we reverse what is done in the Up() incase we want to downgrade our DB, pass Name data to Title 
            Sql("UPDATE Courses SET Title = Name");
            DropColumn("dbo.Courses", "Name");
        }
    }
}
