using BankingApp.DataTransferObject.Enums;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Banking.Persistance")]
namespace Banking.Domain.Entities
{
    internal class BankingAccount
    {
        public int Id { get; set; }
        public string AccountNumber { get; set; }
        public decimal Balance { get; set; }
        public AccountTypeEnum AccountType { get; set; }
        public List<Operation> Operations { get; set; }
        public int CustomerId { get; set; }
        public Customer CustomerRef { get; set; }
    }
}
