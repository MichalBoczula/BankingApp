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
    public class CommandsEmailDataRepositoryTests
    {
        private IMapper _mapper;
        private CommandsEmailDataRepository _repository;
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
            _repository = new CommandsEmailDataRepository(_context, _mapper);

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
        public async Task AddEmail_ShouldReturnEmailId_WhenEmailIsAdded()
        {
            // Arrange
            var email = new CreatedEmailExternal
            {
                Address = "new@example.com"
            };

            // Act
            var result = await _repository.AddEmail(email, CancellationToken.None);

            // Assert
            result.Should().BeGreaterThan(0);
            var addedEmail = await _context.Emails.FindAsync(result);
            addedEmail.Should().NotBeNull();
        }

        [Test]
        public async Task EditEmail_ShouldReturnTrue_WhenEmailIsUpdated()
        {
            // Arrange
            var email = new UpdatedEmailExternal
            {
                Address = "updated@example.com"
            };
            var emailId = 1;

            // Act
            var result = await _repository.EditEmail(email, emailId, CancellationToken.None);

            // Assert
            result.Should().BeTrue();
            var updatedEmail = await _context.Emails.FindAsync(emailId);
            updatedEmail.Should().NotBeNull();
            updatedEmail.Address.Should().Be(email.Address);
        }

        [Test]
        public async Task EditEmail_ShouldReturnFalse_WhenEmailDoesNotExist()
        {
            // Arrange
            var email = new UpdatedEmailExternal
            {
                Address = "updated@example.com"
            };
            var emailId = 999;

            // Act
            var result = await _repository.EditEmail(email, emailId, CancellationToken.None);

            // Assert
            result.Should().BeFalse();
        }

        [Test]
        public async Task DeleteEmail_ShouldReturnTrue_WhenEmailIsDeleted()
        {
            // Arrange
            var emailId = 1;

            // Act
            var result = await _repository.DeleteEmail(emailId, CancellationToken.None);

            // Assert
            result.Should().BeTrue();
            var deletedEmail = await _context.Emails.FindAsync(emailId);
            deletedEmail.Should().BeNull();
        }

        [Test]
        public async Task DeleteEmail_ShouldReturnFalse_WhenEmailDoesNotExist()
        {
            // Arrange
            var emailId = 999;

            // Act
            var result = await _repository.DeleteEmail(emailId, CancellationToken.None);

            // Assert
            result.Should().BeFalse();
        }
    }
}
