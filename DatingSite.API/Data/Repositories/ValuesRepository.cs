using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingSite.API.Data.Interfaces;
using DatingSite.API.Models;
using Microsoft.EntityFrameworkCore;

namespace DatingSite.API.Data.Repositories
{
    public class ValuesRepository : IRepository<Value>
    {
        private readonly DataContext _dbContext;        

        public ValuesRepository(DataContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public async Task<IEnumerable<Value>> List()
        {
             return await _dbContext.Values.ToListAsync();
        }

        public void Add(Value entity)
        {
            _dbContext.Values.Add(entity);            
        }

        public void Delete(Value entity)
        {
            _dbContext.Remove(entity);            
        }

        public async Task<Value> Find(int Id)
        {
            return await _dbContext.Values.FirstOrDefaultAsync(x=>x.Id==Id);
        }
        public void Update(Value entity)
        {
            _dbContext.Entry(entity).State=Microsoft.EntityFrameworkCore.EntityState.Modified;
            _dbContext.Values.Update(entity);            
        }

        public async Task<bool> SaveAll()
        {
             return await _dbContext.SaveChangesAsync()>0;            
        }
    }
}