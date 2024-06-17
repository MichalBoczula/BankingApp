using BankingApp.DataTransferObject.Externals;
using MediatR;

namespace Banking.Application.Features.Commands.Addresses.DeleteAddress
{
    internal class DeleteAddressCommand : IRequest<bool>
    {
        public required int AddressId { get; init; }
    }
}
