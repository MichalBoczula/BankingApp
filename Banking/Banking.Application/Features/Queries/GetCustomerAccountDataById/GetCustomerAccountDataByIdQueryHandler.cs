using Banking.Persistance.Repositories.Queries.Abstract;
using BankingApp.DataTransferObject.Internals;
using MediatR;

namespace Banking.Application.Features.Queries.GetCustomerAccountDataById
{
    internal record GetCustomerAccountDataByIdQueryHandler : QueriesBase, IRequestHandler<GetCustomerAccountDataByIdQuery, CustomerAccountDataDto>
    {
        public GetCustomerAccountDataByIdQueryHandler(IQueriesCustomerDataRepository queriesCustomerDataRepository) : base(queriesCustomerDataRepository)
        {
        }

        public async Task<CustomerAccountDataDto> Handle(GetCustomerAccountDataByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _queriesCustomerDataRepository.GetCustomerAccountData(request.CustomerNumber);
            return result;
        }
    }
}
