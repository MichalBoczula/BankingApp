using Banking.Application.Features.Commands.Addresses.DeleteAddress;
using Banking.Persistance.Repositories.Commands.Abstract;
using FluentAssertions;
using Moq;

namespace Banking.Application.UnitTests.Features.Addresses
{
    [TestFixture]
    public class DeleteAddressCommandHandlerTests
    {
        private Mock<ICommandsAddressDataRepository> _commandsAddressDataRepositoryMock;
        private DeleteAddressCommandHandler _handler;

        [SetUp]
        public void SetUp()
        {
            _commandsAddressDataRepositoryMock = new Mock<ICommandsAddressDataRepository>();
            _handler = new DeleteAddressCommandHandler(_commandsAddressDataRepositoryMock.Object);
        }

        [Test]
        public async Task Handle_ShouldReturnTrue_WhenDeleteIsSuccessful()
        {
            // Arrange
            var command = new DeleteAddressCommand { AddressId = 1 };
            var cancellationToken = new CancellationToken();

            _commandsAddressDataRepositoryMock
                .Setup(x => x.DeleteAddress(command.AddressId, cancellationToken))
                .ReturnsAsync(true);

            // Act
            var result = await _handler.Handle(command, cancellationToken);

            // Assert
            result.Should().BeTrue();
            _commandsAddressDataRepositoryMock.Verify(x => x.DeleteAddress(command.AddressId, cancellationToken), Times.Once);
        }

        [Test]
        public async Task Handle_ShouldReturnFalse_WhenDeleteIsUnsuccessful()
        {
            // Arrange
            var command = new DeleteAddressCommand { AddressId = 1 };
            var cancellationToken = new CancellationToken();

            _commandsAddressDataRepositoryMock
                .Setup(x => x.DeleteAddress(command.AddressId, cancellationToken))
                .ReturnsAsync(false);

            // Act
            var result = await _handler.Handle(command, cancellationToken);

            // Assert
            result.Should().BeFalse();
            _commandsAddressDataRepositoryMock.Verify(x => x.DeleteAddress(command.AddressId, cancellationToken), Times.Once);
        }

        [Test]
        public async Task Handle_ShouldThrowException_WhenRepositoryThrowsException()
        {
            // Arrange
            var command = new DeleteAddressCommand { AddressId = 1 };
            var cancellationToken = new CancellationToken();

            _commandsAddressDataRepositoryMock
                .Setup(x => x.DeleteAddress(command.AddressId, cancellationToken))
                .ThrowsAsync(new Exception("Repository error"));

            // Act
            Func<Task> act = async () => await _handler.Handle(command, cancellationToken);

            // Assert
            await act.Should().ThrowAsync<Exception>().WithMessage("Repository error");
        }
    }
}