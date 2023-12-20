namespace FluentMapBlog.Data
{
    using Microsoft.EntityFrameworkCore;
    using FluentMapBlog.Models;
    using FluentMapBlog.Data.Mappings;
    public class BlogDataContext : DbContext
    {

        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Tag> Tags { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<Category> Categories { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Server=localhost,1433;Database=FluentBlog;User ID=sa;Password=1q2w3e4r@#$;Encrypt=false");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new PostMap());
            modelBuilder.ApplyConfiguration(new TagMap());
        }
       


    }
}