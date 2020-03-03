using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace TodoApp.DAL
{
    public class ApplicationContextFactory : IDesignTimeDbContextFactory<ApplicationContext>
    {
        private readonly string _connectionString = "server=localhost;database=todo;user=dev;password=qwerty";
        
        public ApplicationContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder();
            builder.UseMySQL(_connectionString);
            return new ApplicationContext(builder.Options);
        }
    }
}