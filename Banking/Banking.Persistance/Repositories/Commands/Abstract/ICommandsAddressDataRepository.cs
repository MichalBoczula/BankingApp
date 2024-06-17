using BankingApp.DataTransferObject.Externals;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Banking.Application")]
[assembly: InternalsVisibleTo("Banking.Application.UnitTests")]
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]
namespace Banking.Persistance.Repositories.Commands.Abstract
{
    internal interface ICommandsAddressDataRepository
    {
        Task<int> AddAddress(AddressExternal address, CancellationToken cancellationToken);
        Task<bool> EditAddress(AddressExternal address, CancellationToken cancellationToken);
        Task<bool> DeleteAddress(int addressId, CancellationToken cancellationToken);
    }
}
