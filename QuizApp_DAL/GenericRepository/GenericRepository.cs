using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using QuizApp_Core.Exceptions;
using QuizApp_Core.Extensions;
using QuizApp_DAL.BasicGenericRepository;
using QuizApp_DAL.Entities;
using System.Linq.Expressions;

namespace QuizApp_DAL.GenericRepository
{
    public class GenericRepository<T> : BasicGenericRepository<T>, IGenericRepository<T> where T : Entity, new()
    {
        public GenericRepository(EfDbContext dbContext, ILogger<GenericRepository<T>> logger) : base(dbContext, logger)
        { }

        public override async Task<T> CreateAsync(T entity)
        {
            entity.Id = Guid.NewGuid();
            _dbSet.Add(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<T> GetByIdAsync(Guid? id)
        {
            var entity = await _dbSet.AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);

            if (entity is null)
            {
                _logger.LogMessageAndThrowException($"Can't find object", new ObjectNotFoundException(typeof(T)));
            }

            return entity;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch
            {
                _logger.LogMessageAndThrowException($"Can't update object", new ObjectNotFoundException(typeof(T)));
            }

            return entity;
        }

        public async Task<T> DeleteAsync(Guid? id)
        {
            var entity = new T { Id = (Guid)id };

            _dbContext.Entry(entity).State = EntityState.Deleted;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch
            {
                _logger.LogMessageAndThrowException($"Can't delete object", new ObjectNotFoundException(typeof(T)));
            }

            return entity;
        }
    }
}
