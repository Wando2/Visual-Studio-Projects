using BlogDotNet6.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogDotNet6.Data.Mappings
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Category");

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
                .HasIndex(x => x.Slug, "IX_Category_Slug")
                .IsUnique();

        }


    }
}