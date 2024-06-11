using Banking.Persistance.Repositories.Queries.Abstract;

namespace Banking.Application.Features.Queries
{
    internal record QueriesBase
    {
        protected readonly IQueriesCustomerDataRepository _queriesCustomerDataRepository;

        public QueriesBase(IQueriesCustomerDataRepository queriesCustomerDataRepository)
        {
            _queriesCustomerDataRepository = queriesCustomerDataRepository;
        }
    }
}
