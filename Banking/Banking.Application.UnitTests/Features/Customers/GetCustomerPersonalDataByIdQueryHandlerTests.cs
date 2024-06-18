using Banking.Application.Features.Queries.CustomerData.GetCustomerPersonalDataById;
using Banking.Persistance.Repositories.Queries.Abstract;
using BankingApp.DataTransferObject.Internals.CutomerPersonalData;
using FluentAssertions;
using Moq;

namespace Banking.Application.UnitTests.Features.Customers
{
    [TestFixture]
    public class GetCustomerPersonalDataByIdQueryHandlerTests
    {
        private Mock<IQueriesCustomerDataRepository> _queriesCustomerDataRepositoryMock;
        private GetCustomerPersonalDataByIdQueryHandler _handler;

        [SetUp]
        public void SetUp()
        {
            _queriesCustomerDataRepositoryMock = new Mock<IQueriesCustomerDataRepository>();
            _handler = new GetCustomerPersonalDataByIdQueryHandler(_queriesCustomerDataRepositoryMock.Object);
        }

        [Test]
        public async Task Handle_ShouldReturnCustomerPersonalData_WhenCustomerExists()
        {
            // Arrange
            var customerNumber = Guid.NewGuid();
            var expectedCustomerData = new CustomerPersonalDataDto
            {
                CustomerNumber = customerNumber
            };

            _queriesCustomerDataRepositoryMock
                .Setup(repo => repo.GetCustomerPersonalData(customerNumber))
                .ReturnsAsync(expectedCustomerData);

            var query = new GetCustomerPersonalDataByIdQuery { CustomerNumber = customerNumber };

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(expectedCustomerData);

            _queriesCustomerDataRepositoryMock.Verify(repo => repo.GetCustomerPersonalData(customerNumber), Times.Once);
        }

        [Test]
        public async Task Handle_ShouldReturnNull_WhenCustomerDoesNotExist()
        {
            // Arrange
            var customerNumber = Guid.NewGuid();

            _queriesCustomerDataRepositoryMock
                .Setup(repo => repo.GetCustomerPersonalData(customerNumber))
                .ReturnsAsync((CustomerPersonalDataDto)null);

            var query = new GetCustomerPersonalDataByIdQuery { CustomerNumber = customerNumber };

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            result.Should().BeNull();

            _queriesCustomerDataRepositoryMock.Verify(repo => repo.GetCustomerPersonalData(customerNumber), Times.Once);
        }
    }
}
