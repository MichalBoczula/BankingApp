using AutoMapper;
using Banking.Domain.Entities;
using Banking.Persistance.Context;
using Banking.Persistance.Profiles.Commands;
using Banking.Persistance.Repositories.Commands.Concrete;
using BankingApp.DataTransferObject.Externals;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;

namespace Banking.Persistance.UnitTests.Repositories.Commands
{
    [TestFixture]
    public class CommandsAddressDataRepositoryTests
    {
        private IMapper _mapper;
        private CommandsAddressDataRepository _repository;
        private CommandDbContext _context;

        [SetUp]
        public void SetUp()
        {
            var options = new DbContextOptionsBuilder<CommandDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            _context = new CommandDbContext(options);

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CommandsMappingProfiles>();
            });

            _mapper = config.CreateMapper();
            _repository = new CommandsAddressDataRepository(_context, _mapper);

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
                BuildingNumber = "4a",
                FlatNumber = "10"
            });
            _context.SaveChanges();
        }

        [Test]
        public async Task AddAddress_ShouldReturnAddressId_WhenAddressIsAdded()
        {
            // Arrange
            var address = new CreatedAddressExternal
            {
                PostCode = "22-222",
                City = "new city",
                Street = "new street",
                BuildingNumber = "5b",
                FlatNumber = "2"
            };

            // Act
            var result = await _repository.AddAddress(address, CancellationToken.None);

            // Assert
            result.Should().BeGreaterThan(0);
            var addedAddress = await _context.Addresses.FindAsync(result);
            addedAddress.Should().NotBeNull();
        }

        [Test]
        public async Task EditAddress_ShouldReturnTrue_WhenAddressIsUpdated()
        {
            // Arrange
            var address = new UpdatedAddressExternal
            {
                PostCode = "33-333",
                City = "updated city",
                Street = "updated street",
                BuildingNumber = "7c",
                FlatNumber = "3"
            };
            var addressId = 1;

            // Act
            var result = await _repository.EditAddress(address, addressId, CancellationToken.None);

            // Assert
            result.Should().BeTrue();
            var updatedAddress = await _context.Addresses.FindAsync(addressId);
            updatedAddress.Should().NotBeNull();
            updatedAddress.PostCode.Should().Be(address.PostCode);
            updatedAddress.City.Should().Be(address.City);
            updatedAddress.Street.Should().Be(address.Street);
            updatedAddress.BuildingNumber.Should().Be(address.BuildingNumber);
            updatedAddress.FlatNumber.Should().Be(address.FlatNumber);
        }

        [Test]
        public async Task EditAddress_ShouldReturnFalse_WhenAddressDoesNotExist()
        {
            // Arrange
            var address = new UpdatedAddressExternal
            {
                PostCode = "33-333",
                City = "updated city",
                Street = "updated street",
                BuildingNumber = "7c",
                FlatNumber = "3"
            };
            var addressId = 999;

            // Act
            var result = await _repository.EditAddress(address, addressId, CancellationToken.None);

            // Assert
            result.Should().BeFalse();
        }

        [Test]
        public async Task DeleteAddress_ShouldReturnTrue_WhenAddressIsDeleted()
        {
            // Arrange
            var addressId = 1;

            // Act
            var result = await _repository.DeleteAddress(addressId, CancellationToken.None);

            // Assert
            result.Should().BeTrue();
            var deletedAddress = await _context.Addresses.FindAsync(addressId);
            deletedAddress.Should().BeNull();
        }

        [Test]
        public async Task DeleteAddress_ShouldReturnFalse_WhenAddressDoesNotExist()
        {
            // Arrange
            var addressId = 999;

            // Act
            var result = await _repository.DeleteAddress(addressId, CancellationToken.None);

            // Assert
            result.Should().BeFalse();
        }
    }

}
