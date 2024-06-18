using Banking.Application.Features.Commands.Addresses.EditAddress;
using Banking.Persistance.Repositories.Commands.Abstract;
using BankingApp.DataTransferObject.Externals;
using FluentAssertions;
using Moq;

namespace Banking.Application.UnitTests.Features.Addresses
{
    public class EditAddressCommandHandlerTests
    {
        private Mock<ICommandsAddressDataRepository> _commandsAddressDataRepositoryMock;
        private EditAddressCommandHandler _handler;

        [SetUp]
        public void SetUp()
        {
            _commandsAddressDataRepositoryMock = new Mock<ICommandsAddressDataRepository>();
            _handler = new EditAddressCommandHandler(_commandsAddressDataRepositoryMock.Object);
        }

        [Test]
        public async Task Handle_ShouldReturnTrue_WhenEditIsSuccessful()
        {
            // Arrange
            var command = new EditAddressCommand { Contract = new UpdatedAddressExternal(), AddressId = 1 };
            var cancellationToken = new CancellationToken();

            _commandsAddressDataRepositoryMock
                .Setup(x => x.EditAddress(command.Contract, command.AddressId, cancellationToken))
                .ReturnsAsync(true);

            // Act
            var result = await _handler.Handle(command, cancellationToken);

            // Assert
            result.Should().BeTrue();
            _commandsAddressDataRepositoryMock.Verify(x => x.EditAddress(command.Contract, command.AddressId, cancellationToken), Times.Once);
        }

        [Test]
        public async Task Handle_ShouldReturnFalse_WhenEditIsUnsuccessful()
        {
            // Arrange
            var command = new EditAddressCommand { Contract = new UpdatedAddressExternal(), AddressId = 1 };
            var cancellationToken = new CancellationToken();

            _commandsAddressDataRepositoryMock
                .Setup(x => x.EditAddress(command.Contract, command.AddressId, cancellationToken))
                .ReturnsAsync(false);

            // Act
            var result = await _handler.Handle(command, cancellationToken);

            // Assert
            result.Should().BeFalse();
            _commandsAddressDataRepositoryMock.Verify(x => x.EditAddress(command.Contract, command.AddressId, cancellationToken), Times.Once);
        }

        [Test]
        public async Task Handle_ShouldThrowException_WhenRepositoryThrowsException()
        {
            // Arrange
            var command = new EditAddressCommand { Contract = new UpdatedAddressExternal(), AddressId = 1 };
            var cancellationToken = new CancellationToken();

            _commandsAddressDataRepositoryMock
                .Setup(x => x.EditAddress(command.Contract, command.AddressId, cancellationToken))
                .ThrowsAsync(new Exception("Repository error"));

            // Act
            Func<Task> act = async () => await _handler.Handle(command, cancellationToken);

            // Assert
            await act.Should().ThrowAsync<Exception>().WithMessage("Repository error");
        }
    }
}