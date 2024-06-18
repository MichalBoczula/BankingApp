using BankingApp.DataTransferObject.Enums;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Banking.Persistance")]
[assembly: InternalsVisibleTo("Banking.Persistance.UnitTests")]
namespace Banking.Domain.Entities
{
    internal class Phone
    {
        public int Id { get; set; }
        public string CountryCode { get; set; }
        public string Number { get; set; }
        public VerificationStatusEnum VerificationStatus { get; set; }
        public int CustomerId { get; set; }
        public Customer CustomerRef { get; set; }
    }
}
