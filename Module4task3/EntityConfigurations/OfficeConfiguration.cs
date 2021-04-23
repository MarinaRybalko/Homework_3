using Module4task3.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Module4task3.EntityConfigurations
{
    public class OfficeConfiguration : IEntityTypeConfiguration<Office>
    {
        public void Configure(EntityTypeBuilder<Office> builder)
        {
            builder.ToTable("Office").HasKey(h => h.OfficeId);
            builder.Property(p => p.Title).IsRequired().HasColumnName("Title").HasMaxLength(100);
            builder.Property(p => p.Location).IsRequired().HasColumnName("Location").HasMaxLength(100);

            builder.HasMany(h => h.Employee)
                .WithOne(w => w.Office)
                .HasForeignKey(h => h.OfficeId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
