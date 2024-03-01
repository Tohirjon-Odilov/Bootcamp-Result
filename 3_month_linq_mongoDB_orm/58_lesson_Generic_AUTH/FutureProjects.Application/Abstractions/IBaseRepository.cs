using System.Linq.Expressions;

namespace FutureProjects.Application.Abstractions
{
    public interface IBaseRepository<T> where T : class
    {
        public Task<T> Create(T entity);
        public Task<T> GetByAny(Expression<Func<T, bool>> expression);
        public Task<IEnumerable<T>> GetAll();
        public Task<bool> Delete(Expression<Func<T, bool>> expression);
        public Task<T> Update(T entity);
    }
}
