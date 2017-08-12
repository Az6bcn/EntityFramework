using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VidzyCodeFirst
{
    class Program
    {
        /*Started with Many-to-Many and later changed to One-to-Many*/
        public class Video
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public DateTime ReleaseDate { get; set; }
            //Has a Genre property--> One-to-Many
            public Genre genre { get; set; }
            //Has a list of Genre --> Many-to-Many
            //public IList<Genre> genres { get; set; }
        }

        public class Genre
        {
            public int Id { get; set; }
            public string Name { get; set; }
            //Has a list of Video
            public IList<Video> videos { get; set; }
        }

        //Context class to access the db
        public class vidzyContext : DbContext
        {
            //rename my DBName
            public vidzyContext() : base ("VidzyCodeFirstDB")
            {

            }
            //declare model classes as DbSets 
            public DbSet<Video> videos { get; set; }
            public DbSet<Genre> genres { get; set; }
        }
        static void Main(string[] args)
        {
            //instantiate the context class
            vidzyContext db = new vidzyContext();

            /* For many to many---> populate data into the DB, creates new Video with it's corresponding Genre
           
            //instantiate and creates a new video with the list of Genre it has. 
            Video v1 = new Video
            {
                Name = "Ronaldinho best moves",
                ReleaseDate = DateTime.Now,
                //has a genresList-- > instantiate a list of Genre
                genres = new List<Genre>()
                {
                    //instantiate and creates a new genre for this present list --> creates a new genre in the DB
                    new Genre()
                    {
                        Name = "Horror"

                    }
                }
            };

            //add to the db
            db.videos.Add(v1);
            //commit to db
            db.SaveChanges(); */



            /* For One-to-Many */
            ////instantiate the video class 
            //Video v1 = new Video
            //{
            //    Name = "Ronaldinho best moves",
            //    ReleaseDate = DateTime.Now,
            //};
            //instantiate and creates a new genre and add the book that belongs to into in it. 
            Genre g1 = new Genre
            {
                Name = "XXX",
                videos = new List<Video>()
                {
                    //instantiate and create a new Video for this genre
                    new Video(){
                    Name = "Ronaldinho best moves",
                    ReleaseDate = DateTime.Now,
                    }
                }
            };

            //add to the db
            db.genres.Add(g1);
            //commit to db
            db.SaveChanges(); 
        }
    }
}
