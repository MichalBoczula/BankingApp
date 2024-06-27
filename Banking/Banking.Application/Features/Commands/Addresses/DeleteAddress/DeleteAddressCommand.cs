using BankingApp.DataTransferObject.Externals;
using MediatR;

namespace Banking.Application.Features.Commands.Addresses.DeleteAddress
{
    internal record DeleteAddressCommand : IRequest<bool>
    {
        public required int AddressId { get; init; }
    }
}
