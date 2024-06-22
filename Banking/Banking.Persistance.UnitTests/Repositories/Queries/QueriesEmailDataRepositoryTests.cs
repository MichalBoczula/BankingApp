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
    public class QueriesEmailDataRepositoryTests
    {
        private IMapper _mapper;
        private QueriesEmailDataRepository _repository;
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
            _repository = new QueriesEmailDataRepository(_context, _mapper);

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
            _context.Emails.Add(new Email
            {
                Id = 1,
                Address = "test@example.com"
            });
            _context.SaveChanges();
        }

        [Test]
        public async Task GetEmailById_ShouldReturnEmailDto_WhenEmailExists()
        {
            // Arrange
            var emailId = 1;
            var expectedDto = new EmailDto
            {
                Address = "test@example.com"
            };

            // Act
            var result = await _repository.GetEmailById(emailId);

            // Assert
            result.Should().BeEquivalentTo(expectedDto);
        }

        [Test]
        public async Task GetEmailById_ShouldReturnNull_WhenEmailDoesNotExist()
        {
            // Arrange
            var emailId = 999;

            // Act
            var result = await _repository.GetEmailById(emailId);

            // Assert
            result.Should().BeNull();
        }
    }
}
