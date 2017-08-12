using System.Linq;
using System.Data.Entity;
using System.Collections;
using System;

namespace Vidzy
{
    class Program
    {
        static void Main(string[] args)
        {
            //Initialise the Context
            VidzyContext dbContext = new VidzyContext();

            //Action Movies Sorted by Name:

            var actionMovies = dbContext.Videos
                .Where(g => g.Genre.Name == "Action")
                .OrderBy(m => m.Name).ToList();

            Console.WriteLine("Action Movies Order by Name: ");
            foreach (var actionMovie in actionMovies)
            {
                Console.WriteLine(actionMovie.Name);
            }


            //Gold drama movies sorted by release date (newest first)
            var GoldDrama = dbContext.Videos
                .Where(g => g.Genre.Name == "Drama" && g.Classification == Classification.Gold)
                .OrderBy(rd => rd.ReleaseDate).ToList();


            Console.WriteLine("Gold drama movies sorted by release date: ");
            foreach (var gMovie in GoldDrama)
            {
                Console.WriteLine(gMovie.Name + " -->" + gMovie.ReleaseDate);
            }

            //All movies projected into an anonymous type with two properties: MovieName and Genre
            var AllMovies = dbContext.Videos
                .Select(o => new             //project all videos (videosList) into an anonymous type
                {
                    MovieName = o.Name,
                    Genre = o.Genre.Name
                });

            Console.WriteLine("All movies projected into an anonymous type with two properties: MovieName and Genre: ");
            foreach (var Movie in AllMovies)
            {
                Console.WriteLine(Movie.MovieName + " -->" + Movie.Genre);
            }


            //All movies grouped by their classification: Project the group into a new
            //anonymous type with two properties: Classification(string), Movies

            var GroupByClassification = dbContext.Videos
                .GroupBy(c => c.Classification)
                .Select(o => new        //project the group into an anonymous type (o), with o we can get the Key of the group
                {
                    ClassificationName = o.Key,
                    Movies = o.OrderBy(c => c.Name) //The group variable (c) can be used to get all videos in that group.
                }).ToList();

            //Iterate the List of groups based/grouped by their classification
            foreach (var g in GroupByClassification)
            {
                Console.WriteLine("Classification is: " + g.ClassificationName);

                Console.WriteLine("movies :");

                //Iterate the List of Objects in each group
                foreach (var m in g.Movies)
                {
                    Console.WriteLine(m.Name);
                }
            }


            /*List of classifications sorted alphabetically and count of videos in them 
            ----> To do this, group the videos by classification and count the movie in each group*/
            var ClassificationList = dbContext.Videos
                .GroupBy(c => c.Classification)
                .Select(o => new
                {
                    ClassificationName = o.Key,
                    //VideosCount = o.OrderBy(c => c.Name).Count() //counts the names of videos in the group
                    VideosCount = o.Count() //counts the list of video in the group
                });

            foreach (var g in ClassificationList)
            {
                Console.WriteLine("Classification Name: " + g.ClassificationName);

                Console.WriteLine("Movies Count :" + g.VideosCount);

                
            }

            /*List of genres and number of videos they include, sorted by the number of videos.
             * ----> get the list of Videos, then group it by Genres and count the videos in each genre group */

            var genresListSorted = dbContext.Videos
                .GroupBy(g => g.Genre)      //group it by Genres
                .Select(o => new
                {
                    GenresName = o.Key, 
                    VideosCountGenres = o.Count()  //count the videos in each genre group
                })
                .OrderBy(g => g.VideosCountGenres); //sorted by the number of videos

            Console.WriteLine("******************************************" );
            foreach (var g in genresListSorted)
            {
                Console.WriteLine("Genre Name: " + g.GenresName.Name);
                
                Console.WriteLine("Movies Count :" + g.VideosCountGenres);


            }

            Console.ReadLine();
        }
    }
}
