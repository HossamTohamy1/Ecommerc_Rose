using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
    public class ReviewConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.ToTable("Reviews");

            builder.HasKey(r => r.Id);
            builder.Property(r => r.Headline).IsRequired().HasMaxLength(200);
            builder.Property(r => r.Content).IsRequired();
            builder.Property(r => r.Rating).IsRequired();

            builder.HasOne(r => r.User)
                .WithMany(u => u.Reviews)
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(r => new { r.ProductId, r.UserId }).IsUnique();

            builder.HasQueryFilter(r => !r.IsDeleted);
        }
    }
}