using Banking.Application.Features.Queries.Emails;
using Banking.Persistance.Repositories.Queries.Abstract;
using BankingApp.DataTransferObject.Internals.CutomerPersonalData;
using FluentAssertions;
using Moq;

namespace Banking.Application.UnitTests.Features.Emails
{
    [TestFixture]
    public class GetEmailByIdQueryHandlerTests
    {
        private Mock<IQueriesEmailDataRepository> _queriesEmailDataRepositoryMock;
        private GetEmailByIdQueryHandler _handler;

        [SetUp]
        public void SetUp() 
        {
            _queriesEmailDataRepositoryMock = new Mock<IQueriesEmailDataRepository>();
            _handler = new GetEmailByIdQueryHandler(_queriesEmailDataRepositoryMock.Object);
        }

        [Test]
        public async Task Handle_ShouldReturnAddress_WhenEmailExists()
        {
            // Arrange
            var emailId = 1;
            var expectedEmails = new EmailDto
            {
                Address = "qwert@test.com",
            };

            _queriesEmailDataRepositoryMock
                .Setup(repo => repo.GetEmailById(emailId))
                .ReturnsAsync(expectedEmails);

            var query = new GetEmailByIdQuery { EmailId = emailId };

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(expectedEmails);

            _queriesEmailDataRepositoryMock.Verify(repo => repo.GetEmailById(emailId), Times.Once);
        }

        [Test]
        public async Task Handle_ShouldReturnNull_WhenEmailDoesNotExist()
        {
            // Arrange
            var emailId = 1;

            _queriesEmailDataRepositoryMock
                .Setup(repo => repo.GetEmailById(emailId))
                .ReturnsAsync((EmailDto)null);

            var query = new GetEmailByIdQuery { EmailId = emailId };

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            result.Should().BeNull();

            _queriesEmailDataRepositoryMock.Verify(repo => repo.GetEmailById(emailId), Times.Once);
        }
    }
}
