using Queries.Core;
using Queries.Core.Repositories;
using Queries.Persistence.Repositories;

namespace Queries.Persistence
{
    //Implements the Logic for Methods in the IUnitOfWork Interface
    public class UnitOfWork : IUnitOfWork
    {
        //Our App contextClassName
        private readonly PlutoContext _context;

        //Recieves our App ContextClassName
        public UnitOfWork(PlutoContext context)
        {
            //stores our App ContextName in _context
            _context = context;
            //Then uses the context to initialise both Repositories
            Courses = new CourseRepository(_context);
            Authors = new AuthorRepository(_context);
        }

        //properties 
        public ICourseRepository Courses { get; private set; }
        public IAuthorRepository Authors { get; private set; }

        //Calls the SaveChanges on the Context
        public int Complete()
        {
            return _context.SaveChanges();
        }

        //Implementation of the Dispose Method to Dispose the Context
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}