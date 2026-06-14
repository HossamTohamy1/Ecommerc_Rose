using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
    public class OccasionConfiguration : IEntityTypeConfiguration<Occasion>
    {
        public void Configure(EntityTypeBuilder<Occasion> builder)
        {
            builder.ToTable("Occasions");

            builder.HasKey(o => o.Id);
            builder.Property(o => o.Title).IsRequired().HasMaxLength(150);
            builder.Property(o => o.Description).HasMaxLength(1000);
            builder.Property(o => o.Image).HasMaxLength(500);

            builder.HasQueryFilter(o => !o.IsDeleted);
        }
    }
}