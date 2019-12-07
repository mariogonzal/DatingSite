using System.Collections.Generic;
using System.Threading.Tasks;
using DatingSite.API.Models;

namespace DatingSite.API.Data.Interfaces
{
    public interface IRepository<T> where T: DataEntityModelBase
    {
        Task<IEnumerable<T>> List();
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task<T> Find(int Id);
        Task<bool> SaveAll();

         
    }
}