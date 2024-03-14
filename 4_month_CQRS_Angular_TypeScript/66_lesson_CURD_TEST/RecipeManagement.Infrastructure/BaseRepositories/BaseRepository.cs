using Microsoft.EntityFrameworkCore;
using RecipeManagement.Application.Abstractions;
using RecipeManagement.Infrastructure.Persistance;
using System.Linq.Expressions;

namespace RecipeManagement.Infrastructure.BaseRepositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly RecipeManagementDbContext _context;
        private readonly DbSet<T> _dbSet;

        public BaseRepository(RecipeManagementDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task<T> Create(T entity)
        {
            var result = await _dbSet.AddAsync(entity);

            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetByAny(Expression<Func<T, bool>> expression)
        {
            var result = await _dbSet.FirstOrDefaultAsync(expression);
            if (result == null)
            {
                return null!;
            }
            return result!;
        }

        public async Task<T> Update(T entity)
        {
            var result = _dbSet.Update(entity);

            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<bool> Delete(Expression<Func<T, bool>> expression)
        {
            var result = await _dbSet.FirstOrDefaultAsync(expression);
            if (result == null)
            {
                return false;
            }
            _dbSet.Remove(result);

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
