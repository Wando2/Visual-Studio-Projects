
namespace BlogDotNet6.Data{
    using Microsoft.EntityFrameworkCore;
    using BlogDotNet6.Models;
    public class BlogDataContext : DbContext
    {
       
        public DbSet<Post> Posts { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Tag> Tags { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Server=localhost,1433;Database=BlogDotNet6;User ID=sa;Password=1q2w3e4r@#$;Encrypt=false");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tag>().ToTable("Tag");
            modelBuilder.Entity<Post>().ToTable("Post");
            modelBuilder.Entity<Category>().ToTable("Category");
            modelBuilder.Entity<Role>().ToTable("Role");
            modelBuilder.Entity<User>().ToTable("User")
            .HasIndex(u => u.Email)
            .IsUnique(); 

        }


    }
}