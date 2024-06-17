using BankingApp.DataTransferObject.Externals;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Banking.Application")]
[assembly: InternalsVisibleTo("Banking.Application.UnitTests")]
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]
namespace Banking.Persistance.Repositories.Commands.Abstract
{
    internal interface ICommandsAddressDataRepository
    {
        Task<int> AddAddress(CreatedAddressExternal address, CancellationToken cancellationToken);
        Task<bool> EditAddress(UpdatedAddressExternal address, int addressId, CancellationToken cancellationToken);
        Task<bool> DeleteAddress(int addressId, CancellationToken cancellationToken);
    }
}
