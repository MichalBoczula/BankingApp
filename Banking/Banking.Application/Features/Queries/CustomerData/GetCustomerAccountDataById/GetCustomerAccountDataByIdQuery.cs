using BankingApp.DataTransferObject.Internals.CustomerAccountData;
using MediatR;

namespace Banking.Application.Features.Queries.CustomerData.GetCustomerAccountDataById
{
    internal record GetCustomerAccountDataByIdQuery : IRequest<CustomerAccountDataDto>
    {
        public required Guid CustomerNumber { get; init; }
    }
}
