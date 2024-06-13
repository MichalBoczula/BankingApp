using Banking.Domain.Dictionaries.Tables;
using BankingApp.DataTransferObject.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Banking.Persistance.Configuration.Dictionaries
{
    internal class DocumentTypeConfiguration : IEntityTypeConfiguration<DocumentType>
    {
        public void Configure(EntityTypeBuilder<DocumentType> builder)
        {
            builder.HasKey(dt => dt.Id);

            builder.Property(dt => dt.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasData(
                new DocumentType { Id = (int)DocumentTypeEnum.IdCard, Name = "IdCard" },
                new DocumentType { Id = (int)DocumentTypeEnum.Passport, Name = "Passport" }
            );
        }
    }
}
