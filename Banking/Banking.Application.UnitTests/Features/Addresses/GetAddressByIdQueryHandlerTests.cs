using Banking.Application.Features.Queries.Addresses.GetAddressById;
using Banking.Persistance.Repositories.Queries.Abstract;
using BankingApp.DataTransferObject.Internals.CutomerPersonalData;
using FluentAssertions;
using Moq;

namespace Banking.Application.UnitTests.Features.Addresses
{
    [TestFixture]
    public class GetAddressByIdQueryHandlerTests
    {
        private Mock<IQueriesAddressDataRepository> _queriesAddressDataRepositoryMock;
        private GetAddressByIdQueryHandler _handler;

        [SetUp]
        public void SetUp()
        {
            _queriesAddressDataRepositoryMock = new Mock<IQueriesAddressDataRepository>();
            _handler = new GetAddressByIdQueryHandler(_queriesAddressDataRepositoryMock.Object);
        }

        [Test]
        public async Task Handle_ShouldReturnAddress_WhenAddressExists()
        {
            // Arrange
            var addressId = 1;
            var expectedAddress = new AddressDto
            {
                Street = "123 Main St",
                City = "Anytown",
            };

            _queriesAddressDataRepositoryMock
                .Setup(repo => repo.GetAddressById(addressId))
                .ReturnsAsync(expectedAddress);

            var query = new GetAddressByIdQuery { AddressId = addressId };

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(expectedAddress);

            _queriesAddressDataRepositoryMock.Verify(repo => repo.GetAddressById(addressId), Times.Once);
        }

        [Test]
        public async Task Handle_ShouldReturnNull_WhenAddressDoesNotExist()
        {
            // Arrange
            var addressId = 1;

            _queriesAddressDataRepositoryMock
                .Setup(repo => repo.GetAddressById(addressId))
                .ReturnsAsync((AddressDto)null);

            var query = new GetAddressByIdQuery { AddressId = addressId };

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            result.Should().BeNull();

            _queriesAddressDataRepositoryMock.Verify(repo => repo.GetAddressById(addressId), Times.Once);
        }
    }
}
