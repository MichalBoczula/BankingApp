using Banking.Domain.Dictionaries.Tables;
using BankingApp.DataTransferObject.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Banking.Persistance.Configuration.Dictionaries
{
    internal class AccountTypeConfiguration : IEntityTypeConfiguration<AccountType>
    {
        public void Configure(EntityTypeBuilder<AccountType> builder)
        {
            builder.HasKey(at => at.Id);

            builder.Property(at => at.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasData(
                new AccountType { Id = (int)AccountTypeEnum.Business, Name = "Business" },
                new AccountType { Id = (int)AccountTypeEnum.Personal, Name = "Personal" }
            );
        }
    }
}
