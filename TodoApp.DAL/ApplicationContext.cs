using Microsoft.EntityFrameworkCore;
using TodoApp.DAL.Models;

namespace TodoApp.DAL
{
    public class ApplicationContext : DbContext
    {
        public DbSet<TaskModel> Tasks { get; set; }
        public DbSet<Category> Categories { get; set; }

        public ApplicationContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}