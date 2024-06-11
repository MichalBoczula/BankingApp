using BankingApp.DataTransferObject.Internals;
using MediatR;

namespace Banking.Application.Features.Queries.GetCustomerAccountDataById
{
    internal record GetCustomerAccountDataByIdQuery : IRequest<CustomerAccountDataDto>
    {
        public required Guid CustomerNumber { get; init; }
    }
}
