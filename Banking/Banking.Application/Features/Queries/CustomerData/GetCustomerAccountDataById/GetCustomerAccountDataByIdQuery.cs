using BankingApp.DataTransferObject.Internals.CustomerAccountData;
using MediatR;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Banking.Application.UnitTests")]
namespace Banking.Application.Features.Queries.CustomerData.GetCustomerAccountDataById
{
    internal record GetCustomerAccountDataByIdQuery : IRequest<CustomerAccountDataDto>
    {
        public required Guid CustomerNumber { get; init; }
    }
}
