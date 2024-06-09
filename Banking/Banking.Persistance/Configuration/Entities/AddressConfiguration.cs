using Banking.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Banking.Persistance.Configuration.Entities
{
    internal class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Street)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(a => a.City)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(a => a.PostCode)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(a => a.BuildingNumber)
                .IsRequired()
                .HasMaxLength(10);

            builder.Property(a => a.FlatNumber)
                .HasMaxLength(10);

            builder.Property(a => a.VerificationStatus)
                .IsRequired();

            builder.HasOne(a => a.CustomerRef)
                .WithMany(c => c.Addresses)
                .HasForeignKey(a => a.CustomerId);
        }
    }
}
