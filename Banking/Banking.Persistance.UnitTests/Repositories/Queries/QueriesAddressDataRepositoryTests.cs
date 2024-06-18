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
    public class QueriesAddressDataRepositoryTests
    {
        private IMapper _mapper;
        private QueriesAddressDataRepository _repository;
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
            _repository = new QueriesAddressDataRepository(_context, _mapper);

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
            _context.Addresses.Add(new Address
            {
                Id = 1,
                PostCode = "11-111",
                City = "test",
                Street = "street",
                FlatNumber = "1",
                BuildingNumber = "4a"
            });
            _context.SaveChanges();
        }

        [Test]
        public async Task GetAddressById_ShouldReturnAddressDto_WhenAddressExists()
        {
            // Arrange
            var addressId = 1;
            var expectedAddressDto = new AddressDto
            {
                PostCode = "11-111",
                City = "test",
                Street = "street",
                FlatNumber = "1",
                BuildingNumber = "4a"
            };

            // Act
            var result = await _repository.GetAddressById(addressId);

            // Assert
            result.Should().BeEquivalentTo(expectedAddressDto);
        }

        [Test]
        public async Task GetAddressById_ShouldReturnNull_WhenAddressDoesNotExist()
        {
            // Arrange
            var addressId = 2;

            // Act
            var result = await _repository.GetAddressById(addressId);

            // Assert
            result.Should().BeNull();
        }
    }
}