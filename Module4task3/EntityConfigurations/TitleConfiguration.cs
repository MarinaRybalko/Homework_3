using Module4task3.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Module4task3.EntityConfigurations
{
    public class TitleConfiguration : IEntityTypeConfiguration<Title>
    {
        public void Configure(EntityTypeBuilder<Title> builder)
        {
            builder.ToTable("Title").HasKey(h => h.TitleId);
            builder.Property(p => p.Name).IsRequired().HasColumnName("Name").HasMaxLength(50);

            builder.HasMany(h => h.Employee)
                .WithOne(w => w.Title)
                .HasForeignKey(h => h.TitleId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
