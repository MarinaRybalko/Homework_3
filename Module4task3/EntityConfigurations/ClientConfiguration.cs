using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Module4task3.Entities;

namespace Module4task3.EntityConfigurations
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("Client").HasKey(h => h.ClientId);
            builder.Property(p => p.ClientId).HasColumnName("ClientId");
            builder.Property(p => p.FirstName).HasColumnName("FirstName").HasMaxLength(255);
            builder.Property(p => p.LastName).HasColumnName("LastName").HasMaxLength(255);
            builder.Property(p => p.Email).HasColumnName("Email").HasMaxLength(255);
            builder.Property(p => p.Phone).HasColumnName("Phone").HasMaxLength(13);
            builder.Property(p => p.IsActive).HasColumnName("IsActive").HasDefaultValue(true);
        }
    }
}