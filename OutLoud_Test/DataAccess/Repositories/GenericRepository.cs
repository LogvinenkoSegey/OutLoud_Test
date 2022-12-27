using Microsoft.EntityFrameworkCore;
using OutLoud_Test.DataAccess.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OutLoud_Test.DataAccess.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        readonly AppDbContext _context;
        readonly DbSet<TEntity> _db;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
            _db = context.Set<TEntity>();
        }

        public async Task Create(TEntity item)
        {
            await _db.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAll() => 
            await _db.AsNoTracking().ToListAsync();

        public async Task Remove(TEntity item)
        {
            _db.Remove(item);
            await _context.SaveChangesAsync();
        }

        public async Task Remove(IEnumerable<TEntity> items)
        {
            _db.RemoveRange(items);
            await _context.SaveChangesAsync();
        }

        public async Task Update(TEntity item)
        {
            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
