using BankingApp.DataTransferObject.Enums;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Banking.Persistance")]
namespace Banking.Domain.Entities
{
    internal class Email
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public VerificationStatusEnum VerificationStatus { get; set; }
        public int CustomerId { get; set; }
        public Customer CustomerRef { get; set; }
    }
}
