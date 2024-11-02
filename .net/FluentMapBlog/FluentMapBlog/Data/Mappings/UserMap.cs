using FluentMapBlog.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FluentMapBlog.Data.Mappings
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).
            ValueGeneratedOnAdd().
            UseIdentityColumn(1, 1);

            builder.Property(x => x.Name).
            IsRequired().
            HasColumnName("Name").

            HasMaxLength(100).
            HasColumnType("varchar");

            builder.Property(x => x.Slug).
            IsRequired().
            HasColumnName("Slug").
            HasColumnType("varchar").
            HasMaxLength(100);

            builder.Property(x => x.PasswordHash);
            builder.Property(x => x.Email);
            builder.Property(x => x.Bio);
            builder.Property(x => x.Image);

            builder
                .HasIndex(x => x.Slug, "IX_User_Slug")
                .IsUnique();

            builder.HasMany(x => x.Roles)
            .WithMany(x => x.Users)
            .UsingEntity<Dictionary<string, object>>(
                "UserRole",
                user => user.HasOne<Role>()
                .WithMany()
                .HasForeignKey("RoleId"),
                role => role.HasOne<User>()
                .WithMany()
                .HasForeignKey("UserId"));
                

        }
    }
}