using System.Linq.Expressions;

namespace RecipeManagement.Application.Abstractions
{
    public interface IBaseRepository<T> where T : class
    {
        public Task<T> Create(T entity);
        public Task<IEnumerable<T>> GetAll();
        public Task<T> GetByAny(Expression<Func<T, bool>> expression);
        public Task<T> Update(T entity);
        public Task<bool> Delete(Expression<Func<T, bool>> expression);
    }
}
