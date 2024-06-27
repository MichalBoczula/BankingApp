using Banking.Application.Features.Commands.Emails.EditEmail;
using Banking.Persistance.Repositories.Commands.Abstract;
using BankingApp.DataTransferObject.Externals;
using FluentAssertions;
using Moq;

namespace Banking.Application.UnitTests.Features.Emails
{
    [TestFixture]
    public class EditEmailCommandHandlerTests
    {
        private Mock<ICommandsEmailDataRepository> _commandsEmailDataRepositoryMock;
        private EditEmailCommandHandler _handler;

        [SetUp]
        public void SetUp()
        {
            _commandsEmailDataRepositoryMock = new Mock<ICommandsEmailDataRepository>();
            _handler = new EditEmailCommandHandler(_commandsEmailDataRepositoryMock.Object);
        }

        [Test]
        public async Task Handle_ShouldReturnTrue_WhenEmailIsEditedSuccessfully()
        {
            // Arrange
            var command = new EditEmailCommand { Contract = new UpdatedEmailExternal{ Address = "updated@example.com" }, EmailId = 1 };
            var cancellationToken = new CancellationToken();

            _commandsEmailDataRepositoryMock
                .Setup(x => x.EditEmail(command.Contract, command.EmailId, cancellationToken))
                .ReturnsAsync(true);

            // Act
            var result = await _handler.Handle(command, cancellationToken);

            // Assert
            result.Should().BeTrue();
            _commandsEmailDataRepositoryMock.Verify(x => x.EditEmail(command.Contract, command.EmailId, cancellationToken), Times.Once);
        }

        [Test]
        public async Task Handle_ShouldReturnFalse_WhenEmailEditFails()
        {
            // Arrange
            var command = new EditEmailCommand { Contract = new UpdatedEmailExternal { Address = "updated@example.com" }, EmailId = 1 };
            var cancellationToken = new CancellationToken();

            _commandsEmailDataRepositoryMock
                .Setup(x => x.EditEmail(command.Contract, command.EmailId, cancellationToken))
                .ReturnsAsync(false);

            // Act
            var result = await _handler.Handle(command, cancellationToken);

            // Assert
            result.Should().BeFalse();
            _commandsEmailDataRepositoryMock.Verify(x => x.EditEmail(command.Contract, command.EmailId, cancellationToken), Times.Once);
        }

        [Test]
        public async Task Handle_ShouldThrowException_WhenRepositoryThrowsException()
        {
            // Arrange
            var command = new EditEmailCommand { Contract = new UpdatedEmailExternal { Address = "updated@example.com" }, EmailId = 1 };
            var cancellationToken = new CancellationToken();

            _commandsEmailDataRepositoryMock
                .Setup(x => x.EditEmail(command.Contract, command.EmailId, cancellationToken))
                .ThrowsAsync(new System.Exception("Repository error"));

            // Act
            Func<Task> act = async () => await _handler.Handle(command, cancellationToken);

            // Assert
            await act.Should().ThrowAsync<System.Exception>().WithMessage("Repository error");
        }
    }
}
