using Banking.Application.Features.Queries.CustomerData.GetCustomerAccountDataById;
using Banking.Persistance.Repositories.Queries.Abstract;
using BankingApp.DataTransferObject.Internals.CustomerAccountData;
using FluentAssertions;
using Moq;

namespace Banking.Application.UnitTests.Features.Customers
{
    [TestFixture]
    public class GetCustomerAccountDataByIdQueryHandlerTests
    {
        private Mock<IQueriesCustomerDataRepository> _queriesCustomerDataRepositoryMock;
        private GetCustomerAccountDataByIdQueryHandler _handler;

        [SetUp]
        public void SetUp()
        {
            _queriesCustomerDataRepositoryMock = new Mock<IQueriesCustomerDataRepository>();
            _handler = new GetCustomerAccountDataByIdQueryHandler(_queriesCustomerDataRepositoryMock.Object);
        }

        [Test]
        public async Task Handle_ShouldReturnCustomerAccountData_WhenCustomerExists()
        {
            // Arrange
            var customerNumber = Guid.NewGuid();
            var expectedCustomerData = new CustomerAccountDataDto
            {
                CustomerNumber = customerNumber,
                BankingAccounts = new List<BankingAccountDto>
            {
                new BankingAccountDto { AccountNumber = Guid.NewGuid().ToString(), Balance = 1000.50m },
                new BankingAccountDto { AccountNumber = Guid.NewGuid().ToString(), Balance = 200.75m }
            }
            };

            _queriesCustomerDataRepositoryMock
                .Setup(repo => repo.GetCustomerAccountData(customerNumber))
                .ReturnsAsync(expectedCustomerData);

            var query = new GetCustomerAccountDataByIdQuery { CustomerNumber = customerNumber };

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(expectedCustomerData);

            _queriesCustomerDataRepositoryMock.Verify(repo => repo.GetCustomerAccountData(customerNumber), Times.Once);
        }

        [Test]
        public async Task Handle_ShouldReturnNull_WhenCustomerDoesNotExist()
        {
            // Arrange
            var customerNumber = Guid.NewGuid();

            _queriesCustomerDataRepositoryMock
                .Setup(repo => repo.GetCustomerAccountData(customerNumber))
                .ReturnsAsync((CustomerAccountDataDto)null);

            var query = new GetCustomerAccountDataByIdQuery { CustomerNumber = customerNumber };

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            result.Should().BeNull();

            _queriesCustomerDataRepositoryMock.Verify(repo => repo.GetCustomerAccountData(customerNumber), Times.Once);
        }
    }
}
