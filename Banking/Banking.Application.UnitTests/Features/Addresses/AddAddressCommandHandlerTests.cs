using Banking.Application.Features.Commands.Addresses.AddAddress;
using Banking.Persistance.Repositories.Commands.Abstract;
using BankingApp.DataTransferObject.Externals;
using FluentAssertions;
using Moq;

namespace Banking.Application.UnitTests.Features.Addresses
{
    [TestFixture]
    public class AddAddressCommandHandlerTests
    {
        private Mock<ICommandsAddressDataRepository> _commandsAddressDataRepositoryMock;
        private AddAddressCommandHandler _handler;

        [SetUp]
        public void SetUp()
        {
            _commandsAddressDataRepositoryMock = new Mock<ICommandsAddressDataRepository>();
            _handler = new AddAddressCommandHandler(_commandsAddressDataRepositoryMock.Object);
        }

        [Test]
        public async Task Handle_ShouldReturnResultFromRepository_WhenCalled()
        {
            // Arrange
            var command = new AddAddressCommand { Contract = new CreatedAddressExternal() };
            var cancellationToken = new CancellationToken();
            var expectedResult = 1;

            _commandsAddressDataRepositoryMock
                .Setup(x => x.AddAddress(command.Contract, cancellationToken))
                .ReturnsAsync(expectedResult);

            // Act
            var result = await _handler.Handle(command, cancellationToken);

            // Assert
            result.Should().Be(expectedResult);
            _commandsAddressDataRepositoryMock.Verify(x => x.AddAddress(command.Contract, cancellationToken), Times.Once);
        }

        [Test]
        public async Task Handle_ShouldThrowException_WhenRepositoryThrowsException()
        {
            // Arrange
            var command = new AddAddressCommand { Contract = new CreatedAddressExternal() };
            var cancellationToken = new CancellationToken();

            _commandsAddressDataRepositoryMock
                .Setup(x => x.AddAddress(command.Contract, cancellationToken))
                .ThrowsAsync(new Exception("Repository error"));

            // Act
            Func<Task> act = async () => await _handler.Handle(command, cancellationToken);

            // Assert
            await act.Should().ThrowAsync<Exception>().WithMessage("Repository error");
        }
    }
}
