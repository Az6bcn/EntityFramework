namespace CodeFirstDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatePost : DbMigration
    {
        //Up---> to upgrade Db
        public override void Up()
        {
            //Create Post Table based on the Name and Property of our Model Class.
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DatePublished = c.DateTime(nullable: false),
                        Title = c.String(),
                        Body = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        //Down--> to downgrade Db
        public override void Down()
        {
            DropTable("dbo.Posts");
        }
    }
}
