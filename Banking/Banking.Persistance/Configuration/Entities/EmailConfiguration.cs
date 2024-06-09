using Banking.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Banking.Persistance.Configuration.Entities
{
    internal class EmailConfiguration : IEntityTypeConfiguration<Email>
    {
        public void Configure(EntityTypeBuilder<Email> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Address)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(e => e.VerificationStatus)
                .IsRequired();

            builder.HasOne(e => e.CustomerRef)
                .WithMany(c => c.Emails)
                .HasForeignKey(e => e.CustomerId);
        }
    }
}
