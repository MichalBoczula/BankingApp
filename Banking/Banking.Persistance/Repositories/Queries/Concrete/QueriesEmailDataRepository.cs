using AutoMapper;
using Banking.Persistance.Repositories.Base;
using Banking.Persistance.Repositories.Queries.Abstract;
using BankingApp.DataTransferObject.Internals.CutomerPersonalData;
using Microsoft.EntityFrameworkCore;

namespace Banking.Persistance.Repositories.Queries.Concrete
{
    internal class QueriesEmailDataRepository : IQueriesEmailDataRepository
    {
        private readonly IQueryDbContext _queryDbContext;
        private readonly IMapper _mapper;

        public QueriesEmailDataRepository(IQueryDbContext queryDbContext, IMapper mapper)
        {
            _queryDbContext = queryDbContext;
            _mapper = mapper;
        }

        public async Task<EmailDto> GetEmailById(int emailId)
        {
            var email = await _queryDbContext.Emails.FirstOrDefaultAsync(e => e.Id == emailId);
            var result = _mapper.Map<EmailDto>(email);
            return result;
        }
    }
}
