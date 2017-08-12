using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentAPI
{
    public class Course
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float FullPrice { get; set; }
        public System.DateTime DatePublished { get; set; } 
        //Navigation property ==> will auto create FK as author_id--> this name we can override using fluent API
        public Author Author { get; set; }
        /*To override the default FK ("author_id") that could hav been created by Entity 
        we create a Foreign Key property with the name we want and later configure it using fluent API*/
        public int AuthorId { get; set; }  
        //Tag == Navigation property to Tag Model , Course has a list of tags
        public IList<Tag> Tags { get; set; }
        //Navigation property 
        public Cover Cover { get; set; }


    }
}
