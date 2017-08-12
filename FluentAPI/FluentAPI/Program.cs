using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentAPI
{
    class Program
    {
        static void Main(string[] args)
        {


            PlutoContext dbContext = new PlutoContext();

            Author a = new Author
            {
                Name = "Bolu",
                //Instantiate the courses List of this Author
                Courses = new List<Course>()
                {
                    new Course()
                    {
                        Name = "STTC",
                        Description = "STTC ES UNA OPTATIVA",
                        DatePublished = DateTime.Now,
                        FullPrice = 2500
                    }
                }


            };
            /********************************** O R ***********************************/
            //a.Name = "Azeez";

            //// New Course
            //Course c = new Course
            //{
            //    Name = "ERF",
            //    Description = "Ing. de Radio-Frecuencias",
            //    DatePublished = DateTime.Now

            //};

            ////add this course to the a.Courses List
            //a.Courses.Add(c);   // --> To be able to add this to Course List in the Author's clas, the list must have been Instantiated in the class Constructor to prevent NULL-REFRENCE-EXCEPTION

            //add to db
            dbContext.authors.Add(a);
            //commit to db
            dbContext.SaveChanges();



            Console.ReadLine();

        }
    }
}
