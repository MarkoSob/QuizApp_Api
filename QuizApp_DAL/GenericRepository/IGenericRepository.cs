using QuizApp_DAL.Entities;
using System.Linq.Expressions;

namespace QuizApp_DAL.GenericRepository
{
    public interface IGenericRepository<T> where T : Entity, new()
    {
        Task<T> CreateAsync(T entity);
        Task<T> DeleteAsync(Guid? id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(Guid? id);
        IQueryable<T> GetByPredicate(Expression<Func<T, bool>> expression);
        Task<T> UpdateAsync(T entity);
    }
}