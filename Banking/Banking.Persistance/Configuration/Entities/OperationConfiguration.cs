using Banking.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Banking.Persistance.Configuration.Entities
{
    internal class OperationConfiguration : IEntityTypeConfiguration<Operation>
    {
        public void Configure(EntityTypeBuilder<Operation> builder)
        {
            builder.HasKey(o => o.Id);

            builder.Property(o => o.OperationType)
                .IsRequired();

            builder.Property(o => o.FromAccount)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(o => o.ToAccount)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(o => o.Amount)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(o => o.OperationDate)
                .IsRequired();

            builder.HasOne(o => o.BankingAccountRef)
                .WithMany(b => b.Operations)
                .HasForeignKey(o => o.BankingAccountId);
        }
    }

}
