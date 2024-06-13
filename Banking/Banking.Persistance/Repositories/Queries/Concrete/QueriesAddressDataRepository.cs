using AutoMapper;
using Banking.Persistance.Repositories.Base;
using Banking.Persistance.Repositories.Queries.Abstract;
using BankingApp.DataTransferObject.Externals;
using BankingApp.DataTransferObject.Internals.CutomerPersonalData;
using Microsoft.EntityFrameworkCore;

namespace Banking.Persistance.Repositories.Queries.Concrete
{
    internal class QueriesAddressDataRepository : IQueriesAddressDataRepository
    {
        private readonly IQueryDbContext _queryDbContext;
        private readonly IMapper _mapper;

        public QueriesAddressDataRepository(IQueryDbContext queryDbContext, IMapper mapper)
        {
            _queryDbContext = queryDbContext;
            _mapper = mapper;
        }

        public async Task<AddressDto> GetAddressById(int addressId)
        {
            var address = await _queryDbContext.Addresses.FirstOrDefaultAsync(a => a.Id == addressId);
            var result = _mapper.Map<AddressDto>(address);
            return result;
        }

        public Task<int> AddAddress(AddressExternal address)
        {
            throw new NotImplementedException();
        }

        public Task<bool> EditAddress(AddressExternal address)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAddress(int addressId)
        {
            throw new NotImplementedException();
        }
    }
}
