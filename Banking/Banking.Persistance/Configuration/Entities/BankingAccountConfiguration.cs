using Banking.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Banking.Persistance.Configuration.Entities
{
    internal class BankingAccountConfiguration : IEntityTypeConfiguration<BankingAccount>
    {
        public void Configure(EntityTypeBuilder<BankingAccount> builder)
        {
            builder.HasKey(b => b.Id);

            builder.Property(b => b.AccountNumber)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(b => b.Balance)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(b => b.AccountType)
                .IsRequired();

            builder.HasOne(b => b.CustomerRef)
                .WithMany(c => c.BankingAccounts)
                .HasForeignKey(b => b.CustomerId);
        }
    }
}
