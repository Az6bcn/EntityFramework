using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//import data.Entity for DbContext


namespace CodeFirstDemo
{
    /*CODE FIRST*/

    //1 :   Install entity Framework through NuGet into project (Tools--> NuGet)
    //2:    We create our Model class with it's properties --> these properties will be our DbSet (Table) columns 
    //in SQL 

    public class Post
    {
        //EF taked every property with ID o id o Id o xxId as the PK
        public int Id { get; set; }
        public DateTime DatePublished { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
    }


    //3:    Create context class that : DbContext  --> We use this class instantiated object to load and save data

        public class BlogDbContext : DbContext
    {
        //Expose, declare our DbSets (Tables) === Models
        public DbSet<Post> Posts { get; set; }
    }


    //4:    Specifiy ConnectionString  in app.config
    /*
       <connectionStrings>
            <add name ="ContextClassName" connectionString="data Source= AZEEZOLUSEGUN(SQL DatabaseName); initial catalog = SpecifyNameOfDatabase; integrated security= true" providerName="System.Data.SqlClient/>  (providerName="System.Data.SqlClient--> required to work with codeFirst)
       </connectionStrings>
     */

    //5:    Enable Code First Migrations from "package manager console" --> execute : enable-migrations (run only once for the lifetime of a project)
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
