using BankingApp.DataTransferObject.Externals;
using MediatR;

namespace Banking.Application.Features.Commands.Addresses.EditAddress
{
    internal record EditAddressCommand : IRequest<bool>
    {
        public required int AddressId { get; init; }
        public required UpdatedAddressExternal Contract { get; init; }
    }
}
