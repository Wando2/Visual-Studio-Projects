using BlogDotNet6.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogDotNet6.Data.Mappings
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
            HasColumnType("nvarchar");

            builder.Property(x => x.Slug).
            IsRequired().
            HasColumnName("Slug").
            HasColumnType("nvarchar").
            HasMaxLength(100);

            builder.Property(x => x.PasswordHash)
                .IsRequired()
                .HasColumnName("PasswordHash")
                .HasColumnType("nvarchar")
                .HasMaxLength(500);

            builder.Property(x => x.Email)
                .IsRequired()
                .HasColumnName("Email")
                .HasColumnType("nvarchar")
                .HasMaxLength(100);

            builder.Property(x => x.Bio)
                .HasColumnName("Bio")
                .HasColumnType("text")
                .HasMaxLength(2000);

            builder.Property(x => x.Image)
                .HasColumnName("Image")
                .HasColumnType("nvarchar")
                .HasMaxLength(200);

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