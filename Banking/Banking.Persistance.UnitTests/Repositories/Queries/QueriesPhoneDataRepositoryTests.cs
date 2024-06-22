using AutoMapper;
using Banking.Domain.Entities;
using Banking.Persistance.Context;
using Banking.Persistance.Profiles.Queries;
using Banking.Persistance.Repositories.Queries.Concrete;
using BankingApp.DataTransferObject.Internals.CutomerPersonalData;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;

namespace Banking.Persistance.UnitTests.Repositories.Queries
{
    [TestFixture]
    public class QueriesPhoneDataRepositoryTests
    {
        private IMapper _mapper;
        private QueriesPhoneDataRepository _repository;
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
            _repository = new QueriesPhoneDataRepository(_context, _mapper);

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
            _context.Phones.Add(new Phone
            {
                CountryCode = "+48",
                Number = "123456789"
            });
            _context.SaveChanges();
        }

        [Test]
        public async Task GetPhoneById_ShouldReturnPhoneDto_WhenPhoneExists()
        {
            // Arrange
            var phoneId = 1;
            var expectedDto = new PhoneDto
            {
                CountryCode = "+48",
                Number = "123456789"
            };

            // Act
            var result = await _repository.GetPhoneById(phoneId);

            // Assert
            result.Should().BeEquivalentTo(expectedDto);
        }

        [Test]
        public async Task GetPhoneById_ShouldReturnNull_WhenPhoneDoesNotExist()
        {
            // Arrange
            var phoneId = 999;

            // Act
            var result = await _repository.GetPhoneById(phoneId);

            // Assert
            result.Should().BeNull();
        }
    }
}
