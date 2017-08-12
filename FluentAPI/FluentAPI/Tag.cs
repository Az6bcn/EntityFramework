using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentAPI
{
   public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //List of Courses
        public IList<Course> Courses { get; set; }

    }
}
