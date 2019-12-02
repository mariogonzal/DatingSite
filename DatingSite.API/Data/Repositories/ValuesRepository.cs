using System.Collections.Generic;
using System.Linq;
using DatingSite.API.Data.Interfaces;
using DatingSite.API.Models;

namespace DatingSite.API.Data.Repositories
{
    public class ValuesRepository : IRepository<Value>
    {
        private readonly DataContext _dbContext;
        public ValuesRepository(DataContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public IEnumerable<Value> List => _dbContext.Values.ToList();

        public void Add(Value entity)
        {
            _dbContext.Values.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(Value entity)
        {
            _dbContext.Remove(entity);
            _dbContext.SaveChanges();
        }

        public Value Find(int Id)
        {
            return _dbContext.Values.FirstOrDefault(x=>x.Id==Id);
        }
        public void Update(Value entity)
        {
            _dbContext.Entry(entity).State=Microsoft.EntityFrameworkCore.EntityState.Modified;
            _dbContext.Values.Update(entity);
            _dbContext.SaveChanges();
        }
    }
}