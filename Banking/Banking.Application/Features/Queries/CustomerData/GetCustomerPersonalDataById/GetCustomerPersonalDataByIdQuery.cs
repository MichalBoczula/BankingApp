using Azure.Core;
using BankingApp.DataTransferObject.Internals.CutomerPersonalData;
using MediatR;

namespace Banking.Application.Features.Queries.CustomerData.GetCustomerPersonalDataById
{
    internal record GetCustomerPersonalDataByIdQuery : IRequest<CustomerPersonalDataDto>
    {
        public required Guid CustomerNumber { get; init; }
    }
}
