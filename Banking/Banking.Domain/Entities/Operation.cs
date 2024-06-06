using Banking.Domain.Dictionaries.Enums;

namespace Banking.Domain.Entities
{
    internal class Operation
    {
        public int Id { get; set; }
        public OperationType OperationType { get; set; }
        public string FromAccount { get; set; }
        public string ToAccount { get; set; }
        public decimal Amount { get; set; }
        public DateTime OperationDate { get; set; }
        public int BankingAccountId { get; set; }
        public BankingAccount BankingAccountRef { get; set; }
        public int CustomerId { get; set; }
        public Customer CustomerRef { get; set; }
    }
}
