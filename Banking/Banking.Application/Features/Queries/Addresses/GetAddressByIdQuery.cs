using BankingApp.DataTransferObject.Internals.CutomerPersonalData;
using MediatR;

namespace Banking.Application.Features.Queries.Addresses
{
    internal record GetAddressByIdQuery : IRequest<AddressDto>
    {
        public required int AddressId { get; init; }
    }
}
