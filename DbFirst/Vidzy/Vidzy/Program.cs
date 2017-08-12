using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Relationship examples and how to instantiate them
//https://www.infragistics.com/community/blogs/dhananjay_kumar/archive/2015/10/21/how-to-create-relationships-between-entities-in-the-entity-framework-code-first-approach.aspx
namespace Vidzy
{
    //Classification Enum
    public enum Classification : byte
    {
        Silver = 1,
        Gold = 2,
        Platinuim = 3
    }
    public class Program
    {
        

        static void Main(string[] args)
        {
/*************************************************Many 2 Many***********************************/
            //            VidzyEntities context = new VidzyEntities();
            ///**Creating manually the data of Video and Genre **/
            //            //Instantiate Video
            //            Video v1 = new Video()
            //            {
            //                Name = "Iron Fist",
            //                ReleaseDate = DateTime.Now,
            //            };


            //            //Instantiate the Genre class, *the Video that it belongs to will be added when yu add it to a video*  
            //            //Genre g = new Genre {
            //            //    Name = "Horror",
            //            //};
            //            Genre g2 = new Genre
            //            {
            //                Name = "YorubaAction",
            //            };

            //            //add the Genre to the Video GenreList
            //            //v1.Genres.Add(g);
            //            v1.Genres.Add(g2);
            //            //add video to DB using the stored procedure imported as method
            //            context.Videos.Add(v1);
            //            context.SaveChanges();




            ///* add using the stored procedure imported as a Method with 3 parameters */
            //            //context.AddVideo("Empire", DateTime.Now, "Action");



/******************************************* One 2 Many*************************************/

            VidzyEntities context = new VidzyEntities();
            /**Creating manually the data of Video and Genre **/
            //Instantiate Video y le paso la GenreId de la categoria que pertenecera
            Video v1 = new Video()
            {
                Name = "Witches2-5",
                ReleaseDate = DateTime.Now,
                GenreId = 7,
                Classification = Classification.Silver

            };

            //add video to DB using the stored procedure imported as method
            context.Videos.Add(v1);
            context.SaveChanges();
        }
    }
}
