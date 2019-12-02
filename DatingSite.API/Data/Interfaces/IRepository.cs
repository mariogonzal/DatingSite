using System.Collections.Generic;
using DatingSite.API.Models;

namespace DatingSite.API.Data.Interfaces
{
    public interface IRepository<T> where T: DataEntityModelBase
    {
        IEnumerable<T> List{get;}        
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        T Find(int Id);

         
    }
}