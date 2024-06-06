namespace Banking.Domain.Entities
{
    internal class Customer
    {
        public int Id { get; set; }
        public Guid AccountNumber { get; set; }
        public int PersonalDataId { get; set; }
        public PersonalData PersonalDataRef { get; set; }
        public List<Address> Addresses { get; set; }
        public List<Email> Emails { get; set; }
        public List<Phone> Phones { get; set; }
    }
}