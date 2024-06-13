using BankingApp.DataTransferObject.Internals.CutomerPersonalData;
using MediatR;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Banking.Application.UnitTests")]
namespace Banking.Application.Features.Queries.CustomerData.GetCustomerPersonalDataById
{
    internal record GetCustomerPersonalDataByIdQuery : IRequest<CustomerPersonalDataDto>
    {
        public required Guid CustomerNumber { get; init; }
    }
}
