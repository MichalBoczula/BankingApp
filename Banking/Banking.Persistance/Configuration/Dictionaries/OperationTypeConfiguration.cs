using Banking.Domain.Dictionaries.Enums;
using Banking.Domain.Dictionaries.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Banking.Persistance.Configuration.Dictionaries
{
    internal class OperationTypeConfiguration : IEntityTypeConfiguration<OperationType>
    {
        public void Configure(EntityTypeBuilder<OperationType> builder)
        {
            builder.HasKey(ot => ot.Id);

            builder.Property(ot => ot.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasData(
                new OperationType { Id = (int)OperationTypeEnum.BankingTransfer, Name = "BankingTransfer" },
                new OperationType { Id = (int)OperationTypeEnum.AtmOperation, Name = "AtmOperation" },
                new OperationType { Id = (int)OperationTypeEnum.BLIK, Name = "BLIK" },
                new OperationType { Id = (int)OperationTypeEnum.CardPayment, Name = "CardPayment" }
            );
        }
    }

}
