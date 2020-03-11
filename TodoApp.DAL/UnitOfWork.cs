using System.Threading.Tasks;
using TodoApp.Infra.Interfaces;

namespace TodoApp.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _context;
        private readonly IRepositoryFactory _repositoryFactory;

        public UnitOfWork(ApplicationContext context, IRepositoryFactory repositoryFactory)
        {
            _context = context;
            _repositoryFactory = repositoryFactory;
        }

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            return _repositoryFactory.Create<TEntity>();
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}