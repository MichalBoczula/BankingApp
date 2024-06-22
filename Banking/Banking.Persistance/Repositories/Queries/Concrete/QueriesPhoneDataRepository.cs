using AutoMapper;
using Banking.Persistance.Repositories.Base;
using Banking.Persistance.Repositories.Queries.Abstract;
using BankingApp.DataTransferObject.Internals.CutomerPersonalData;
using Microsoft.EntityFrameworkCore;

namespace Banking.Persistance.Repositories.Queries.Concrete
{
    internal class QueriesPhoneDataRepository : IQueriesPhoneDataRepository
    {
        private readonly IQueryDbContext _queryDbContext;
        private readonly IMapper _mapper;

        public QueriesPhoneDataRepository(IQueryDbContext queryDbContext, IMapper mapper)
        {
            _queryDbContext = queryDbContext;
            _mapper = mapper;
        }

        public async Task<PhoneDto> GetPhoneById(int phoneId)
        {
            var phone = await _queryDbContext.Phones.FirstOrDefaultAsync(p => p.Id == phoneId);
            var result = _mapper.Map<PhoneDto>(phone);
            return result;
        }
    }
}
