using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TodoApp.Infra.Interfaces
{
    public interface IRepository<TEntity>
    {
        public Task<TEntity> GetByIdAsync(int id);
        public Task<IEnumerable<TEntity>> GetAllAsync();
        public Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> expression);
        public Task CreateAsync(TEntity entity);
        public Task<TEntity> UpdateAsync(TEntity entity);
        public Task<IEnumerable<TEntity>> UpdateManyAsync(IEnumerable<TEntity> entities);
        public void Remove(TEntity entity);
    }
}