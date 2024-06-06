using Banking.Domain.Dictionaries.Enums;

namespace Banking.Domain.Entities
{
    internal class PersonalData
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string IdentityNumber { get; set; }
        public DocumentType DocumentType { get; set; }
        public int CustomerId { get; set; }
        public Customer CustomerRef { get; set; }
    }
}
