using System;
using System.Linq;
using System.Collections;


namespace Queries
{
    class Program
    {
        static void Main(string[] args)
        {
            PlutoContext context = new PlutoContext();

            //Linq Syntax
            var query =
                from c in context.Courses //context.Courses--> sOURCE OF DATA, cOURSE = ONE OF dBsET (tABLE)
                                          //Filter ==> WHERE Operator
                where c.Name.Contains("C#") //Filters the list to get C# Courses
                                            //Sort ==> ORDERBY 

                orderby c.Name //Sorts them alphabetically
                select c;


            //Iterate over the Query Object to display the Result (all C# Courses)
            foreach (var course in query)
            {
                //Print out the Course Names
                Console.WriteLine(course.Name);
            }

            //Linq Extension Methods
            var courseQuery = context.Courses
                              .Where(c => c.Name.Contains("c#"))
                              .OrderBy(c => c.Name);

            foreach (var course in courseQuery)
            {
                //Print out the Course Names
                Console.WriteLine(course.Name);
            }

            /*********************************************L I N Q   S Y N T A X **************************************/

            /*RESTRICTION*/ //---> Select all Courses of Level =1 with Author.id = 1
            var query2 =
                from c in context.Courses
                where c.Level == 1 && c.Author.Id == 1
                select c;

            /*ORDERING*/  //---> Order all Courses of certain Author by their Level
            var query3 =
                from c in context.Courses
                where c.Author.Id == 1
                //orderby c.Level
                //Orderby Multiple Columns --> Order by Level (descending order) then by their Name
                orderby c.Level descending, c.Name
                select c;

            /*PROJECTION*/  //---> When we want to return a different Object ( not return all the properties of an Entity)
            var query4 =
                from c in context.Courses
                where c.Author.Id == 1
                //Orderby Multiple Columns --> Order by Level (descending order) then by their Name
                orderby c.Level descending, c.Name
                //Project the properties into a difrent object 
                select new { Name = c.Name, Author = c.Author.Name };

            /*GROUPBY*/  //---> To break Objects into one or more groups
            var query5 =
                from c in context.Courses
                group c by c.Level into g //groups the courses base on their Levels into List of groups (g) e.g Level1 Courses, Level2 Courses and Level3 Courses into variable g
                //we get a List of groups
                select g;


            //iterate over them

            foreach (var group in query5)
            {
                //Select the Key of the Group == The Level of Courses it Contains
                Console.WriteLine(group.Key);
                
                //AGREGATE FUNCTION ---> e.g Count(), Max etc
                //Display all level & No. of Courses in each Level
                Console.WriteLine("{0}, ({1})", group.Key, group.Count());

                //Display the Courses in each group ---> A group is IEnumerable, contains a List of Courses that belongs to it
                foreach (var Course in group)
                {
                    Console.WriteLine("\t{0}", Course.Name);

                }
            }


            /*JOINING*/  //---> In LINQ 3types of Joining .... Inner Join, Group Join and Cross Join
            //INNER JOIN in LINQ : You use the navigation property of Entities to display properties of their related entities.
            var queryJoin =
                from c in context.Courses
                    // Projection into anonymous Object to get CourseName and it's Authors's Name ---> jst like joining Course and Author's Table in SQL
                select new { CourseName = c.Name, AuthorName = c.Author.Name }; //Author --> navigation property in Course class that permits us to hv access to Author's clas

            foreach (var item in queryJoin)
            {
               
              Console.WriteLine("{0} Author's Name is ------> {1}", item.CourseName, item.AuthorName);
            }

            /*GROUP JOIN in LINQ : Associates/Join each Object in the Left table (1st table we refrencing in our query) with 1 or More Objects (ListObject) in 
            the Right Table(2nd table refrenced in our query) */
            var queryGroupJoin =
                //List of Authors
              from a in context.Authors
                  //Join Author to Course o ListCourses by it's Id ==> where authorId == CourseId
                //Match each Author to one or more courses
              join c in context.Courses on a.Id equals c.AuthorId into g //into g -> Result will be a group Join == List of match Course with same id as Author's id
                  // Projection into anonymous Object to get CourseName and it's Authors's Name ---> jst like joining Course and Author's Table in SQL
              select new { AuthorName = a.Name, CourseName = g.Count()}; //Author --> navigation property in Course class that permits us to hv access to Author's clas

            foreach (var item in queryGroupJoin)
            {

                Console.WriteLine("Author's Name is : {0}  Number of Courses ------> {1}", item.AuthorName, item.CourseName);
            }
            

            /*********************************************L I N Q   M E T H O D **************************************/


            /*RESTRICTION*/ //---> Select all Courses of Level =1 with Author.id = 1/*RESTRICTION*/ //---> Select all Courses of Level =1 with Author.id = 1
            var Courses = context.Courses.Where(c => c.Level == 1);

            /*ORDERING*/  //---> Order all Courses by Name
            var Courses2 = context.Courses.Where(c => c.Level == 1).OrderBy(c => c.Name);
            //To OrderBy Multiple properties---> you use ThenBy()
            var Courses_1 = context.Courses.Where(c => c.Level == 1).OrderBy(c => c.Name).ThenBy(C => C.Level);
            //Decending way
            var Courses2_3 = context.Courses
                .Where(c => c.Level == 1)
                .OrderByDescending(c => c.Name)
                .ThenByDescending(C => C.Level);

            /*PROJECTION*/  //---> When we want to return a different Object ( not return all the properties of an Entity)

            var Courses3 = context.Courses
                .Where(c => c.Level == 1)
                .OrderByDescending(c => c.Name)
                .ThenByDescending(C => C.Level)
                //Project the properties into a difrent object 
                //.Select(c => new { CourseName = c.Name, AuthorName = c.Author.Name });
                //Select list of Tag bcos Courses has a List of Tag.
                .Select(c => c.Tags); //But the Course3 variable also returns a list of the query result i.e we having a list of list of Tags
                //C Returns a List of Courses 
                foreach (var c in Courses3)
                {
                    //Each of the Course in this List Consists of List of Tags
                    foreach (var tag in c)
                    {
                        Console.WriteLine(tag.Name);
                    }
                }

            /***********************SELECTMANY**************/
            //SelectMany --> Returns a flat List of Tags. 
            var tags = context.Courses
               .Where(c => c.Level == 1)
               .OrderByDescending(c => c.Name)
               .ThenByDescending(C => C.Level)
               .SelectMany(c => c.Tags) //Use SelectMany when what we want to Select is a List.
                //to make returned reult unique--- No repeticion-- we use the Distinct()
               .Distinct();
            //tags --> Contains list of Tags Tag : Id, Nam, ListCourses
            foreach (var tag in tags)
            {
                Console.WriteLine("SelectMany ----->" + tag.Name);
            }

            /*GROUPBY*/  //---> To break Objects into one or more groups
            var contextGroupByLevel = context.Courses
                             //Break the Courses List into groups (Break down by Level)
                             .GroupBy(c => c.Level);
            foreach (var group in contextGroupByLevel)
            {
                //each group --> contains as List of courses in that group (Level)
                Console.WriteLine(group.Key); //get the key of the group

                //iterate through the List in the group
                foreach (var course in group)
                {
                    //Display the courses in the group (in that Level)
                    Console.WriteLine(course.Name);
                }
            }

            /*JOINING*/  //---> In LINQ 3types of Joining .... Inner Join, Group Join and Cross Join
                         //INNER JOIN in LINQ : You use the navigation property of Entities to display properties of their related entities.
                         //INNER JOIN: to get CourseName- AuthorName. ***we assume these two Objects (Courses and Authors) has no relationship btw them. If there's 
                         //we use the navigation property of Entities to display properties of their related entities.

            var innerJoin = context.Courses.Join(context.Authors,
                        c => c.AuthorId,
                        a => a.Id,            //c, a --> to relate the two tables
                        //want used happend we they are matched
                        (course, author) => new
                        {
                            CourseName = course.Name,
                            AuthorName = author.Name
                        });

            /*GROUP JOIN in LINQ : Associates/Join each Object in the Left table (1st table we refrencing in our query) with 1 or More Objects (ListObject) in 
           the Right Table(2nd table refrenced in our query) */
            var GroupJoin = context.Authors //Left Table
                 .GroupJoin(context.Courses, a => a.Id, c => c.AuthorId,
                 //want used happend we they are matched
                 (author, courses) => new {
                     AuthorName = author.Name,
                     Courses = courses.Count()
                 });
                
            Console.ReadLine();
        }
    }
}
