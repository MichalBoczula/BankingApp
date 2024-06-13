using Banking.Domain.Entities;
using BankingApp.DataTransferObject.Enums;
using Microsoft.EntityFrameworkCore;

namespace Banking.Persistance.Seed
{
    internal static class DataSeed
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            #region Customer Seed Data
            var firstCustomerId = 1;
            var secondCustomerId = 2;
            var thirdCustomerId = 3;

            modelBuilder.Entity<Customer>().HasData(
                new Customer
                {
                    Id = firstCustomerId,
                    CustomerNumber = new Guid("d5212365-524a-430d-ac75-14a0983edf62"),
                    PersonalDataId = firstCustomerId
                },
                new Customer
                {
                    Id = secondCustomerId,
                    CustomerNumber = new Guid("64652d35-1df7-4331-80ef-aef7d620e046"),
                    PersonalDataId = secondCustomerId
                },
                new Customer
                {
                    Id = thirdCustomerId,
                    CustomerNumber = new Guid("7febeceb-6e20-4151-871b-d5324c0f735b"),
                    PersonalDataId = thirdCustomerId
                });
            #endregion

            #region Address Seed Data
            modelBuilder.Entity<Address>().HasData(
                new Address
                {
                    Id = 1,
                    Street = "123 Main St",
                    City = "CityA",
                    PostCode = "10001",
                    BuildingNumber = "1",
                    FlatNumber = "101",
                    VerificationStatus = VerificationStatusEnum.Positive,
                    CustomerId = firstCustomerId
                },
                new Address
                {
                    Id = 2,
                    Street = "456 Elm St",
                    City = "CityB",
                    PostCode = "10002",
                    BuildingNumber = "2",
                    FlatNumber = "202",
                    VerificationStatus = VerificationStatusEnum.Positive,
                    CustomerId = secondCustomerId
                },
                new Address
                {
                    Id = 3,
                    Street = "789 Oak St",
                    City = "CityC",
                    PostCode = "10003",
                    BuildingNumber = "3",
                    FlatNumber = "303",
                    VerificationStatus = VerificationStatusEnum.Positive,
                    CustomerId = thirdCustomerId
                }
            );
            #endregion

            #region Email Seed Data
            modelBuilder.Entity<Email>().HasData(
                new Email
                {
                    Id = 1,
                    Address = "customer1@example.com",
                    VerificationStatus = VerificationStatusEnum.Positive,
                    CustomerId = firstCustomerId
                },
                new Email
                {
                    Id = 2,
                    Address = "customer2@example.com",
                    VerificationStatus = VerificationStatusEnum.Positive,
                    CustomerId = secondCustomerId
                },
                new Email
                {
                    Id = 3,
                    Address = "customer3@example.com",
                    VerificationStatus = VerificationStatusEnum.Positive,
                    CustomerId = thirdCustomerId
                }
            );
            #endregion

            #region BankingAccount Seed Data
            modelBuilder.Entity<BankingAccount>().HasData(
                new BankingAccount
                {
                    Id = 1,
                    AccountNumber = "ACC001",
                    Balance = 1000.00M,
                    AccountType = AccountTypeEnum.Personal,
                    CustomerId = firstCustomerId
                },
                new BankingAccount
                {
                    Id = 2,
                    AccountNumber = "ACC002",
                    Balance = 2000.00M,
                    AccountType = AccountTypeEnum.Personal,
                    CustomerId = secondCustomerId
                },
                new BankingAccount
                {
                    Id = 3,
                    AccountNumber = "ACC003",
                    Balance = 3000.00M,
                    AccountType = AccountTypeEnum.Personal,
                    CustomerId = thirdCustomerId
                }
            );
            #endregion

            #region PersonalData Seed Data
            modelBuilder.Entity<PersonalData>().HasData(
                new PersonalData
                {
                    Id = 1,
                    FirstName = "John",
                    LastName = "Doe",
                    DateOfBirth = new DateTime(1985, 1, 1),
                    IdentityNumber = "1234567890",
                    DocumentType = DocumentTypeEnum.IdCard,
                    CustomerId = firstCustomerId
                },
                new PersonalData
                {
                    Id = 2,
                    FirstName = "Jane",
                    LastName = "Smith",
                    DateOfBirth = new DateTime(1990, 2, 2),
                    IdentityNumber = "0987654321",
                    DocumentType = DocumentTypeEnum.Passport,
                    CustomerId = secondCustomerId
                },
                new PersonalData
                {
                    Id = 3,
                    FirstName = "Alice",
                    LastName = "Johnson",
                    DateOfBirth = new DateTime(1980, 3, 3),
                    IdentityNumber = "1122334455",
                    DocumentType = DocumentTypeEnum.IdCard,
                    CustomerId = thirdCustomerId
                }
            );
            #endregion

            #region Phone Seed Data
            modelBuilder.Entity<Phone>().HasData(
                new Phone
                {
                    Id = 1,
                    CountryCode = "+1",
                    Number = "123456789",
                    VerificationStatus = VerificationStatusEnum.Positive,
                    CustomerId = firstCustomerId
                },
                new Phone
                {
                    Id = 2,
                    CountryCode = "+1",
                    Number = "987654321",
                    VerificationStatus = VerificationStatusEnum.Positive,
                    CustomerId = secondCustomerId
                },
                new Phone
                {
                    Id = 3,
                    CountryCode = "+1",
                    Number = "555666777",
                    VerificationStatus = VerificationStatusEnum.Positive,
                    CustomerId = thirdCustomerId
                }
            );
            #endregion
        }
    }
}
