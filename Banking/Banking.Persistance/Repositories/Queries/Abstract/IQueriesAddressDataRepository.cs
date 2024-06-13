using BankingApp.DataTransferObject.Externals;
using BankingApp.DataTransferObject.Internals.CutomerPersonalData;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Banking.Application")]
namespace Banking.Persistance.Repositories.Queries.Abstract
{
    internal interface IQueriesAddressDataRepository
    {
        Task<AddressDto> GetAddressById(int addressId);
        Task<int> AddAddress(AddressExternal address);
        Task<bool> EditAddress(AddressExternal address);
        Task<bool> DeleteAddress(int addressId);
    }
}
