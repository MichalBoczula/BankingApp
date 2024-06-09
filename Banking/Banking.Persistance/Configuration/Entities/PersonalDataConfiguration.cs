using Banking.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Banking.Persistance.Configuration.Entities
{
    internal class PersonalDataConfiguration : IEntityTypeConfiguration<PersonalData>
    {
        public void Configure(EntityTypeBuilder<PersonalData> builder)
        {
            builder.HasKey(pd => pd.Id);

            builder.Property(pd => pd.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(pd => pd.LastName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(pd => pd.DateOfBirth)
                .IsRequired();

            builder.Property(pd => pd.IdentityNumber)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(pd => pd.DocumentType)
                .IsRequired();

            builder.HasOne(pd => pd.CustomerRef)
                .WithOne(c => c.PersonalDataRef)
                .HasForeignKey<PersonalData>(pd => pd.CustomerId);
        }
    }
}
