using BankingApp.DataTransferObject.Externals;
using MediatR;

namespace Banking.Application.Features.Commands.Addresses.AddAddress
{
    internal record AddAddressCommand : IRequest<int>
    {
        public required AddressExternal Contract { get; init; }
    }
}
