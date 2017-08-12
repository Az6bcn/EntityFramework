using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Queries.Core.Repositories
{
    /*********************************G E N E R I C  R E P O S I T O R Y*******************************/  
    //Repository Interface is like a Colletiuon, No UPDATE or SAVE methods
    //INTERFACE ONLY DECLARE BUT DOESN'T IMPLEMENTS THE LOGIC, THE CLASS THAT IMPLEMENTS THIS INTERFACE WILL IMPLEMENT THEIR LOGIC
    public interface IRepository<TEntity> where TEntity : class
    {
        //Gets an Id and returns an Object with that Id
        TEntity Get(int id);
        //Returns all Objects
        IEnumerable<TEntity> GetAll();
        //Takes a predicate, yu can use lambda expression => to filter Objects
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        // This method was not in the videos, but I thought it would be useful to add.
        TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate);

        //Add one Object to the Repository
        void Add(TEntity entity);
        //Add a list of Objects to the Repository
        void AddRange(IEnumerable<TEntity> entities);

        //Removes one Object to the Repository
        void Remove(TEntity entity);
        ////Removes a list of Objects to the Repository
        void RemoveRange(IEnumerable<TEntity> entities);
    }
}