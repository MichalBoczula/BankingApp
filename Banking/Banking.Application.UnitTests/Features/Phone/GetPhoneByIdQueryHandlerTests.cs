using Banking.Application.Features.Queries.Emails;
using Banking.Application.Features.Queries.Phones.GetPhoneById;
using Banking.Persistance.Repositories.Queries.Abstract;
using BankingApp.DataTransferObject.Internals.CutomerPersonalData;
using FluentAssertions;
using Moq;

namespace Banking.Application.UnitTests.Features.Phone
{
    [TestFixture]
    public class GetPhoneByIdQueryHandlerTests
    {
        private Mock<IQueriesPhoneDataRepository> _queriesPhoneDataRepositoryMock;
        private GetPhoneByIdQueryHandler _handler;

        [SetUp]
        public void SetUp()
        {
            _queriesPhoneDataRepositoryMock = new Mock<IQueriesPhoneDataRepository>();
            _handler = new GetPhoneByIdQueryHandler(_queriesPhoneDataRepositoryMock.Object);
        }

        [Test]
        public async Task Handle_ShouldReturnAddress_WhenPhoneExists()
        {
            // Arrange
            var phoneId = 1;
            var expectedPhone = new PhoneDto
            {
                CountryCode = "1",
                Number = "123456789",
            };

            _queriesPhoneDataRepositoryMock
                .Setup(repo => repo.GetPhoneById(phoneId))
                .ReturnsAsync(expectedPhone);

            var query = new GetPhoneByIdQuery { PhoneId = phoneId };

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(expectedPhone);

            _queriesPhoneDataRepositoryMock.Verify(repo => repo.GetPhoneById(phoneId), Times.Once);
        }

        [Test]
        public async Task Handle_ShouldReturnNull_WhenPhoneDoesNotExist()
        {
            // Arrange
            var phoneId = 1;

            _queriesPhoneDataRepositoryMock
                .Setup(repo => repo.GetPhoneById(phoneId))
                .ReturnsAsync((PhoneDto)null);

            var query = new GetPhoneByIdQuery { PhoneId = phoneId };

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            result.Should().BeNull();

            _queriesPhoneDataRepositoryMock.Verify(repo => repo.GetPhoneById(phoneId), Times.Once);
        }
    }
}
