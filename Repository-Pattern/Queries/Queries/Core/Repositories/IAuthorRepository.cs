using Queries.Core.Domain;

namespace Queries.Core.Repositories
{
    //INTERFACE ONLY DECLARE BUT DOESN'T IMPLEMENTS THE LOGIC, THE CLASS THAT IMPLEMENTS THIS INTERFACE WILL IMPLEMENT THEIR LOGIC
    public interface IAuthorRepository : IRepository<Author>
    {
        Author GetAuthorWithCourses(int id);
    }
}