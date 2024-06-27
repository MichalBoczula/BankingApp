using Banking.Application.Features.Commands.Emails.DeleteEmail;
using Banking.Persistance.Repositories.Commands.Abstract;
using FluentAssertions;
using Moq;

namespace Banking.Application.UnitTests.Features.Emails
{
    [TestFixture]
    public class DeleteEmailCommandHandlerTests
    {
        private Mock<ICommandsEmailDataRepository> _commandsEmailDataRepositoryMock;
        private DeleteEmailCommandHandler _handler;

        [SetUp]
        public void SetUp()
        {
            _commandsEmailDataRepositoryMock = new Mock<ICommandsEmailDataRepository>();
            _handler = new DeleteEmailCommandHandler(_commandsEmailDataRepositoryMock.Object);
        }

        [Test]
        public async Task Handle_ShouldReturnTrue_WhenEmailIsDeletedSuccessfully()
        {
            // Arrange
            var command = new DeleteEmailCommand { EmailId = 1 };
            var cancellationToken = new CancellationToken();

            _commandsEmailDataRepositoryMock
                .Setup(x => x.DeleteEmail(command.EmailId, cancellationToken))
                .ReturnsAsync(true);

            // Act
            var result = await _handler.Handle(command, cancellationToken);

            // Assert
            result.Should().BeTrue();
            _commandsEmailDataRepositoryMock.Verify(x => x.DeleteEmail(command.EmailId, cancellationToken), Times.Once);
        }

        [Test]
        public async Task Handle_ShouldReturnFalse_WhenEmailDeletionFails()
        {
            // Arrange
            var command = new DeleteEmailCommand { EmailId = 1 };
            var cancellationToken = new CancellationToken();

            _commandsEmailDataRepositoryMock
                .Setup(x => x.DeleteEmail(command.EmailId, cancellationToken))
                .ReturnsAsync(false);

            // Act
            var result = await _handler.Handle(command, cancellationToken);

            // Assert
            result.Should().BeFalse();
            _commandsEmailDataRepositoryMock.Verify(x => x.DeleteEmail(command.EmailId, cancellationToken), Times.Once);
        }

        [Test]
        public async Task Handle_ShouldThrowException_WhenRepositoryThrowsException()
        {
            // Arrange
            var command = new DeleteEmailCommand { EmailId = 1 };
            var cancellationToken = new CancellationToken();

            _commandsEmailDataRepositoryMock
                .Setup(x => x.DeleteEmail(command.EmailId, cancellationToken))
                .ThrowsAsync(new System.Exception("Repository error"));

            // Act
            Func<Task> act = async () => await _handler.Handle(command, cancellationToken);

            // Assert
            await act.Should().ThrowAsync<System.Exception>().WithMessage("Repository error");
        }
    }
}
