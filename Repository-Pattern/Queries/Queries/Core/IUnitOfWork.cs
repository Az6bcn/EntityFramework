using Queries.Core.Repositories;
using System;

namespace Queries.Core
{
    //IUnitOfWork inherits from IDisposable
    public interface IUnitOfWork : IDisposable
    {
        //Exposes our Entities Repositories Interfaces, each one implements the IRepository.
        ICourseRepository Courses { get; }
        IAuthorRepository Authors { get; }
        int Complete();
    }
}