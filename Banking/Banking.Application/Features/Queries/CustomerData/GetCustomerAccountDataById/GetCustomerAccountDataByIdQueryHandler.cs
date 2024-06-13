using Banking.Persistance.Repositories.Queries.Abstract;
using BankingApp.DataTransferObject.Internals.CustomerAccountData;
using MediatR;

namespace Banking.Application.Features.Queries.CustomerData.GetCustomerAccountDataById
{
    internal record GetCustomerAccountDataByIdQueryHandler : IRequestHandler<GetCustomerAccountDataByIdQuery, CustomerAccountDataDto>
    {
        private readonly IQueriesCustomerDataRepository _queriesCustomerDataRepository;

        public GetCustomerAccountDataByIdQueryHandler(IQueriesCustomerDataRepository queriesCustomerDataRepository)
        {
            _queriesCustomerDataRepository = queriesCustomerDataRepository;
        }

        public async Task<CustomerAccountDataDto> Handle(GetCustomerAccountDataByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _queriesCustomerDataRepository.GetCustomerAccountData(request.CustomerNumber);
            return result;
        }
    }
}
