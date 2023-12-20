using FluentMapBlog.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FluentMapBlog.Data.Mappings
{ 
    public class RoleMap : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Role");

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


            builder
                .HasIndex(x => x.Slug, "IX_Role_Slug")
                .IsUnique();

        }
    }
}