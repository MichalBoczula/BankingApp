using Banking.Domain.Dictionaries.Enums;

namespace Banking.Domain.Entities
{
    internal class BankingAccount
    {
        public int Id { get; set; }
        public string AccountNumber { get; set; }
        public decimal Balance { get; private set; }
        public AccountType AccountType { get; set; }
        public List<Operation> Operations { get; set; }
    }
}
