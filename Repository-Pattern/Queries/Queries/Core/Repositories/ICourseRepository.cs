using Queries.Core.Domain;
using System.Collections.Generic;

namespace Queries.Core.Repositories
{
    //INTERFACE ONLY DECLARE BUT DOESN'T IMPLEMENTS THE LOGIC, THE CLASS THAT IMPLEMENTS THIS INTERFACE WILL IMPLEMENT THEIR LOGIC
    /*Derives from the GENERIC REPOSITORY INTERFACE ---> It will inherits all it's generic Operations */
    public interface ICourseRepository : IRepository<Course>
    {
        IEnumerable<Course> GetTopSellingCourses(int count);
        IEnumerable<Course> GetCoursesWithAuthors(int pageIndex, int pageSize);
    }
}