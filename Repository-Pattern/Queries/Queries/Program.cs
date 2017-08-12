using Queries.Persistence;

namespace Queries
{
    class Program
    {
        static void Main(string[] args)
        {
            //using to dispose the context automatically after ecxecution-----only in console App
            //Initialise a UnitOfWork with our AppContextName
            using (var unitOfWork = new UnitOfWork(new PlutoContext()))
            {
                // Example1 --> Get a course with id =!
                var course = unitOfWork.Courses.Get(1); /*unitOfWork-- similar to DbContext only that it acess our Repository 
                                                        and not the DbSets in our DbContext in this way it decouples our App 
                                                        from EF. Since the "ICourseRepository Courses" implements the IRepository
                                                        we can access the method implemented in this Interface*/

                // Example2 --> Get all courses with their Authors
                var courses = unitOfWork.Courses.GetCoursesWithAuthors(1, 4);

               
                // Example3 --> Delete Author and It's Courses. Cascade Delete OFF, we have to Delete the Courses of the Author 1st and later Delete the Authors
                //1: Get the Author 
                var author = unitOfWork.Authors.GetAuthorWithCourses(1);
                //2: Delete all it's Courses (List of Courses)
                unitOfWork.Courses.RemoveRange(author.Courses);
                //3: Delete the Author himself
                unitOfWork.Authors.Remove(author);
                //SaveChanges
                unitOfWork.Complete();
            }
        }
    }
}
  