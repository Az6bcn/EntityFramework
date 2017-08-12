using Queries.Core.Domain;
using Queries.Core.Repositories;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Queries.Persistence.Repositories
{
    //inherits the Repository class and implements the ICourseRepository
    public class CourseRepository : Repository<Course>, ICourseRepository
    {
        //Call the BASE (Parent) class constructor passing it "context" which is of type "PlutoContext"
        public CourseRepository(PlutoContext context) : base(context)
        {
        }

        public PlutoContext PlutoContextApp
        {
            /*Cast the Context we re inheriting from the Generic Repository to the name 
             * of our Application's Context (ContextCllassName). 
             *So we can get Access to our Application Context DbSets */
            get { return Context as PlutoContext; }
        }



        //Implementation of the Logic of the Methods in the ICourseRepository Interface
        public IEnumerable<Course> GetTopSellingCourses(int count)
        {
            //not really top selling
            return PlutoContextApp.Courses.OrderByDescending(c => c.FullPrice).Take(count).ToList();
        }

        public IEnumerable<Course> GetCoursesWithAuthors(int pageIndex, int pageSize = 10)
        {
            //uses Eager Loading to load Courses and it's Author
            return PlutoContextApp.Courses
                .Include(c => c.Author)
                .OrderBy(c => c.Name)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }

       
    }
}