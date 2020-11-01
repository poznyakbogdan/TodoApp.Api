﻿using System;
using System.Threading.Tasks;

namespace TodoApp.Infra.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : class;
        Task CommitAsync();
    }
}