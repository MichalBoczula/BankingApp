﻿using AutoMapper;
using Banking.Domain.Entities;
using Banking.Persistance.Repositories.Base;
using Banking.Persistance.Repositories.Commands.Abstract;
using BankingApp.DataTransferObject.Externals;
using Microsoft.EntityFrameworkCore;

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

        public async Task<int> AddAddress(CreatedAddressExternal address, CancellationToken cancellationToken)
        {
            var addressToAdd = _mapper.Map<Address>(address);

            await _context.Addresses.AddAsync(addressToAdd);
            await _context.SaveChangesAsync(cancellationToken);

            return addressToAdd.Id;
        }

        public async Task<bool> EditAddress(UpdatedAddressExternal address, int addressId, CancellationToken cancellationToken)
        {
            var addressToUpdate = await _context.Addresses.FirstOrDefaultAsync(x => x.Id == addressId);

            if (addressToUpdate == null)
            {
                return false;
            }

            addressToUpdate.PostCode = address.PostCode;
            addressToUpdate.Street = address.Street;
            addressToUpdate.City = address.City;
            addressToUpdate.FlatNumber = address.FlatNumber;
            addressToUpdate.BuildingNumber = address.BuildingNumber;

            _context.Addresses.Update(addressToUpdate);
            var result = await _context.SaveChangesAsync(cancellationToken);

            return Convert.ToBoolean(result);
        }

        public async Task<bool> DeleteAddress(int addressId, CancellationToken cancellationToken)
        {
            var addressToRemove = await _context.Addresses.FirstOrDefaultAsync(x => x.Id == addressId);

            if (addressToRemove == null)
            {
                return false;
            }

            _context.Addresses.Remove(addressToRemove);

            var result = await _context.SaveChangesAsync(cancellationToken);

            return Convert.ToBoolean(result);
        }
    }
}
