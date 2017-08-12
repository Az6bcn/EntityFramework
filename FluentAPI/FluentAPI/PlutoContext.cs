using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace FluentAPI
{
    public class PlutoContext : DbContext
    {

        //change DataBaseName
        public PlutoContext() : base("PlutoContextDB2")
        {

        }

        /*  A DbSet is a collection of Objects (Model class & propperties) that represents a Table in the DB. */
        public DbSet<Course> courses { get; set; }
        public DbSet<Author> authors { get; set; }
        public DbSet<Tag> tags { get; set; }

        /*****************************CONFIGURATION USING FLUENT API***************************/
        //Method for fluent API Configuration
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //we use the ModelBuilder - call the entitiy() to get refrence to any of our classes(specified)
            modelBuilder.Entity<Course>()
                        //now we can configure our properties, which will be our Columns in SQL DBeg name, description properties etc
                        .Property(c => c.Name)
                        //make this name property required 
                        .IsRequired()
                        //and set some length on it
                        .HasMaxLength(255);
            //configure the Description property
            modelBuilder.Entity<Course>()
                       .Property(c => c.Description)
                       .IsRequired()
                       .HasMaxLength(2000);

            //************************RELATIONSHIP CONFIGURATION*************************/
            /* Override the foreignKey column in Course to how we want it  ---> by default Entity will compute it has Author_Id*/
            //To do this we have to Set/Configure the Relationship btw Course - Author (One-to-Many) from Course --> Author 
            /**Set/Configure the Relationship btw Course - Author (One-to-Many)****/
            modelBuilder.Entity<Course>()
                        //Direction Course --> Author (1Course belongs to only 1 Author)
                        .HasRequired(c => c.Author)
                        //reverse direction Course <-- Author (1 Author has many Courses)
                        .WithMany(a => a.Courses)
                        //configure Foreign Key with our declared property to be used as ForeignKey in Course class "AuthorId"
                        .HasForeignKey(k => k.AuthorId)
            //if ian Author has at least one existing Course we shldn't be able to delete that Author ( cascadeDelete = true , i.e when we delete an Author it will delete all it's courses)
                        .WillCascadeOnDelete(false); //we shldn't be able to delete an Author with atleast one existing Course
                                                     /* RECREATE INITIALMIGRATION  using the -fore switch to overwrite it: add-migration InitialModel -force */

            /** Set/Configure the Relationship btw Course - Tag (Many-to-Many) from Course --> Tag**/
            modelBuilder.Entity<Course>()
                //Direction Course --> Tag (Many Course has may Tags)
                .HasMany(c => c.Tags)
                //reverse direction Course <-- Tag (Many Tags has many Courses)
                .WithMany(t => t.Courses)
            //set the name of the intermidate table (Course-Tag) in Many-to-Many
                .Map(m =>
                {
                    //set the intermediate Table name
                    m.ToTable("CourseTags");
                    //set the intermediate Table heading Columns to prevent default Course_Id or Tag_Id)
                    //LeftCoulmn
                    m.MapLeftKey("CourseId");
                    //RightColumn
                    m.MapRightKey("TagId");

                });

            /** Set/Configure the Relationship btw Course - Cover (One-to-One) from Course (Parent)--> Tag (Child)
             Child can't exist without it parent, On adding data to DB the parent should be created first
             * **/
            modelBuilder.Entity<Course>()
               //Direction Course --> Cover (1Course has only One Cover)
               .HasRequired(c => c.Cover)
               //reverse direction Course <-- Cover i.e Cover needs it's parent(Principal)(Each Cover has a Course)
               .WithRequiredPrincipal(c => c.Course);
            base.OnModelCreating(modelBuilder);
        }


    }
}
