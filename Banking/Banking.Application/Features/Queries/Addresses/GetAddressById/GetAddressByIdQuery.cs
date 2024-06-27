using BankingApp.DataTransferObject.Internals.CutomerPersonalData;
using MediatR;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Banking.Application.UnitTests")]
namespace Banking.Application.Features.Queries.Addresses.GetAddressById
{
    internal record GetAddressByIdQuery : IRequest<AddressDto>
    {
        public required int AddressId { get; init; }
    }
}
