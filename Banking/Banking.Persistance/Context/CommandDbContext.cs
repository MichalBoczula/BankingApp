using Banking.Domain.Dictionaries.Tables;
using Banking.Domain.Entities;
using Banking.Persistance.Repositories.Base;
using Banking.Persistance.Seed;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Banking.Persistance.UnitTests")]
namespace Banking.Persistance.Context
{
    internal class CommandDbContext : DbContext, ICommandDbContext
    {
        //Entities
        public DbSet<Address> Addresses { get; set; }
        public DbSet<BankingAccount> BankingAccounts { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Email> Emails { get; set; }
        public DbSet<Operation> Operations { get; set; }
        public DbSet<PersonalData> PersonalData { get; set; }
        public DbSet<Phone> Phones { get; set; }

        //Dictionaries
        public DbSet<AccountType> AccountTypes { get; set; }
        public DbSet<DocumentType> DocumentTypes { get; set; }
        public DbSet<OperationType> OperationTypes { get; set; }
        public DbSet<VerificationStatus> VerificationStatuses { get; set; }

        public CommandDbContext([NotNull] DbContextOptions<CommandDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.Seed();
        }
    }
}
