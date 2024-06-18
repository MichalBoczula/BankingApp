using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Banking.Persistance")]
[assembly: InternalsVisibleTo("Banking.Persistance.UnitTests")]
namespace Banking.Domain.Entities
{
    internal class Customer
    {
        public int Id { get; set; }
        public Guid CustomerNumber { get; set; }
        public int PersonalDataId { get; set; }
        public PersonalData PersonalDataRef { get; set; }
        public List<Address> Addresses { get; set; }
        public List<Email> Emails { get; set; }
        public List<Phone> Phones { get; set; }
        public List<BankingAccount> BankingAccounts { get; set; }
    }
}