using Microsoft.EntityFrameworkCore;
using TodoList.Model;

namespace TodoList.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Todo> Todos { get; set; }
       
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=app.db;cache=shared");
        }
    }
}