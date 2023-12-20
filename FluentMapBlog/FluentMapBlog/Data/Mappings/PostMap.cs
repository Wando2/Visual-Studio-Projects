using FluentMapBlog.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FluentMapBlog.Data.Mappings
{

    public class PostMap : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.ToTable("Post");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn(1, 1);

            builder.Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnType("varchar")
                .HasColumnName("Title");

            builder.Property(x => x.Slug)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(100)
                .HasColumnName("Slug");

            builder.Property(x => x.Body)
                .IsRequired()
                .HasColumnType("text")
                .HasMaxLength(2000)
                .HasColumnName("Body");

            builder.Property(x => x.CreateDate)
                .HasColumnType("datetime")
                .HasDefaultValue(DateTime.Now.ToUniversalTime())
                .HasColumnName("CreateDate");

            builder.Property(x => x.LastUpdateDate)
                .HasColumnType("datetime")
                .HasDefaultValue(DateTime.Now.ToUniversalTime())
                .HasColumnName("LastUpdateDate");

            builder.Property(x => x.Summary)
                .IsRequired()
                .HasColumnType("text")
                .HasMaxLength(2000)
                .HasColumnName("Summary");

            builder
                .HasIndex(x => x.Slug, "IX_Post_Slug")
                .IsUnique();

            builder.HasOne(x => x.Author)
            .WithMany(x => x.Posts)
            .HasConstraintName("FK_Post_User");

            builder.HasOne(x => x.Category)
            .WithMany(x => x.Posts)
            .HasConstraintName("FK_Post_Category");

            builder.HasMany(x => x.Tags)
            .WithMany(x => x.Posts)
            .UsingEntity<Dictionary<string, object>>(
                "PostTag",
                post => post.HasOne<Tag>()
                .WithMany()
                .HasForeignKey("TagId")
                .OnDelete(DeleteBehavior.Cascade),
                tag => tag.HasOne<Post>()
                .WithMany()
                .HasForeignKey("PostId")
                .HasConstraintName("FK_PostTag")
                .OnDelete(DeleteBehavior.Cascade));






        }
    }
}

