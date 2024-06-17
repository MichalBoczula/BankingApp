using AutoMapper;
using Banking.Persistance.Repositories.Base;
using Banking.Persistance.Repositories.Queries.Abstract;
using BankingApp.DataTransferObject.Internals.CustomerAccountData;
using BankingApp.DataTransferObject.Internals.CutomerPersonalData;
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
            var customer = await _queryDbContext.Customers
                .Include(x => x.BankingAccounts)
                .ThenInclude(x => x.Operations)
                .Where(c=> c.CustomerNumber == customerNumber)
                .AsNoTracking()
                .FirstOrDefaultAsync();
            var result = _mapper.Map<CustomerAccountDataDto>(customer);

            return result;
        }

        public async Task<CustomerPersonalDataDto> GetCustomerPersonalData(Guid customerNumber)
        {
            var customer = await _queryDbContext.Customers
                .Include(x => x.Addresses)
                .Include(x => x.Emails)
                .Include(x => x.Phones)
                .Where(c => c.CustomerNumber == customerNumber)
                .AsNoTracking()
                .FirstOrDefaultAsync();
            var result = _mapper.Map<CustomerPersonalDataDto>(customer);

            return result;
        }
    }
}
