using BankingApp.DataTransferObject.Enums;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Banking.Persistance")]
namespace Banking.Domain.Entities
{
    internal class PersonalData
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string IdentityNumber { get; set; }
        public DocumentTypeEnum DocumentType { get; set; }
        public int CustomerId { get; set; }
        public Customer CustomerRef { get; set; }
    }
}
