using Banking.Domain.Dictionaries.Enums;

namespace Banking.Domain.Entities
{
    internal class Email
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public VerificationStatus VerificationStatus { get; set; }
        public int CustomerId { get; set; }
        public Customer CustomerRef { get; set; }
    }
}
