using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbFirst
{

   

public class Program
    {
        //ENUM
        public enum Level : byte
        {
            Beginner = 1,
            Intermediate = 2,
            Advanced = 3
        }

        static void Main(string[] args)
        {

            PlutoDbContext db = new PlutoDbContext();
            //get courses through stored procedure that ended up as Method
            var courses = db.GetCourses();

            //Iterate over the list of courses
            foreach (var c in courses)
            {
                Console.WriteLine(c.Title);
            }

            //Course Object --> and set it's level to any of the ENUM
            Course crse = new Course();
            crse.Level = Level.Beginner;
            

            Console.ReadKey();

            
    }
    }
}
