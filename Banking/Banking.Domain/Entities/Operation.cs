using Banking.Domain.Dictionaries.Enums;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Banking.Persistance")]
namespace Banking.Domain.Entities
{
    internal class Operation
    {
        public int Id { get; set; }
        public OperationTypeEnum OperationType { get; set; }
        public string FromAccount { get; set; }
        public string ToAccount { get; set; }
        public decimal Amount { get; set; }
        public DateTime OperationDate { get; set; }
        public int BankingAccountId { get; set; }
        public BankingAccount BankingAccountRef { get; set; }
    }
}
