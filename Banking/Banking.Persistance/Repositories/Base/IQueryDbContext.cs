using Banking.Domain.Dictionaries.Tables;
using Banking.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Banking.Persistance.Repositories.Base
{
    internal interface IQueryDbContext
    {       
        //Entities
        public DbSet<Address> Addresses { get; set; }
        public DbSet<BankingAccount> BankingAccounts { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Email> Emails { get; set; }
        public DbSet<Operation> Operations { get; set; }
        public DbSet<PersonalData> PersonalData { get; set; }
        public DbSet<Phone> Phones { get; set; }

        public DbSet<AccountType> AccountTypes { get; set; }
        public DbSet<DocumentType> DocumentTypes { get; set; }
        public DbSet<OperationType> OperationTypes { get; set; }
        public DbSet<VerificationStatus> VerificationStatuses { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
