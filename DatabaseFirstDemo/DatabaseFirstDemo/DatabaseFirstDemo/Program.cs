using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseFirstDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //instance of our DbContext class
            DatabaseFirstDemoEntities db = new DatabaseFirstDemoEntities();

            //instantiate our Post mModel class and create new post
            var post = new Post()
            {
                Body = "Body",
                DatePublished = DateTime.Now,
                Title = "Title",
                //we don't REALLY need to specify the ID
                PostID = 1
            };
            // DbSet<Post> Posts --> we use Post to refrence our Table and perform CRUD Operation
            db.Posts.Add(post);
            //commit to the database
            db.SaveChanges();

        }
    }
}
