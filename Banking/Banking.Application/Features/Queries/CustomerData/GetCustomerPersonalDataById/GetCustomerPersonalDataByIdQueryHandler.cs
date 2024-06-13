using Banking.Persistance.Repositories.Queries.Abstract;
using BankingApp.DataTransferObject.Internals.CutomerPersonalData;
using MediatR;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Banking.Application.UnitTests")]
namespace Banking.Application.Features.Queries.CustomerData.GetCustomerPersonalDataById
{
    internal record GetCustomerPersonalDataByIdQueryHandler : IRequestHandler<GetCustomerPersonalDataByIdQuery, CustomerPersonalDataDto>
    {
        private readonly IQueriesCustomerDataRepository _queriesCustomerDataRepository;

        public GetCustomerPersonalDataByIdQueryHandler(IQueriesCustomerDataRepository queriesCustomerDataRepository)
        {
            _queriesCustomerDataRepository = queriesCustomerDataRepository;
        }

        public async Task<CustomerPersonalDataDto> Handle(GetCustomerPersonalDataByIdQuery request, CancellationToken cancellationToken)
        {
            var customerPersonalData = await _queriesCustomerDataRepository.GetCustomerPersonalData(request.CustomerNumber);
            return customerPersonalData;
        }
    }
}
