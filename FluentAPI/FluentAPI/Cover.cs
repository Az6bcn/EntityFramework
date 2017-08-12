using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentAPI
{
    /****One-toOne Relationship with Course****/
    public class Cover
    {
        public int Id { get; set; }
        //Navigation property
        public Course Course { get; set; }
    }
}
