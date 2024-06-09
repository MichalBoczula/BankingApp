using Banking.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Banking.Persistance.Configuration.Entities
{
    internal class PhoneConfiguration : IEntityTypeConfiguration<Phone>
    {
        public void Configure(EntityTypeBuilder<Phone> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.CountryCode)
                .IsRequired()
                .HasMaxLength(5);

            builder.Property(p => p.Number)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(p => p.VerificationStatus)
                .IsRequired();

            builder.HasOne(p => p.CustomerRef)
                .WithMany(c => c.Phones)
                .HasForeignKey(p => p.CustomerId);
        }
    }
}
