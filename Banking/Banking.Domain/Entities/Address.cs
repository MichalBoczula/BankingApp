using BankingApp.DataTransferObject.Enums;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Banking.Persistance")]
[assembly: InternalsVisibleTo("Banking.Persistance.UnitTests")]
namespace Banking.Domain.Entities
{
    internal class Address
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string PostCode { get; set; }
        public string BuildingNumber { get; set; }
        public string FlatNumber { get; set; }
        public VerificationStatusEnum VerificationStatus { get; set; }
        public int CustomerId { get; set; }
        public Customer CustomerRef { get; set; }
    }
}
