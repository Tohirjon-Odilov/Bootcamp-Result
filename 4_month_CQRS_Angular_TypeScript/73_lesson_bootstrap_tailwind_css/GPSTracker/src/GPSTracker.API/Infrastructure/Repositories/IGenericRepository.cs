namespace GPSTracker.API.Infrastructure.Repositories
{
    public interface IGenericRepository<TEntity>
    {
        ValueTask<TEntity> InsertAsync(TEntity entity);
        List<TEntity> SelectAll();
        ValueTask<TEntity> SelectByIdAsync(int id);
        ValueTask<TEntity> UpdateAsync(TEntity entity);
        ValueTask<TEntity> DeleteAsync(TEntity entity);
    }
}
