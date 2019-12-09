using System.Collections.Generic;
using System.Threading.Tasks;
using DatingSite.API.Data.Interfaces;
using DatingSite.API.Models;
using Microsoft.EntityFrameworkCore;

namespace DatingSite.API.Data.Repositories
{
    public class UserRepository : IRepository<User>
    {
        private readonly DataContext _context;
        public UserRepository(DataContext context)
        {
            _context = context;

        }
        public void Add(User entity)
        {
            _context.Users.Add(entity);
        }

        public void Delete(User entity)
        {
            _context.Users.Remove(entity);
        }

        public async Task<User> Find(int Id)
        {
            return await _context.Users.Include(ph=>ph.Photos).FirstOrDefaultAsync(u=> u.Id==Id);
        }

        public async Task<IEnumerable<User>> List()
        {
            return await _context.Users.Include(ph=>ph.Photos).ToListAsync();
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync()>0;
        }

        public void Update(User entity)
        {
             _context.Entry(entity).State=Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.Users.Update(entity); 
        }
    }
}