namespace TodoApp.Infra.Interfaces
{
    public interface IRepositoryFactory
    {
        IRepository<TEntity> Create<TEntity>() where TEntity: class;
    }
}