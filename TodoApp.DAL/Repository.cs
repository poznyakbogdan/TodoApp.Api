using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TodoApp.Infra.Interfaces;

namespace TodoApp.DAL
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity: class
    {
        private readonly DbSet<TEntity> _entities;

        public Repository(DbSet<TEntity> entities)
        {
            _entities = entities;
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _entities.FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _entities.ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await _entities.Where(expression).ToListAsync();
        }

        public async Task CreateAsync(TEntity entity)
        {
            await _entities.AddAsync(entity);
        }
        
        public void Remove(TEntity entity)
        {
            _entities.Remove(entity);
        }
    }
}