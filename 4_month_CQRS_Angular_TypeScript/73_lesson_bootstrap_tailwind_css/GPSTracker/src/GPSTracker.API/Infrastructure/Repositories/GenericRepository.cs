namespace GPSTracker.API.Infrastructure.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly AppDbContext _context;

        public GenericRepository(AppDbContext context)
            => _context = context;

        public async ValueTask<TEntity> InsertAsync(TEntity entity)
        {
            var entityEntry = await _context.AddAsync<TEntity>(entity);
            await _context.SaveChangesAsync();

            return entityEntry.Entity;
        }

        public List<TEntity> SelectAll()
            => _context.Set<TEntity>().ToList();

        public async ValueTask<TEntity> SelectByIdAsync(int id)
            => await _context.Set<TEntity>().FindAsync(id);

        public async ValueTask<TEntity> DeleteAsync(TEntity entity)
        {
            var entityEntry = this._context.Set<TEntity>().Remove(entity);
            await _context.SaveChangesAsync();

            return entityEntry.Entity;
        }

        public async ValueTask<TEntity> UpdateAsync(TEntity entity)
        {
            var entityEntry = this._context.Update<TEntity>(entity);
            await _context.SaveChangesAsync();

            return entityEntry.Entity;
        }
    }
}
