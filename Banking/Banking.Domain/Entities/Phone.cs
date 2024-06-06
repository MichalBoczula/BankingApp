using Banking.Domain.Dictionaries.Enums;

namespace Banking.Domain.Entities
{
    internal class Phone
    {
        public int Id { get; set; }
        public string CountryCode { get; set; }
        public string Number { get; set; }
        public VerificationStatus VerificationStatus { get; set; }
        public int CustomerId { get; set; }
        public Customer CustomerRef { get; set; }
    }
}
