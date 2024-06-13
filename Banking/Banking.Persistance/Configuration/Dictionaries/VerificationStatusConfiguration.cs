using Banking.Domain.Dictionaries.Tables;
using BankingApp.DataTransferObject.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Banking.Persistance.Configuration.Dictionaries
{
    internal class VerificationStatusConfiguration : IEntityTypeConfiguration<VerificationStatus>
    {
        public void Configure(EntityTypeBuilder<VerificationStatus> builder)
        {
            builder.HasKey(vs => vs.Id);

            builder.Property(vs => vs.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasData(
                new VerificationStatus { Id = (int)VerificationStatusEnum.Positive, Name = "Positive" },
                new VerificationStatus { Id = (int)VerificationStatusEnum.Negative, Name = "Negative" }
            );
        }
    }
}
