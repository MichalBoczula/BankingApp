using Banking.Application.Features.Commands.Emails.AddEmail;
using Banking.Persistance.Repositories.Commands.Abstract;
using FluentAssertions;
using Moq;
using BankingApp.DataTransferObject.Externals;
using BankingApp.DataTransferObject.Enums;

namespace Banking.Application.UnitTests.Features.Emails
{
    [TestFixture]
    public class AddEmailCommandHandlerTests
    {
        private Mock<ICommandsEmailDataRepository> _commandsEmailDataRepositoryMock;
        private AddEmailCommandHandler _handler;

        [SetUp]
        public void SetUp()
        {
            _commandsEmailDataRepositoryMock = new Mock<ICommandsEmailDataRepository>();
            _handler = new AddEmailCommandHandler(_commandsEmailDataRepositoryMock.Object);
        }

        [Test]
        public async Task Handle_ShouldReturnEmailId_WhenEmailIsAddedSuccessfully()
        {
            // Arrange
            var emailId = 1;
            var command = new AddEmailCommand 
            { 
                Contract = new CreatedEmailExternal
                {
                    Address = "test@example.com",
                    CustomerId = 1,
                    VerificationStatus = VerificationStatusEnum.Positive
                } 
            };

            var cancellationToken = new CancellationToken();

            _commandsEmailDataRepositoryMock
                .Setup(x => x.AddEmail(command.Contract, cancellationToken))
                .ReturnsAsync(emailId);

            // Act
            var result = await _handler.Handle(command, cancellationToken);

            // Assert
            result.Should().Be(emailId);
            _commandsEmailDataRepositoryMock.Verify(x => x.AddEmail(command.Contract, cancellationToken), Times.Once);
        }

        [Test]
        public async Task Handle_ShouldThrowException_WhenRepositoryThrowsException()
        {
            // Arrange
            var command = new AddEmailCommand
            {
                Contract = new CreatedEmailExternal
                {
                    Address = "test@example.com",
                    CustomerId = 1,
                    VerificationStatus = VerificationStatusEnum.Positive
                }
            };
            
            var cancellationToken = new CancellationToken();

            _commandsEmailDataRepositoryMock
                .Setup(x => x.AddEmail(command.Contract, cancellationToken))
                .ThrowsAsync(new System.Exception("Repository error"));

            // Act
            Func<Task> act = async () => await _handler.Handle(command, cancellationToken);

            // Assert
            await act.Should().ThrowAsync<System.Exception>().WithMessage("Repository error");
        }
    }
}