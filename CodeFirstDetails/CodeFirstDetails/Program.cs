using System.Collections.Generic;
using System.Data.Entity;

namespace CodeFirstDetails
{
    public class Program
    {
        //One -to-Many Relationship between Courses and Author
        public class Course
        {
            public int Id { get; set; }
            //Renamed Title to Name
            //After adding the migration before we drop the Title column we pass everything in the this column 
            //to the (New) Name Column using the Sql syntax. Bcos when this column is dropped all it's data is lost.
            public string Name { get; set; }
            public string Description { get; set; }
            public CourseLevel Level { get; set; }
            public float FullPrice { get; set; }
            //Added property
            public System.DateTime DatePublished { get; set; } //ublic System.DateTime? nullable DatePublished { get; set; } --> to create a nullable DatePublished property
            //Author == Navigation property to refrence Author of a course 
            // FK => creates FK using the Author_id automatically
            public Author Author { get; set; }
            public Category Category { get; set; }
            //Tag == Navigation property to Tag Model , Course has a list of tags
            public IList<Tag> Tags { get; set; }

        }

        public class Author
        {
            public int Id { get; set; }
            public string Name { get; set; }
            //List of Courses
            public IList<Course> Courses { get; set; }
        }

        //Many -to-Many Relationship between Courses and Tag
        public class Tag
        {
            public int Id { get; set; }
            public string  Name { get; set; }
            //List of Courses
            public IList<Course> Courses { get; set; }
        }

        public enum CourseLevel
        {
            Beginner = 1,
            Intermediate = 2,
            Advanced = 3
        }

        //New class ---> Category and register it in the context class and then add a new migration for this modification
        public class Category
        {
            public int Id { get; set; }
            public string  Name { get; set; }
        }

        public class PlutoContext : DbContext
        {
            //change DataBaseName
            public PlutoContext() : base("PlutoContextDB")
            {

            }

            /*  A DbSet is a collection of Objects (Model class & propperties) that represents a Table in the DB. */
            public DbSet<Course> courses { get; set; }
            public DbSet<Author> authors { get; set; }
            public DbSet<Tag> tags { get; set; }
            //add new class to context   ---> then add a new migration for this modification
            public DbSet<Category> Categories { get; set; }

        }


        static void Main(string[] args)
        {
        }
    }
}
