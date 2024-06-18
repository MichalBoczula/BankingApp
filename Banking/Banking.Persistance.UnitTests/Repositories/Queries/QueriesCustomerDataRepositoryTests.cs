using AutoMapper;
using Banking.Domain.Entities;
using Banking.Persistance.Context;
using Banking.Persistance.Profiles.Queries;
using Banking.Persistance.Repositories.Queries.Concrete;
using BankingApp.DataTransferObject.Enums;
using BankingApp.DataTransferObject.Internals.CustomerAccountData;
using BankingApp.DataTransferObject.Internals.CutomerPersonalData;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;

namespace Banking.Persistance.UnitTests.Repositories.Queries
{
    [TestFixture]
    public class QueriesCustomerDataRepositoryTests
    {
        private IMapper _mapper;
        private QueriesCustomerDataRepository _repository;
        private QueryDbContext _context;

        [SetUp]
        public void SetUp()
        {
            var options = new DbContextOptionsBuilder<QueryDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            _context = new QueryDbContext(options);

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<QueriesMappingProfiles>();
            });

            _mapper = config.CreateMapper();
            _repository = new QueriesCustomerDataRepository(_context, _mapper);

            SeedDatabase();
        }

        [TearDown]
        public void TearDown()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }

        private void SeedDatabase()
        {
            var customer = new Customer
            {
                CustomerNumber = Guid.Parse("be48f826-d03c-4cc1-b6ec-629e4ea1be19"),
                PersonalDataId = 1,
                PersonalDataRef = new PersonalData
                {
                    FirstName = "Joe",
                    LastName = "Doe",
                    DateOfBirth = DateTime.UtcNow,
                    IdentityNumber = "adc",
                    DocumentType = DocumentTypeEnum.IdCard,
                    CustomerId = 1
                },
                Addresses = new List<Address>
                {
                    new Address
                    {
                        PostCode = "12345",
                        City = "City1",
                        Street = "Street1",
                        BuildingNumber = "1",
                        FlatNumber = "2"
                    }
                },
                Emails = new List<Email>
                {
                    new Email
                    {
                        Address = "john.doe@example.com",
                        VerificationStatus = VerificationStatusEnum.Positive,
                        CustomerId = 1
                    }
                },
                Phones = new List<Phone>
                {
                    new Phone
                    {
                        Number = "123456789",
                        CountryCode = "1",
                        VerificationStatus =VerificationStatusEnum.Positive,
                        CustomerId = 1
                    }
                },
                BankingAccounts = new List<BankingAccount>
                {
                    new BankingAccount
                    {
                        AccountNumber = "1234567890",
                        Balance = 1000,
                        AccountType = AccountTypeEnum.Personal,
                        Operations = new List<Operation>
                        {
                            new Operation
                            {
                                OperationType = OperationTypeEnum.AtmOperation,
                                FromAccount = "aaa",
                                ToAccount = string.Empty,
                                OperationDate = DateTime.Today,
                                BankingAccountId = 1,
                                Amount = 500
                            }
                        },
                        CustomerId = 1
                    }
                }
            };

            _context.Customers.Add(customer);
            _context.SaveChanges();
        }

        [Test]
        public void QueriesConfigurationIsValid()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<QueriesMappingProfiles>();
            });

            config.AssertConfigurationIsValid();
        }

        [Test]
        public async Task GetCustomerAccountData_ShouldReturnCustomerAccountDataDto_WhenCustomerExists()
        {
            // Arrange
            var customerNumber = _context.Customers.First().CustomerNumber;
            var expectedDto = new CustomerAccountDataDto
            {
                CustomerNumber = customerNumber,
                BankingAccounts = new List<BankingAccountDto>
                {
                    new BankingAccountDto
                    {
                         AccountNumber = "1234567890",
                        Balance = 1000,
                        AccountType = AccountTypeEnum.Personal,
                        Operations = new List<OperationDto>
                        {
                            new OperationDto
                            {
                                OperationType = OperationTypeEnum.AtmOperation,
                                FromAccount = "aaa",
                                ToAccount = string.Empty,
                                OperationDate = DateTime.Today,
                                Amount = 500
                            }
                        },
                    }
                }
            };

            // Act
            var result = await _repository.GetCustomerAccountData(customerNumber);

            // Assert
            result.Should().BeEquivalentTo(expectedDto);
        }

        [Test]
        public async Task GetCustomerPersonalData_ShouldReturnCustomerPersonalDataDto_WhenCustomerExists()
        {
            // Arrange
            var customerNumber = _context.Customers.First().CustomerNumber;
            var expectedDto = new CustomerPersonalDataDto
            {
                CustomerNumber = Guid.Parse("be48f826-d03c-4cc1-b6ec-629e4ea1be19"),
                Addresses = new List<AddressDto>
                {
                    new AddressDto
                    {
                        PostCode = "12345",
                        City = "City1",
                        Street = "Street1",
                        BuildingNumber = "1",
                        FlatNumber = "2"
                    }
                },
                Emails = new List<EmailDto>
                {
                    new EmailDto
                    {
                        Address = "john.doe@example.com",
                        VerificationStatus = VerificationStatusEnum.Positive,
                    }
                },
                Phones = new List<PhoneDto>
                {
                    new PhoneDto
                    {
                        Number = "123456789",
                        CountryCode = "1",
                        VerificationStatus =VerificationStatusEnum.Positive,
                    }
                }
            };

            // Act
            var result = await _repository.GetCustomerPersonalData(customerNumber);

            // Assert
            result.Should().BeEquivalentTo(expectedDto);
        }

        [Test]
        public async Task GetCustomerAccountData_ShouldReturnNull_WhenCustomerDoesNotExist()
        {
            // Arrange
            var customerNumber = Guid.NewGuid();

            // Act
            var result = await _repository.GetCustomerAccountData(customerNumber);

            // Assert
            result.Should().BeNull();
        }

        [Test]
        public async Task GetCustomerPersonalData_ShouldReturnNull_WhenCustomerDoesNotExist()
        {
            // Arrange
            var customerNumber = Guid.NewGuid();

            // Act
            var result = await _repository.GetCustomerPersonalData(customerNumber);

            // Assert
            result.Should().BeNull();
        }
    }
}
