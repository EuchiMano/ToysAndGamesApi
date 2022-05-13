using Microsoft.EntityFrameworkCore;
using ToysAndGames.DataAccess.Data;
using ToysAndGames.Model.Interfaces;

namespace ToysAndGames.DataAccess.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly ApplicationDbContext _context;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<T> CreateAsync(T entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetAll()
        {
            throw new NotImplementedException();
        }

        

        public Task<T> UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}