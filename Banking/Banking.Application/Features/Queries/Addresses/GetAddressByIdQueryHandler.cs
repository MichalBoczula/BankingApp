using Banking.Persistance.Repositories.Queries.Abstract;
using BankingApp.DataTransferObject.Internals.CutomerPersonalData;
using MediatR;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Banking.Application.UnitTests")]
namespace Banking.Application.Features.Queries.Addresses
{
    internal record GetAddressByIdQueryHandler : IRequestHandler<GetAddressByIdQuery, AddressDto>
    {
        private readonly IQueriesAddressDataRepository _queriesAddressDataRepository;

        public GetAddressByIdQueryHandler(IQueriesAddressDataRepository queriesAddressDataRepository)
        {
            _queriesAddressDataRepository = queriesAddressDataRepository;
        }

        public async Task<AddressDto> Handle(GetAddressByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _queriesAddressDataRepository.GetAddressById(request.AddressId);
            return result;
        }
    }
}
