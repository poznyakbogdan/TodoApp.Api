using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Storage;

namespace TodoApp.DAL
{
    public class ApplicationContextSqlLiteFactory : IDesignTimeDbContextFactory<ApplicationContext>
    {
        private readonly string _connectionString;

        public ApplicationContextSqlLiteFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public ApplicationContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder();
            builder.UseSqlite(_connectionString);
            return new ApplicationContext(builder.Options);
        }
    }
}