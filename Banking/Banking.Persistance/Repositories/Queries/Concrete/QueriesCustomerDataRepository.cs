using AutoMapper;
using Banking.Persistance.Repositories.Base;
using Banking.Persistance.Repositories.Queries.Abstract;
using BankingApp.DataTransferObject.Internals;
using Microsoft.EntityFrameworkCore;

namespace Banking.Persistance.Repositories.Queries.Concrete
{
    internal class QueriesCustomerDataRepository : IQueriesCustomerDataRepository
    {
        private readonly IQueryDbContext _queryDbContext;
        private readonly IMapper _mapper;

        public QueriesCustomerDataRepository(IQueryDbContext queryDbContext, IMapper mapper)
        {
            _queryDbContext = queryDbContext;
            _mapper = mapper;
        }

        public async Task<CustomerAccountDataDto> GetCustomerAccountData(Guid customerNumber)
        {
            var customer = await _queryDbContext.Customers.Where(c=> c.CustomerNumber == customerNumber).FirstOrDefaultAsync();
            var result = _mapper.Map<CustomerAccountDataDto>(customer);
            return result;
        }
    }
}
