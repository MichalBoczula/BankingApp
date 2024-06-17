using AutoMapper;
using Banking.Domain.Entities;
using Banking.Persistance.Repositories.Base;
using Banking.Persistance.Repositories.Commands.Abstract;
using BankingApp.DataTransferObject.Externals;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Banking.Persistance.Repositories.Commands.Concrete
{
    internal class CommandsAddressDataRepository : ICommandsAddressDataRepository
    {
        private readonly ICommandDbContext _context;
        private readonly IMapper _mapper;

        public CommandsAddressDataRepository(ICommandDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> AddAddress(AddressExternal address, CancellationToken cancellationToken)
        {
            var addressToAdd = _mapper.Map<Address>(address);
            await _context.Addresses.AddAsync(addressToAdd);
            await _context.SaveChangesAsync(cancellationToken);
            return addressToAdd.Id;
        }

        public async Task<bool> EditAddress(AddressExternal address, CancellationToken cancellationToken)
        {
            var addressToUpdate = _mapper.Map<Address>(address);
            _context.Addresses.Update(addressToUpdate);
            var result = await _context.SaveChangesAsync(cancellationToken);
            return Convert.ToBoolean(result);
        }

        public async Task<bool> DeleteAddress(int addressId, CancellationToken cancellationToken)
        {
            var addressToRemove = await _context.Addresses.FirstOrDefaultAsync(x => x.Id == addressId);
            
            if (addressToRemove != null)
            {
                return false;
            }
            
            _context.Addresses.Remove(addressToRemove);
            var result = await _context.SaveChangesAsync(cancellationToken);
            return Convert.ToBoolean(result);
        }
    }
}
