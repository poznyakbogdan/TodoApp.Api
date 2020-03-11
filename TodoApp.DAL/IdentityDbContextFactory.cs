using IdentityServer4.EntityFramework.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace TodoApp.DAL
{
    public class IdentityDbContextFactory : IDesignTimeDbContextFactory<IdentityDbContext>
    {
        private readonly string _connectionString;
        private readonly ILoggerFactory _loggerFactory;
        public IdentityDbContextFactory(string connectionString, ILoggerFactory loggerFactory)
        {
            _connectionString = connectionString;
            _loggerFactory = loggerFactory;
        }
        
        public IdentityDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder();
            builder
                .UseLoggerFactory(_loggerFactory)
                .UseMySQL(_connectionString);
            return new IdentityDbContext(builder.Options, new OptionsWrapper<OperationalStoreOptions>(new OperationalStoreOptions()));
        }
    }
}