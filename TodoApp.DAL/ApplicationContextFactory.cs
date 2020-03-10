using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Logging;

namespace TodoApp.DAL
{
    public class ApplicationContextFactory : IDesignTimeDbContextFactory<ApplicationContext>
    {
        private readonly string _connectionString;
        private readonly ILoggerFactory _loggerFactory;
        public ApplicationContextFactory(string connectionString, ILoggerFactory loggerFactory)
        {
            _connectionString = connectionString;
            _loggerFactory = loggerFactory;
        }
        public ApplicationContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder();
            builder
                .UseLoggerFactory(_loggerFactory)
                .UseSqlite(_connectionString);
            return new ApplicationContext(builder.Options);
        }
    }
}