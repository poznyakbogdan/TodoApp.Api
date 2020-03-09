using TodoApp.Infra.Interfaces;

namespace TodoApp.DAL
{
    public class RepositoryFactory : IRepositoryFactory
    {
        private readonly ApplicationContext _context;

        public RepositoryFactory(ApplicationContext context)
        {
            _context = context;
        }
        public IRepository<TEntity> Create<TEntity>() where TEntity: class
        {
            return new Repository<TEntity>(_context.Set<TEntity>());
        }
    }
}